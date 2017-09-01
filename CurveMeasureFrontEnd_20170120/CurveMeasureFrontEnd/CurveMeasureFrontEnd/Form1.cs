using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using System.Windows.Forms.DataVisualization.Charting;

namespace CurveMeasureFrontEnd
{
    public partial class Form1 : Form
    {
        bool isMeasuring = false;
        bool downTrigger = false;
        bool upTrigger = false;

        Dictionary<String, Color> colorMaps = new Dictionary<String, Color>();

        // Trigger timing chart (Down/UP)
        // Start (F/F) => Pressed (T/F)->(T/T) => Released (F/T)->(T/T) => End (T/T)

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            String[] ports = SerialPort.GetPortNames();
            comboBoxSerials.Items.Clear();
            comboBoxSerials.Items.AddRange(ports);
            if (ports.Length > 0)
            {
                comboBoxSerials.SelectedIndex = comboBoxSerials.Items.Count - 1;
                serial.BaudRate = 19200;
                serial.DtrEnable = true;
                serial.RtsEnable = true;
            }
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (!serial.IsOpen)
            {
                serial.PortName = (String)comboBoxSerials.Items[comboBoxSerials.SelectedIndex];
                serial.Open();
                serial.ReadExisting();
                buttonConnect.BackColor = Color.Orange;
                textBoxLog.Text += "Connected to " + serial.PortName + "\r\n";
                textBoxLog.Select(textBoxLog.TextLength, 0);
                textBoxLog.ScrollToCaret();
            }
            else
            {
                serial.Close();
                buttonConnect.BackColor = SystemColors.ButtonFace;
                textBoxLog.Text += "Disconnected from " + serial.PortName + "\r\n";
                textBoxLog.Select(textBoxLog.TextLength, 0);
                textBoxLog.ScrollToCaret();
            }
        }


