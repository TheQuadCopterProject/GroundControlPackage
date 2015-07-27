using System.Diagnostics;

namespace Telemetry
{
    partial class telemetryWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.motorData = new ZedGraph.ZedGraphControl();
            this.updateTimer = new System.Windows.Forms.Timer(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pwm1Box = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pwm2Box = new System.Windows.Forms.TextBox();
            this.pwm3Box = new System.Windows.Forms.TextBox();
            this.pwm4Box = new System.Windows.Forms.TextBox();
            this.hdgBox = new System.Windows.Forms.TextBox();
            this.rollBox = new System.Windows.Forms.TextBox();
            this.pitchBox = new System.Windows.Forms.TextBox();
            this.xAccelBox = new System.Windows.Forms.TextBox();
            this.yAccelBox = new System.Windows.Forms.TextBox();
            this.zAccelBox = new System.Windows.Forms.TextBox();
            this.altBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.temp1Box = new System.Windows.Forms.TextBox();
            this.rpm1Box = new System.Windows.Forms.TextBox();
            this.rpm2Box = new System.Windows.Forms.TextBox();
            this.rpm3Box = new System.Windows.Forms.TextBox();
            this.rpm4Box = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.voltBox = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.PFD = new ZedGraph.ZedGraphControl();
            this.connectButton = new System.Windows.Forms.Button();
            this.comPortBox = new System.Windows.Forms.TextBox();
            this.serialOutput = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.pwmMotor4Bar = new Telemetry.VerticalProgressBar();
            this.pwmMotor3Bar = new Telemetry.VerticalProgressBar();
            this.pwmMotor2Bar = new Telemetry.VerticalProgressBar();
            this.pwmMotor1Bar = new Telemetry.VerticalProgressBar();
            this.datalog = new byte[32];
            this.commandBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.joystickTimer = new System.Windows.Forms.Timer(this.components);
            this.sendCommand = new System.Windows.Forms.Timer(this.components);
            this.SerialConnectButton = new System.Windows.Forms.Button();
            this.fileDirectory = new System.Windows.Forms.TextBox();
            this.responsivenessLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // motorData
            // 
            this.motorData.BackColor = System.Drawing.Color.Lime;
            this.motorData.Location = new System.Drawing.Point(1087, 21);
            this.motorData.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.motorData.Name = "motorData";
            this.motorData.ScrollGrace = 0D;
            this.motorData.ScrollMaxX = 0D;
            this.motorData.ScrollMaxY = 0D;
            this.motorData.ScrollMaxY2 = 0D;
            this.motorData.ScrollMinX = 0D;
            this.motorData.ScrollMinY = 0D;
            this.motorData.ScrollMinY2 = 0D;
            this.motorData.Size = new System.Drawing.Size(769, 479);
            this.motorData.TabIndex = 0;
            // 
            // updateTimer
            // 
            this.updateTimer.Enabled = true;
            this.updateTimer.Interval = 50;
            this.updateTimer.Tick += new System.EventHandler(this.updateTimer_Tick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Lime;
            this.label2.Location = new System.Drawing.Point(1871, 213);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "PWM1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Lime;
            this.label3.Location = new System.Drawing.Point(1950, 213);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "PWM2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1871, 475);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 25);
            this.label4.TabIndex = 9;
            this.label4.Text = "PWM3";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1950, 475);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 25);
            this.label5.TabIndex = 11;
            this.label5.Text = "PWM4";
            // 
            // pwm1Box
            // 
            this.pwm1Box.BackColor = System.Drawing.SystemColors.InfoText;
            this.pwm1Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pwm1Box.Location = new System.Drawing.Point(17, 1225);
            this.pwm1Box.Name = "pwm1Box";
            this.pwm1Box.Size = new System.Drawing.Size(100, 31);
            this.pwm1Box.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 1197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 25);
            this.label7.TabIndex = 14;
            this.label7.Text = "PWM1";
            // 
            // pwm2Box
            // 
            this.pwm2Box.BackColor = System.Drawing.SystemColors.InfoText;
            this.pwm2Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pwm2Box.Location = new System.Drawing.Point(123, 1225);
            this.pwm2Box.Name = "pwm2Box";
            this.pwm2Box.Size = new System.Drawing.Size(100, 31);
            this.pwm2Box.TabIndex = 15;
            // 
            // pwm3Box
            // 
            this.pwm3Box.BackColor = System.Drawing.SystemColors.InfoText;
            this.pwm3Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pwm3Box.Location = new System.Drawing.Point(229, 1225);
            this.pwm3Box.Name = "pwm3Box";
            this.pwm3Box.Size = new System.Drawing.Size(100, 31);
            this.pwm3Box.TabIndex = 16;
            // 
            // pwm4Box
            // 
            this.pwm4Box.BackColor = System.Drawing.SystemColors.InfoText;
            this.pwm4Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pwm4Box.Location = new System.Drawing.Point(335, 1225);
            this.pwm4Box.Name = "pwm4Box";
            this.pwm4Box.Size = new System.Drawing.Size(100, 31);
            this.pwm4Box.TabIndex = 17;
            // 
            // hdgBox
            // 
            this.hdgBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.hdgBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.hdgBox.Location = new System.Drawing.Point(441, 1225);
            this.hdgBox.Name = "hdgBox";
            this.hdgBox.Size = new System.Drawing.Size(100, 31);
            this.hdgBox.TabIndex = 18;
            // 
            // rollBox
            // 
            this.rollBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.rollBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.rollBox.Location = new System.Drawing.Point(547, 1225);
            this.rollBox.Name = "rollBox";
            this.rollBox.Size = new System.Drawing.Size(100, 31);
            this.rollBox.TabIndex = 19;
            // 
            // pitchBox
            // 
            this.pitchBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.pitchBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pitchBox.Location = new System.Drawing.Point(653, 1225);
            this.pitchBox.Name = "pitchBox";
            this.pitchBox.Size = new System.Drawing.Size(100, 31);
            this.pitchBox.TabIndex = 20;
            // 
            // xAccelBox
            // 
            this.xAccelBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.xAccelBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.xAccelBox.Location = new System.Drawing.Point(759, 1225);
            this.xAccelBox.Name = "xAccelBox";
            this.xAccelBox.Size = new System.Drawing.Size(100, 31);
            this.xAccelBox.TabIndex = 21;
            // 
            // yAccelBox
            // 
            this.yAccelBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.yAccelBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.yAccelBox.Location = new System.Drawing.Point(868, 1225);
            this.yAccelBox.Name = "yAccelBox";
            this.yAccelBox.Size = new System.Drawing.Size(100, 31);
            this.yAccelBox.TabIndex = 22;
            // 
            // zAccelBox
            // 
            this.zAccelBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.zAccelBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.zAccelBox.Location = new System.Drawing.Point(974, 1225);
            this.zAccelBox.Name = "zAccelBox";
            this.zAccelBox.Size = new System.Drawing.Size(100, 31);
            this.zAccelBox.TabIndex = 23;
            // 
            // altBox
            // 
            this.altBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.altBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.altBox.Location = new System.Drawing.Point(1080, 1225);
            this.altBox.Name = "altBox";
            this.altBox.Size = new System.Drawing.Size(100, 31);
            this.altBox.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(118, 1197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 25);
            this.label8.TabIndex = 25;
            this.label8.Text = "PWM2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(224, 1197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 25);
            this.label9.TabIndex = 26;
            this.label9.Text = "PWM3";
            // 
            // temp1Box
            // 
            this.temp1Box.BackColor = System.Drawing.SystemColors.InfoText;
            this.temp1Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.temp1Box.Location = new System.Drawing.Point(1610, 1225);
            this.temp1Box.Name = "temp1Box";
            this.temp1Box.Size = new System.Drawing.Size(100, 31);
            this.temp1Box.TabIndex = 27;
            // 
            // rpm1Box
            // 
            this.rpm1Box.BackColor = System.Drawing.SystemColors.InfoText;
            this.rpm1Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.rpm1Box.Location = new System.Drawing.Point(1186, 1225);
            this.rpm1Box.Name = "rpm1Box";
            this.rpm1Box.Size = new System.Drawing.Size(100, 31);
            this.rpm1Box.TabIndex = 28;
            // 
            // rpm2Box
            // 
            this.rpm2Box.BackColor = System.Drawing.SystemColors.InfoText;
            this.rpm2Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.rpm2Box.Location = new System.Drawing.Point(1292, 1225);
            this.rpm2Box.Name = "rpm2Box";
            this.rpm2Box.Size = new System.Drawing.Size(100, 31);
            this.rpm2Box.TabIndex = 29;
            // 
            // rpm3Box
            // 
            this.rpm3Box.BackColor = System.Drawing.SystemColors.InfoText;
            this.rpm3Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.rpm3Box.Location = new System.Drawing.Point(1398, 1225);
            this.rpm3Box.Name = "rpm3Box";
            this.rpm3Box.Size = new System.Drawing.Size(100, 31);
            this.rpm3Box.TabIndex = 30;
            // 
            // rpm4Box
            // 
            this.rpm4Box.BackColor = System.Drawing.SystemColors.InfoText;
            this.rpm4Box.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.rpm4Box.Location = new System.Drawing.Point(1504, 1225);
            this.rpm4Box.Name = "rpm4Box";
            this.rpm4Box.Size = new System.Drawing.Size(100, 31);
            this.rpm4Box.TabIndex = 31;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(330, 1197);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 25);
            this.label10.TabIndex = 32;
            this.label10.Text = "PWM4";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(436, 1197);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(58, 25);
            this.label11.TabIndex = 33;
            this.label11.Text = "HDG";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(542, 1197);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(49, 25);
            this.label12.TabIndex = 34;
            this.label12.Text = "Roll";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(648, 1197);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 25);
            this.label13.TabIndex = 35;
            this.label13.Text = "Pitch";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(754, 1197);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(83, 25);
            this.label14.TabIndex = 36;
            this.label14.Text = "x-Accel";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(863, 1197);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(83, 25);
            this.label15.TabIndex = 37;
            this.label15.Text = "y-Accel";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(969, 1197);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(83, 25);
            this.label16.TabIndex = 38;
            this.label16.Text = "z-Accel";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(1075, 1197);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 25);
            this.label17.TabIndex = 39;
            this.label17.Text = "ALT";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(1181, 1197);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(71, 25);
            this.label18.TabIndex = 40;
            this.label18.Text = "RPM1";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(1287, 1197);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(71, 25);
            this.label19.TabIndex = 41;
            this.label19.Text = "RPM2";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(1393, 1197);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 25);
            this.label20.TabIndex = 42;
            this.label20.Text = "RPM3";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1499, 1197);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(71, 25);
            this.label21.TabIndex = 43;
            this.label21.Text = "RPM4";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(1605, 1197);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(69, 25);
            this.label22.TabIndex = 44;
            this.label22.Text = "TMP1";
            // 
            // voltBox
            // 
            this.voltBox.BackColor = System.Drawing.SystemColors.InfoText;
            this.voltBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.voltBox.Location = new System.Drawing.Point(1716, 1225);
            this.voltBox.Name = "voltBox";
            this.voltBox.Size = new System.Drawing.Size(100, 31);
            this.voltBox.TabIndex = 45;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(1718, 1197);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(85, 25);
            this.label23.TabIndex = 46;
            this.label23.Text = "Voltage";
            // 
            // PFD
            // 
            this.PFD.Location = new System.Drawing.Point(32, 21);
            this.PFD.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.PFD.Name = "PFD";
            this.PFD.ScrollGrace = 0D;
            this.PFD.ScrollMaxX = 0D;
            this.PFD.ScrollMaxY = 0D;
            this.PFD.ScrollMaxY2 = 0D;
            this.PFD.ScrollMinX = 0D;
            this.PFD.ScrollMinY = 0D;
            this.PFD.ScrollMinY2 = 0D;
            this.PFD.Size = new System.Drawing.Size(1020, 753);
            this.PFD.TabIndex = 47;
            // 
            // connectButton
            // 
            this.connectButton.ForeColor = System.Drawing.Color.Black;
            this.connectButton.Location = new System.Drawing.Point(1087, 559);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(114, 47);
            this.connectButton.TabIndex = 48;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // comPortBox
            // 
            this.comPortBox.Location = new System.Drawing.Point(1224, 567);
            this.comPortBox.Name = "comPortBox";
            this.comPortBox.Size = new System.Drawing.Size(217, 31);
            this.comPortBox.TabIndex = 49;
            // 
            // serialOutput
            // 
            this.serialOutput.AutoSize = true;
            this.serialOutput.Location = new System.Drawing.Point(1224, 643);
            this.serialOutput.Name = "serialOutput";
            this.serialOutput.Size = new System.Drawing.Size(232, 25);
            this.serialOutput.TabIndex = 50;
            this.serialOutput.Text = "Data is displayed here!";
            // 
            // button3
            // 
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(1088, 632);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 38);
            this.button3.TabIndex = 53;
            this.button3.Text = "Disconnect";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // pwmMotor4Bar
            // 
            this.pwmMotor4Bar.Location = new System.Drawing.Point(1955, 283);
            this.pwmMotor4Bar.Maximum = 114;
            this.pwmMotor4Bar.Minimum = 62;
            this.pwmMotor4Bar.Name = "pwmMotor4Bar";
            this.pwmMotor4Bar.Size = new System.Drawing.Size(52, 189);
            this.pwmMotor4Bar.TabIndex = 10;
            this.pwmMotor4Bar.Value = 62;
            // 
            // pwmMotor3Bar
            // 
            this.pwmMotor3Bar.Location = new System.Drawing.Point(1876, 283);
            this.pwmMotor3Bar.Maximum = 114;
            this.pwmMotor3Bar.Minimum = 62;
            this.pwmMotor3Bar.Name = "pwmMotor3Bar";
            this.pwmMotor3Bar.Size = new System.Drawing.Size(52, 189);
            this.pwmMotor3Bar.TabIndex = 8;
            this.pwmMotor3Bar.Value = 62;
            // 
            // pwmMotor2Bar
            // 
            this.pwmMotor2Bar.Location = new System.Drawing.Point(1955, 21);
            this.pwmMotor2Bar.Maximum = 114;
            this.pwmMotor2Bar.Minimum = 62;
            this.pwmMotor2Bar.Name = "pwmMotor2Bar";
            this.pwmMotor2Bar.Size = new System.Drawing.Size(52, 189);
            this.pwmMotor2Bar.TabIndex = 6;
            this.pwmMotor2Bar.Value = 62;
            // 
            // pwmMotor1Bar
            // 
            this.pwmMotor1Bar.Location = new System.Drawing.Point(1876, 21);
            this.pwmMotor1Bar.Maximum = 114;
            this.pwmMotor1Bar.Minimum = 62;
            this.pwmMotor1Bar.Name = "pwmMotor1Bar";
            this.pwmMotor1Bar.Size = new System.Drawing.Size(52, 189);
            this.pwmMotor1Bar.TabIndex = 4;
            this.pwmMotor1Bar.Value = 62;
            // 
            // commandBox
            // 
            this.commandBox.Location = new System.Drawing.Point(12, 623);
            this.commandBox.Name = "commandBox";
            this.commandBox.Size = new System.Drawing.Size(906, 31);
            this.commandBox.TabIndex = 3;
            // 
            // sendButton
            // 
            this.sendButton.Location = new System.Drawing.Point(924, 619);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(116, 38);
            this.sendButton.TabIndex = 4;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // joystickTimer
            // 
            this.joystickTimer.Interval = 20;
            this.joystickTimer.Tick += new System.EventHandler(this.joystickTimer_Tick);
            // 
            // sendCommand
            // 
            this.sendCommand.Interval = 35;
            this.sendCommand.Tick += new System.EventHandler(this.sendCommand_Tick);
            // 
            // SerialConnectButton
            // 
            this.SerialConnectButton.Location = new System.Drawing.Point(0, 0);
            this.SerialConnectButton.Name = "SerialConnectButton";
            this.SerialConnectButton.Size = new System.Drawing.Size(75, 23);
            this.SerialConnectButton.TabIndex = 0;
            // 
            // fileDirectory
            // 
            this.fileDirectory.Location = new System.Drawing.Point(591, 669);
            this.fileDirectory.Name = "fileDirectory";
            this.fileDirectory.Size = new System.Drawing.Size(327, 31);
            this.fileDirectory.TabIndex = 9;
            this.fileDirectory.Text = "C:\\\\QuadTemp\\\\Serial.txt";
            // 
            // responsivenessLabel
            // 
            this.responsivenessLabel.AutoSize = true;
            this.responsivenessLabel.Location = new System.Drawing.Point(12, 729);
            this.responsivenessLabel.Name = "responsivenessLabel";
            this.responsivenessLabel.Size = new System.Drawing.Size(177, 25);
            this.responsivenessLabel.TabIndex = 11;
            this.responsivenessLabel.Text = "Responsiveness:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1481, 497);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 25);
            this.label6.TabIndex = 12;
            this.label6.Text = "t(sec)";
            // 
            // telemetryWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(2396, 1268);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.serialOutput);
            this.Controls.Add(this.comPortBox);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.PFD);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.voltBox);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.rpm4Box);
            this.Controls.Add(this.rpm3Box);
            this.Controls.Add(this.rpm2Box);
            this.Controls.Add(this.rpm1Box);
            this.Controls.Add(this.temp1Box);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.altBox);
            this.Controls.Add(this.zAccelBox);
            this.Controls.Add(this.yAccelBox);
            this.Controls.Add(this.xAccelBox);
            this.Controls.Add(this.pitchBox);
            this.Controls.Add(this.rollBox);
            this.Controls.Add(this.hdgBox);
            this.Controls.Add(this.pwm4Box);
            this.Controls.Add(this.pwm3Box);
            this.Controls.Add(this.pwm2Box);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pwm1Box);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pwmMotor4Bar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pwmMotor3Bar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pwmMotor2Bar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pwmMotor1Bar);
            this.Controls.Add(this.motorData);
            this.ForeColor = System.Drawing.Color.LawnGreen;
            this.Name = "telemetryWindow";
            this.Text = "Telemetry";
            this.Load += new System.EventHandler(this.telemetryWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ZedGraph.ZedGraphControl motorData;
        public System.Windows.Forms.Timer updateTimer;
        private VerticalProgressBar pwmMotor1Bar;
        private System.Windows.Forms.Label label2;
        private VerticalProgressBar pwmMotor2Bar;
        private System.Windows.Forms.Label label3;
        private VerticalProgressBar pwmMotor3Bar;
        private System.Windows.Forms.Label label4;
        private VerticalProgressBar pwmMotor4Bar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox pwm1Box;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox pwm2Box;
        private System.Windows.Forms.TextBox pwm3Box;
        private System.Windows.Forms.TextBox pwm4Box;
        private System.Windows.Forms.TextBox hdgBox;
        private System.Windows.Forms.TextBox rollBox;
        private System.Windows.Forms.TextBox pitchBox;
        private System.Windows.Forms.TextBox xAccelBox;
        private System.Windows.Forms.TextBox yAccelBox;
        private System.Windows.Forms.TextBox zAccelBox;
        private System.Windows.Forms.TextBox altBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox temp1Box;
        private System.Windows.Forms.TextBox rpm1Box;
        private System.Windows.Forms.TextBox rpm2Box;
        private System.Windows.Forms.TextBox rpm3Box;
        private System.Windows.Forms.TextBox rpm4Box;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox voltBox;
        private System.Windows.Forms.Label label23;
        private ZedGraph.ZedGraphControl PFD;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.TextBox comPortBox;
        private System.Windows.Forms.Label serialOutput;
        private System.Windows.Forms.Button button3;


        ///OTHER VARIABLES!!!

        byte[] datalog;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Timer joystickTimer;
        private System.Windows.Forms.Timer sendCommand;
        //private System.Windows.Forms.TextBox ComPortBox;
        private System.Windows.Forms.Button SerialConnectButton;
        private System.Windows.Forms.TextBox fileDirectory;
        private System.Windows.Forms.Label responsivenessLabel;
        private System.Windows.Forms.Label label6;
    }
}

