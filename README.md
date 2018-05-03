FDMeasure
---------

# FDCurve (Arduino Part)
## Command List
* **i** <br /> Initialize the force sensor and variables.
* **s** <br /> Emergency stop.
* **p** <br /> Probe a target for 5 mm downward.
* **r** <br /> Print out current force sensor value reading.
* **m[dist]** <br /> Measure the force-displacement data for **[dist]** mm. It will print out the measured values.
* **d[dist]** <br /> Move the platform *downward* for **[dist]** mm.
* **u[dist]** <br /> Move the platform *upward* for **[dist]** mm.

# Circuit
* TBA

BOM (warning: not complete)
---------
* 2020 Aluminum extrusion (176 mm * 3ea, 270 mm * 3 ea) + right angle brakets, bolts, drop-in nuts, etc.
* 5mm lead screw (ACME thread), lead = 2 mm, length = 150 mm
* 5mm-5mm copper coupler
* Arduino Leonardo Board + proto shield
* StepStick (A4988)
* DFRobot weight sensor module (1kg load cell + HX711 driver board)
* NEMA17 stepper motor
* NEMA17 L bracket (https://www.aliexpress.com/item/NEMA-17-Mounting-L-Bracket-Mount-Step-Stepping-Stepper-Motor/32679480037.html)
* 5 mm acrylic plate (lasercutted)
* Microswitches (for endstops)
* 3D printed parts
* MGN9 Linear rail (180 mm) + block * 2 ea each
* bolts, nuts (M3, M4, M5, various lengths)