        // Trigger timing chart (Down/UP)
        // Start (F/F) => Pressed (T/F)->(T/T) => Released (F/T) => End (T/T)
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (isMeasuring)
            {
                if (!downTrigger && !upTrigger)
                    downTrigger = true;
                
                e.Handled = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (isMeasuring)
            {
                if (downTrigger && upTrigger)
                {
                    upTrigger = true;
                    downTrigger = false;
                }
                e.Handled = true;
            }
        }


        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (isMeasuring)
            {
                if (!downTrigger && !upTrigger)
                    downTrigger = true;
            }

        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            if (isMeasuring)
            {
                if (downTrigger && upTrigger)
                {
                    upTrigger = true;
                    downTrigger = false;
                }
            }
        }


        private void serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;

            if (sp.IsOpen)
            {
                string read = sp.ReadLine().Trim();


                if (read.Equals("STOP!") || read.Equals("Done!"))
                {
                    this.Invoke(new Action(delegate()
                    {
                        buttonMeasureStart.Enabled = true;
                    }));
                    isMeasuring = false;
                    if (read.Equals("Done!"))
                    {
                        this.Invoke(new Action(delegate()
                        {
                            buttonSave.Enabled = true;
                        }));
                    }
                }

                if (isMeasuring)
                {
                    String[] split = read.Split("\t".ToCharArray());
                    if (split.Length == 2)
                    {
                        double displacement, force;
                        displacement = force = 0;
                        if (Double.TryParse(split[0], out displacement) && Double.TryParse(split[1], out force))
                        {
                            System.Windows.Forms.DataVisualization.Charting.DataPointCollection data = chartFDGraph.Series[0].Points;
                            System.Windows.Forms.DataVisualization.Charting.DataPointCollection point = chartFDGraph.Series[1].Points;
                            
                            this.Invoke(new Action(delegate() 
                            {
                                data.AddXY(displacement, force);
                                if (downTrigger && !upTrigger)
                                {
                                    point.AddXY(displacement, force);
                                    point[point.Count - 1].Color = Color.Red;
                                    upTrigger = true;
                                }

                                if (upTrigger && !downTrigger)
                                {
                                    point.AddXY(displacement, force);
                                    point[point.Count - 1].Color = Color.Blue;
                                    downTrigger = true;
                                }
                            }));
                        }
                    }
                }

                if (read.Equals("Start!"))
                {
                    isMeasuring = true;
                    this.Invoke(new Action(delegate()
                    {
                        buttonMeasureStart.Enabled = false;
                    }));

                }


                this.Invoke(new Action(delegate() 
                {
                    if(textBoxLog.Text.Length > textBoxLog.MaxLength)
                    {
                        textBoxLog.Text = textBoxLog.Text.Substring(textBoxLog.MaxLength / 2);
                    }
                    textBoxLog.Text += read + "\r\n";
                    textBoxLog.Select(textBoxLog.TextLength, 0);
                    textBoxLog.ScrollToCaret();                   

                }));
                
            }
        }
        // If "enter" key is received, then send the command
        private void textBoxCommand_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r')
            {
                if (serial.IsOpen)
                {
                    serial.WriteLine(textBoxCommand.Text + "\n");
                }
                textBoxCommand.Text = "";
            }

        }

        // If "enter" key is received, then send (move amount) the command. The command types are tagged on the buttons.
        private void textBoxMove_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox box = (TextBox)sender;
            String tag = (string)box.Tag;

            if (e.KeyChar == '\r')
            {
                double number = 0;
                bool isNumeric = Double.TryParse(box.Text, out number);

                if (isNumeric && serial.IsOpen)
                {
                    string outText = String.Format("{0}{1:0.00}\n", tag, number);
                    serial.WriteLine(outText);
                }
            }
        }

        // each button should have "Tag" for their commands.
        private void buttonMoves_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            String tag = (string)b.Tag;

            if (serial.IsOpen)
                serial.WriteLine(tag + "\n");
        }

        private void buttonStop_Click(object sender, EventArgs e)
        {
            if (serial.IsOpen)
                serial.WriteLine("s\n");
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (serial.IsOpen)
            {
                serial.Close();
            }
        }

        private void buttonProbe_Click(object sender, EventArgs e)
        {
            if (serial.IsOpen)
                serial.WriteLine("p\n");
        }

        private void buttonInit_Click(object sender, EventArgs e)
        {
            if (serial.IsOpen)
                serial.WriteLine("i\n");
        }

        private void buttonMeasureStart_Click(object sender, EventArgs e)
        {
            TextBox measureBox = textBoxMeasureLength;
            double length = 0;

            bool isNumeric = Double.TryParse(measureBox.Text, out length);

            if (isNumeric && serial.IsOpen)
            {
                string outText = String.Format("m{0:0.00}\n",length);
                serial.WriteLine(outText);

                downTrigger = upTrigger = isMeasuring = false;

                chartFDGraph.Series.Clear();
                chartFDGraph.Legends.Clear();

                Series s = new Series("Measure");
                s.ChartType = SeriesChartType.Line;

                Series s2 = new Series("Actuation");
                s2.ChartType = SeriesChartType.Point;

                chartFDGraph.Series.Add(s);
                chartFDGraph.Series.Add(s2);
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Displays a SaveFileDialog so the user can save the Image
            // assigned to Button2.
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Comma Separated Values (CSV)|*.csv";
            saveFileDialog1.Title = "Save the Force-Displacement graph";
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFileDialog1.OpenFile());

                DataPointCollection graph = chartFDGraph.Series[0].Points;
                DataPointCollection actuation = chartFDGraph.Series[1].Points;

                double press = 0;
                double release = 0;
                if (actuation.Count == 2)
                {
                    press = actuation[0].XValue;
                    release = actuation[1].XValue;
                }

                sw.WriteLine("Displacement,Force,,Press,{0:0},Release,{1:0}", press, release);

                foreach (DataPoint p in graph)
                {
                    String s = string.Format("{0:0},{1}", p.XValue, p.YValues[0]);
                    sw.WriteLine(s);
                }

                sw.Flush();
                sw.Close();
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            if(chartFDGraph.Series.Count < 2)
                buttonSave.Enabled = false;

            if(chartFDGraph.Series.Count >= 2 && chartFDGraph.Series[1].ChartType != SeriesChartType.Point)
                buttonSave.Enabled = false;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Comma Separated Values (CSV)|*.csv";
            openFileDialog1.Title = "Open the Force-Displacement graph(s)";
            openFileDialog1.Multiselect = true;
            openFileDialog1.ShowDialog();

            //chartFDGraph.Series.Clear();
           
            foreach (String path in openFileDialog1.FileNames)
            {
                string fname = System.IO.Path.GetFileNameWithoutExtension(path);

                Series s = new Series(fname);
                s.ChartType = SeriesChartType.Line;

                System.IO.StreamReader sr = new System.IO.StreamReader(path);
                String top = sr.ReadLine();
                String line;

                String[] titles = top.Split(",".ToCharArray(), StringSplitOptions.None);
                if (titles.Length != 7)
                {
                    continue;
                }

                // load press/release points. (5th, 7th item in the first line)
                double press = 0;
                double release = 0;
                double.TryParse(titles[4], out press);
                double.TryParse(titles[6], out release);

                bool isPress = true;
                double lastval = 0;

                while ((line = sr.ReadLine()) != null)
                {
                    String[] values = line.Split(",".ToCharArray(),StringSplitOptions.None);
                    if(values.Length != 2)
                    {
                        sr.Close();
                        break;
                    }

                    double x, y;
                    if(double.TryParse(values[0],out x) && double.TryParse(values[1],out y))
                    {
                        s.Points.AddXY(x, y);

                        // press actuation point highlight
                        if (isPress && press != 0 && x == press)
                        {
                            s.Points.Last().MarkerStyle = MarkerStyle.Circle;
                        }

                        // release actuation point highlight
                        if (!isPress && release != 0 && x == release)
                        {
                            s.Points.Last().MarkerStyle = MarkerStyle.Diamond;
                        }

                        // make upward curve dashed.
                        if(!isPress)
                        {
                            s.Points.Last().BorderDashStyle = ChartDashStyle.Dot;
                        }

                        if (lastval > x)
                        {
                            isPress = false;
                        }
                        lastval = x;
                    }
                }

                try
                {
                    chartFDGraph.Series.Add(s);
                }
                catch (ArgumentException) { }
                
                s.MarkerSize = 10;
                s.BorderWidth = 2;

                sr.Close();
            }

            chartFDGraph.Legends.Clear();
            chartFDGraph.Legends.Add("Curves");
            chartFDGraph.Legends[0].DockedToChartArea = chartFDGraph.ChartAreas[0].Name;
            chartFDGraph.Legends[0].Docking = Docking.Top;
            //chartFDGraph.Legends[0].Font = new Font(FontFamily.GenericSansSerif, 6f);
            chartFDGraph.Legends[0].MaximumAutoSize = 0.1f;

            colorMaps.Clear();
            foreach(Series srs in chartFDGraph.Series)
            {
                colorMaps.Add(srs.Name, srs.Color);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            buttonSave.Enabled = false;

            chartFDGraph.Legends.Clear();
            chartFDGraph.Series.Clear();
        }

        private void chartFDGraph_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult result = chartFDGraph.HitTest(e.X, e.Y);

            // highlight the clicked series.
            if (result.ChartElementType == ChartElementType.DataPoint || result.ChartElementType == ChartElementType.LegendItem)
            {
                result.Series.BorderWidth = 5;
                result.Series.MarkerSize = 20;
                result.Series.MarkerBorderColor = Color.Red;
                result.Series.MarkerBorderWidth = 3;
                result.Series.Color = Color.Black;
            }

            // preserving other lines' colors
            foreach (Series s in chartFDGraph.Series)
            {
                if (s == result.Series)
                    continue;
                s.BorderWidth = 2;
                s.MarkerBorderColor = Color.Transparent;
                s.MarkerBorderWidth = 0;
                s.MarkerSize = 10;
                try
                {
                    s.Color = colorMaps[s.Name];
                }
                catch { }
                
            }
        }



    }
}
