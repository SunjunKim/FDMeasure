namespace CurveMeasureFrontEnd
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            this.comboBoxSerials = new System.Windows.Forms.ComboBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.serial = new System.IO.Ports.SerialPort(this.components);
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.textBoxCommand = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonUp01 = new System.Windows.Forms.Button();
            this.buttonUp1 = new System.Windows.Forms.Button();
            this.buttonUp5 = new System.Windows.Forms.Button();
            this.buttonUp10 = new System.Windows.Forms.Button();
            this.buttonDown10 = new System.Windows.Forms.Button();
            this.buttonDown5 = new System.Windows.Forms.Button();
            this.buttonDown1 = new System.Windows.Forms.Button();
            this.buttonDown01 = new System.Windows.Forms.Button();
            this.textBoxDown = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonProbe = new System.Windows.Forms.Button();
            this.textBoxMeasureLength = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.buttonMeasureStart = new System.Windows.Forms.Button();
            this.buttonInit = new System.Windows.Forms.Button();
            this.chartFDGraph = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.chartFDGraph)).BeginInit();
            this.SuspendLayout();
            // 
            // comboBoxSerials
            // 
            this.comboBoxSerials.FormattingEnabled = true;
            this.comboBoxSerials.Location = new System.Drawing.Point(17, 18);
            this.comboBoxSerials.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxSerials.Name = "comboBoxSerials";
            this.comboBoxSerials.Size = new System.Drawing.Size(171, 26);
            this.comboBoxSerials.TabIndex = 0;
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(199, 15);
            this.buttonConnect.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(107, 34);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // serial
            // 
            this.serial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serial_DataReceived);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(17, 57);
            this.textBoxLog.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxLog.MaxLength = 1000;
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(287, 168);
            this.textBoxLog.TabIndex = 2;
            // 
            // textBoxCommand
            // 
            this.textBoxCommand.Location = new System.Drawing.Point(19, 237);
            this.textBoxCommand.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxCommand.Name = "textBoxCommand";
            this.textBoxCommand.Size = new System.Drawing.Size(170, 28);
            this.textBoxCommand.TabIndex = 3;
            this.textBoxCommand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxCommand_KeyPress);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(199, 236);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 34);
            this.button1.TabIndex = 4;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // buttonUp01
            // 
            this.buttonUp01.Location = new System.Drawing.Point(17, 454);
            this.buttonUp01.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUp01.Name = "buttonUp01";
            this.buttonUp01.Size = new System.Drawing.Size(107, 34);
            this.buttonUp01.TabIndex = 5;
            this.buttonUp01.Tag = "u0.1";
            this.buttonUp01.Text = "▲ 0.1";
            this.buttonUp01.UseVisualStyleBackColor = true;
            this.buttonUp01.Click += new System.EventHandler(this.buttonMoves_Click);
            // 
            // buttonUp1
            // 
            this.buttonUp1.Location = new System.Drawing.Point(17, 411);
            this.buttonUp1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUp1.Name = "buttonUp1";
            this.buttonUp1.Size = new System.Drawing.Size(107, 34);
            this.buttonUp1.TabIndex = 6;
            this.buttonUp1.Tag = "u1";
            this.buttonUp1.Text = "▲ 1";
            this.buttonUp1.UseVisualStyleBackColor = true;
            this.buttonUp1.Click += new System.EventHandler(this.buttonMoves_Click);
            // 
            // buttonUp5
            // 
            this.buttonUp5.Location = new System.Drawing.Point(17, 368);
            this.buttonUp5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUp5.Name = "buttonUp5";
            this.buttonUp5.Size = new System.Drawing.Size(107, 34);
            this.buttonUp5.TabIndex = 7;
            this.buttonUp5.Tag = "u5";
            this.buttonUp5.Text = "▲ 5";
            this.buttonUp5.UseVisualStyleBackColor = true;
            this.buttonUp5.Click += new System.EventHandler(this.buttonMoves_Click);
            // 
            // buttonUp10
            // 
            this.buttonUp10.Location = new System.Drawing.Point(17, 324);
            this.buttonUp10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUp10.Name = "buttonUp10";
            this.buttonUp10.Size = new System.Drawing.Size(107, 34);
            this.buttonUp10.TabIndex = 8;
            this.buttonUp10.Tag = "u10";
            this.buttonUp10.Text = "▲ 10";
            this.buttonUp10.UseVisualStyleBackColor = true;
            this.buttonUp10.Click += new System.EventHandler(this.buttonMoves_Click);
            // 
            // buttonDown10
            // 
            this.buttonDown10.Location = new System.Drawing.Point(19, 732);
            this.buttonDown10.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDown10.Name = "buttonDown10";
            this.buttonDown10.Size = new System.Drawing.Size(107, 34);
            this.buttonDown10.TabIndex = 12;
            this.buttonDown10.Tag = "d10";
            this.buttonDown10.Text = "▼ 10";
            this.buttonDown10.UseVisualStyleBackColor = true;
            this.buttonDown10.Click += new System.EventHandler(this.buttonMoves_Click);
            // 
            // buttonDown5
            // 
            this.buttonDown5.Location = new System.Drawing.Point(19, 688);
            this.buttonDown5.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDown5.Name = "buttonDown5";
            this.buttonDown5.Size = new System.Drawing.Size(107, 34);
            this.buttonDown5.TabIndex = 11;
            this.buttonDown5.Tag = "d5";
            this.buttonDown5.Text = "▼ 5";
            this.buttonDown5.UseVisualStyleBackColor = true;
            this.buttonDown5.Click += new System.EventHandler(this.buttonMoves_Click);
            // 
            // buttonDown1
            // 
            this.buttonDown1.Location = new System.Drawing.Point(19, 645);
            this.buttonDown1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDown1.Name = "buttonDown1";
            this.buttonDown1.Size = new System.Drawing.Size(107, 34);
            this.buttonDown1.TabIndex = 10;
            this.buttonDown1.Tag = "d1";
            this.buttonDown1.Text = "▼ 1";
            this.buttonDown1.UseVisualStyleBackColor = true;
            this.buttonDown1.Click += new System.EventHandler(this.buttonMoves_Click);
            // 
            // buttonDown01
            // 
            this.buttonDown01.Location = new System.Drawing.Point(19, 602);
            this.buttonDown01.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDown01.Name = "buttonDown01";
            this.buttonDown01.Size = new System.Drawing.Size(107, 34);
            this.buttonDown01.TabIndex = 9;
            this.buttonDown01.Tag = "d0.1";
            this.buttonDown01.Text = "▼ 0.1";
            this.buttonDown01.UseVisualStyleBackColor = true;
            this.buttonDown01.Click += new System.EventHandler(this.buttonMoves_Click);
            // 
            // textBoxDown
            // 
            this.textBoxDown.Location = new System.Drawing.Point(49, 776);
            this.textBoxDown.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxDown.Name = "textBoxDown";
            this.textBoxDown.Size = new System.Drawing.Size(74, 28);
            this.textBoxDown.TabIndex = 3;
            this.textBoxDown.Tag = "d";
            this.textBoxDown.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMove_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 782);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(24, 18);
            this.label1.TabIndex = 13;
            this.label1.Text = "▼";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 290);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(24, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "▲";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 284);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 28);
            this.textBox1.TabIndex = 16;
            this.textBox1.Tag = "u";
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxMove_KeyPress);
            // 
            // buttonStop
            // 
            this.buttonStop.BackColor = System.Drawing.Color.Red;
            this.buttonStop.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.buttonStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.buttonStop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.buttonStop.Location = new System.Drawing.Point(19, 498);
            this.buttonStop.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(106, 94);
            this.buttonStop.TabIndex = 17;
            this.buttonStop.Text = "STOP";
            this.buttonStop.UseVisualStyleBackColor = false;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // buttonProbe
            // 
            this.buttonProbe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonProbe.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonProbe.Location = new System.Drawing.Point(199, 327);
            this.buttonProbe.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonProbe.Name = "buttonProbe";
            this.buttonProbe.Size = new System.Drawing.Size(107, 34);
            this.buttonProbe.TabIndex = 18;
            this.buttonProbe.Text = "Probe";
            this.buttonProbe.UseVisualStyleBackColor = false;
            this.buttonProbe.Click += new System.EventHandler(this.buttonProbe_Click);
            // 
            // textBoxMeasureLength
            // 
            this.textBoxMeasureLength.Location = new System.Drawing.Point(156, 412);
            this.textBoxMeasureLength.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxMeasureLength.Name = "textBoxMeasureLength";
            this.textBoxMeasureLength.Size = new System.Drawing.Size(74, 28);
            this.textBoxMeasureLength.TabIndex = 20;
            this.textBoxMeasureLength.Tag = "u";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 384);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 18);
            this.label3.TabIndex = 19;
            this.label3.Text = "Measure (mm)";
            // 
            // buttonMeasureStart
            // 
            this.buttonMeasureStart.Location = new System.Drawing.Point(240, 411);
            this.buttonMeasureStart.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonMeasureStart.Name = "buttonMeasureStart";
            this.buttonMeasureStart.Size = new System.Drawing.Size(66, 34);
            this.buttonMeasureStart.TabIndex = 21;
            this.buttonMeasureStart.Text = "Start";
            this.buttonMeasureStart.UseVisualStyleBackColor = true;
            this.buttonMeasureStart.Click += new System.EventHandler(this.buttonMeasureStart_Click);
            // 
            // buttonInit
            // 
            this.buttonInit.BackColor = System.Drawing.Color.DarkGray;
            this.buttonInit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonInit.Location = new System.Drawing.Point(199, 284);
            this.buttonInit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonInit.Name = "buttonInit";
            this.buttonInit.Size = new System.Drawing.Size(107, 34);
            this.buttonInit.TabIndex = 22;
            this.buttonInit.Text = "Initialize";
            this.buttonInit.UseVisualStyleBackColor = false;
            this.buttonInit.Click += new System.EventHandler(this.buttonInit_Click);
            // 
            // chartFDGraph
            // 
            this.chartFDGraph.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chartFDGraph.BackColor = System.Drawing.Color.Transparent;
            chartArea3.AxisX.Interval = 200D;
            chartArea3.AxisX.Minimum = 0D;
            chartArea3.AxisX.Title = "Displacement (um)";
            chartArea3.AxisX.TitleAlignment = System.Drawing.StringAlignment.Near;
            chartArea3.AxisY.Interval = 10D;
            chartArea3.AxisY.Minimum = 0D;
            chartArea3.AxisY.Title = "Force (cN)";
            chartArea3.Name = "ChartArea1";
            this.chartFDGraph.ChartAreas.Add(chartArea3);
            this.chartFDGraph.Location = new System.Drawing.Point(314, -2);
            this.chartFDGraph.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.chartFDGraph.Name = "chartFDGraph";
            this.chartFDGraph.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.SemiTransparent;
            this.chartFDGraph.Size = new System.Drawing.Size(791, 824);
            this.chartFDGraph.TabIndex = 23;
            this.chartFDGraph.Text = "chartFDGraph";
            this.chartFDGraph.MouseClick += new System.Windows.Forms.MouseEventHandler(this.chartFDGraph_MouseClick);
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.Control;
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(199, 454);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(107, 34);
            this.buttonSave.TabIndex = 22;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = false;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonLoad
            // 
            this.buttonLoad.BackColor = System.Drawing.SystemColors.Control;
            this.buttonLoad.Location = new System.Drawing.Point(199, 558);
            this.buttonLoad.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(107, 34);
            this.buttonLoad.TabIndex = 24;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = false;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.SystemColors.Control;
            this.buttonClear.Location = new System.Drawing.Point(199, 602);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(107, 34);
            this.buttonClear.TabIndex = 25;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1106, 824);
            this.Controls.Add(this.buttonClear);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.chartFDGraph);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonInit);
            this.Controls.Add(this.buttonMeasureStart);
            this.Controls.Add(this.textBoxMeasureLength);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.buttonProbe);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonDown10);
            this.Controls.Add(this.buttonDown5);
            this.Controls.Add(this.buttonDown1);
            this.Controls.Add(this.buttonDown01);
            this.Controls.Add(this.buttonUp10);
            this.Controls.Add(this.buttonUp5);
            this.Controls.Add(this.buttonUp1);
            this.Controls.Add(this.buttonUp01);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBoxDown);
            this.Controls.Add(this.textBoxCommand);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.comboBoxSerials);
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Tag = "";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.chartFDGraph)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBoxSerials;
        private System.Windows.Forms.Button buttonConnect;
        private System.IO.Ports.SerialPort serial;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.TextBox textBoxCommand;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonUp01;
        private System.Windows.Forms.Button buttonUp1;
        private System.Windows.Forms.Button buttonUp5;
        private System.Windows.Forms.Button buttonUp10;
        private System.Windows.Forms.Button buttonDown10;
        private System.Windows.Forms.Button buttonDown5;
        private System.Windows.Forms.Button buttonDown1;
        private System.Windows.Forms.Button buttonDown01;
        private System.Windows.Forms.TextBox textBoxDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonProbe;
        private System.Windows.Forms.TextBox textBoxMeasureLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonMeasureStart;
        private System.Windows.Forms.Button buttonInit;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartFDGraph;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.Button buttonClear;
    }
}

