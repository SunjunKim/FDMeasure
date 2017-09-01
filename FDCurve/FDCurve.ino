/*
	FD-measure curve instrument

	This device consists of a stepper motor driver (A4988-based, refer StepStick 
        and a Hx711 module. This measures a Force-Displacement curver for a push button.
        
        * StepStick http://reprap.org/wiki/StepStick
        * Hx711 driver and Weight sensor module 
          https://www.dfrobot.com/wiki/index.php/Weight_Sensor_Module_V1

	The circuit:
	* Hx711 module 
          - #A2 = DOUT
          - #A3 = SCK
	* StepStick (A4988)
          - #D11 = Enable
          - #D12 = Step
          - #D13 = Direction
        * Endstop
          - #D7 - up/down endstop
          
        * Lead screw (attached to the stepper) : lead : 2 mm / step/mm = 100 * microstep
        * load cell: 1934.8 / gram

	Created day 2017 Jan. 17
	By Sunjun Kim (kuaa.net@gmail.com)

        Modified 2017 Mar. 22
        By Sunjun Kim (kuaa.net@gmail.com)
        * Do reverse 1mm when hit the endstop        
*/

#include <AccelStepper.h>
#include <Hx711.h>

AccelStepper stepper(1, 12, 13); //initialise accelstepper for a two wire board, pin 5 step, pin 4 dir
int EN = 11;
int STOP = 7;
Hx711 scale(A2, A3); // initialize Hx711 module, A2=Data, A3=Clock
long microStep = 4;
// HCIL: gram: 2320.6 / cN = 2275,7
// Sunjun personal: gram: 2261.8 / cN = 2218.04
float scale_mul = 2218.04;  
long scale_offset;

long mmMul = 100 * microStep;

// units: steps/sec
float moveSpeed = 2000;
float probeSpeed = 200;
float measureSpeed = 500;

float safetyForceThreshold = 900; // unit: cN
float safetyMeasureThreshold = 800; // unit: cN
float measureStep = 0.05; // unit: mm

void setup()
{
  Serial.begin(19200);

  // Hx711 init 
  scale.averageValue();
  scale_offset = scale.averageValue();
  
  // Stepper init
  stepper.setEnablePin(EN);
  stepper.setPinsInverted(false, false, true); // direction, step, enable
  
  // Endstop init
  pinMode(STOP, INPUT);
  digitalWrite(STOP, HIGH); // internal pull-up.

  initAll();
}

void initAll()
{
  scale.averageValue();
  scale_offset = scale.averageValue();

  stepper.setMaxSpeed(2000);
  stepper.setAcceleration(100000);
  stepper.setCurrentPosition(0);
  stepper.disableOutputs();  
  
  Serial.println("Init!");
}

char currentCommand = 0; // current command indicator.
int counter = 0; // force check counter for probe command
int invalidCounter = 0; // force check counter for invalidity
int endstopCounter = 0;


void loop()
{
  float distance = 0;
  
  if(Serial.available() > 0)
  {
    char c = Serial.read();
    
    switch(c)
    {
      case 'i': // Init all
        initAll();
        break;
      case 's': // STOP!
        Serial.println("STOP!");
        currentCommand = 0;
        stepper.stop();
        stepper.disableOutputs();
        break;
      case 'p': // Probe
        currentCommand = 'p';
        initProbe();
        break;
      case 'm': // Measure
        currentCommand = 'm';
        distance = Serial.parseFloat();
        if(Serial.read() == '\n')
        {
          Serial.print("Measure ");
          Serial.print(distance);
          Serial.println(" mm");
        }
        initMeasure(distance);
        break;
      case 'd': // Going down, unit = mm
      case 'u': // Going up, unit = mm
        currentCommand = 'g';
        distance = Serial.parseFloat();
        endstopCounter = 0; // allow little bit of movement just even if an endstop is hitted.
        if(Serial.read() == '\n')
        {
          Serial.print("Move ");
          Serial.print(distance);
          Serial.println(" mm");
        }
        if(c=='d')
          initGoto(distance);
        else if(c=='u')
          initGoto(distance*-1);
        break;
    }
  }
  
  switch(currentCommand)
  {
    case 'p': // Probe
      runProbe();
      break;
    case 'g': // Goto commands, unit = mm
      runGoto();
      break;
    case 'm': // Measure
      runMeasure();
      break;
  }  

  // Invalidity check
  bool invalid = false;
  if(invalidCounter++ > 5000)
  {
    invalidCounter =0;
    float force = getGram(1);
    
    if(force > 2000) {
      Serial.println("WARNING! Reverse force detected!!");
      Serial.println(force);
    }
    else if(force > safetyForceThreshold) {
      Serial.println("Too much force detected!!");
      Serial.println(force);      
      invalid = true;
    }     
  }
  
  if(isEndStop())
  {
    if(endstopCounter <= 50)
      endstopCounter++;
  }
  else
  {
    endstopCounter = 0;
  }
  
  if(endstopCounter > 25)
  {
    if(endstopCounter == 30) // debounce.
    {
      Serial.println("Endstop hit!"); 
      stepper.stop();
    }
    // move back slightly
    if(stepper.targetPosition() - stepper.currentPosition() > 0)
    {
      stepper.runToNewPosition(stepper.currentPosition()-mmMul);
      stepper.stop();
    }
    else
    {
      stepper.runToNewPosition(stepper.currentPosition()+mmMul);
      stepper.stop();
    }
    invalid = true;
  }
    
  if(invalid)
  {
    currentCommand = 0;
    stepper.stop();
    stepper.disableOutputs();
  }
}

