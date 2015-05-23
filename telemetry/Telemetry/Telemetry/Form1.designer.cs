namespace Telemetry
{
    partial class Form1
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
            this.datalog = new System.Windows.Forms.RichTextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.commandBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.joystickTimer = new System.Windows.Forms.Timer(this.components);
            this.sendCommand = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.ComPortBox = new System.Windows.Forms.TextBox();
            this.SerialConnectButton = new System.Windows.Forms.Button();
            this.fileDirectory = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.responsivenessLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // datalog
            // 
            this.datalog.Location = new System.Drawing.Point(12, 12);
            this.datalog.MaxLength = 10000000;
            this.datalog.Name = "datalog";
            this.datalog.ReadOnly = true;
            this.datalog.Size = new System.Drawing.Size(1028, 597);
            this.datalog.TabIndex = 0;
            this.datalog.Text = "";
            this.datalog.TextChanged += new System.EventHandler(this.datalog_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 50;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 672);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(228, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Connect to Serial Port:";
            // 
            // ComPortBox
            // 
            this.ComPortBox.Location = new System.Drawing.Point(246, 669);
            this.ComPortBox.Name = "ComPortBox";
            this.ComPortBox.Size = new System.Drawing.Size(100, 31);
            this.ComPortBox.TabIndex = 7;
            this.ComPortBox.Text = "COM4";
            // 
            // SerialConnectButton
            // 
            this.SerialConnectButton.Location = new System.Drawing.Point(924, 669);
            this.SerialConnectButton.Name = "SerialConnectButton";
            this.SerialConnectButton.Size = new System.Drawing.Size(116, 42);
            this.SerialConnectButton.TabIndex = 8;
            this.SerialConnectButton.Text = "Connect";
            this.SerialConnectButton.UseVisualStyleBackColor = true;
            this.SerialConnectButton.Click += new System.EventHandler(this.SerialConnectButton_Click);
            // 
            // fileDirectory
            // 
            this.fileDirectory.Location = new System.Drawing.Point(591, 669);
            this.fileDirectory.Name = "fileDirectory";
            this.fileDirectory.Size = new System.Drawing.Size(327, 31);
            this.fileDirectory.TabIndex = 9;
            this.fileDirectory.Text = "C:\\\\QuadTemp\\\\Serial.txt";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(459, 672);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(126, 25);
            this.label2.TabIndex = 10;
            this.label2.Text = "Write to file:";
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
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Crimson;
            this.label3.Location = new System.Drawing.Point(459, 729);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(465, 50);
            this.label3.TabIndex = 12;
            this.label3.Text = "Default: 6500. The lower, the more responsive. \r\nDO NOT go below 2621 or over 800" +
                "0!";
            // 
            // Form1
            // 
            this.AcceptButton = this.sendButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1052, 793);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.responsivenessLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.fileDirectory);
            this.Controls.Add(this.SerialConnectButton);
            this.Controls.Add(this.ComPortBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.commandBox);
            this.Controls.Add(this.datalog);
            this.Name = "Form1";
            this.Text = "Arduino Communication";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox datalog;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox commandBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.Timer joystickTimer;
        private System.Windows.Forms.Timer sendCommand;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ComPortBox;
        private System.Windows.Forms.Button SerialConnectButton;
        private System.Windows.Forms.TextBox fileDirectory;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label responsivenessLabel;
        private System.Windows.Forms.Label label3;
    }
}