/* ################################################################################# PROBE FUNCTION (p) */
void initProbe()
{
  stepper.setCurrentPosition(-5*mmMul); // probe only 50mm
  stepper.setSpeed(moveSpeed); // initialize stepper speed (constant speed);
  stepper.enableOutputs();
  Serial.println("Start probing");
  counter = 0;
}
void runProbe()
{
  float force = 0;
  stepper.runSpeed();
  if(counter++ == 1000)
  {
    counter = 0;
    force = getGram(1);
  }
  
  // if probing too much then emergency stop.
  if(stepper.currentPosition() > 0)
  {
    Serial.println("Probing stopped - no object detected");    
    stepper.disableOutputs();
    currentCommand = 0;
    return;
  }
  
  // if any object was detected..  
  if(force > 1.0)
  {
    currentCommand = 0;
    // move slightly upward
    stepper.stop();
    Serial.println("Detect! Start slow probing");
    stepper.setCurrentPosition(0);
    stepper.runToNewPosition(-1*mmMul);
    // probe again
    stepper.setSpeed(probeSpeed);
    delay(100);
    while(true)
    {
      stepper.runSpeed();
      
      if(Serial.available() > 0)
      {
        if(Serial.read() == 's')
        {
          Serial.println("STOP!");
          stepper.disableOutputs();
          currentCommand = 0;
          return;
        }
      }
      
      if(stepper.currentPosition() > 0.5)
      {
        Serial.println("Error! slow probing failed");
        stepper.disableOutputs();
        currentCommand = 0;
        return;
      }
      
      if(getGram(1) > 0.5)
      {
        Serial.println("Detect! Set position to 0");
        stepper.stop();
        stepper.setCurrentPosition(0);
        break;
      }      
    }
    stepper.disableOutputs();
  }
}

/* ################################################################################# MOVE FUNCTION (u/d) */
void initGoto(float dist)
{
  stepper.setMaxSpeed(2000);
  stepper.setAcceleration(100000);
  stepper.move(dist*mmMul);
  stepper.enableOutputs();
}
void runGoto()
{
  if(stepper.distanceToGo() == 0)
  {
    currentCommand = 0;
    stepper.disableOutputs();
  }
  stepper.run();
}

/* ################################################################################# MEASURE FUNCTION (m) */
bool isGoingDown = true;
void initMeasure(float dist)
{
  stepper.setSpeed(20);
  stepper.setCurrentPosition(0);
  stepper.moveTo(dist*mmMul);
  stepper.enableOutputs();
  isGoingDown = true;
  Serial.println("Start!");
}
void runMeasure()
{
  if(isGoingDown)
  {
    if(stepper.distanceToGo() == 0)
    {
      isGoingDown = false;
      stepper.moveTo(0);
    }
  }

  if(stepper.currentPosition()%(int)(mmMul*measureStep) == 0)
  {
    delay(20);
    float force = getGram(1);
    long currentUM = stepper.currentPosition()*1000/mmMul;
    Serial.print(currentUM);
    Serial.print("\t");
    Serial.println(force);
    
    // I reached the end of a switch
    if(force > safetyMeasureThreshold)
    {
      isGoingDown = false;
      stepper.moveTo(0);
    }
  }
  
  if(!isGoingDown)
  {
    if(stepper.distanceToGo() == 0)
    {
      Serial.println("Done!");
      currentCommand = 0;
      stepper.disableOutputs();
    }
  }  

  stepper.runSpeedToPosition();  
}

/* ################################################################################# etc */
float getGram(int repeat)
{
  long val = (scale.averageValue(repeat) - scale_offset);
  return (float) val / scale_mul;
}

bool isEndStop()
{
  return (digitalRead(STOP) == LOW);
}

