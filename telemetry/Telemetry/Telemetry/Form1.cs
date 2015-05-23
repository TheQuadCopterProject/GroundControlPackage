using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.Threading;
using System.Diagnostics;
using System.IO;
using System.Management;

namespace Telemetry
{
    public partial class Form1 : Form
    {
        SerialPort mySerialPort;
        string indata;
        string dataToWrite;
        int m1ToWrite;
        int m2ToWrite;
        int m3ToWrite;
        int m4ToWrite;
        int responsiveness = 6500; //responsiveness factor: the lower, the more responsive. Do not go below 2621 or over 8000. Default: 6553
        string messageToSend;
        int flightMode = 0; //0:cutoff  1:flight  2:slow shutdown

        private Joystick joystick;
        private bool[] joystickButtons;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                joystick = new Joystick(this.Handle);
                connectToJoystick(joystick);
            }
            catch
            {
                MessageBox.Show("No Joystick! Please restart after connecting.");
            }
            
        }

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            SerialPort sp = (SerialPort)sender;
            indata = sp.ReadExisting();
            datalog.Text += indata;
        }

        private void datalog_TextChanged(object sender, EventArgs e)
        {
            datalog.SelectionStart = datalog.Text.Length; //Set the current caret position at the end
            datalog.ScrollToCaret(); //Now scroll it automatically
            
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            //datalog.Text = alldata;
            try
            {
                using (StreamWriter writer = new StreamWriter(fileDirectory.Text))
                {
                    int numberOfLines = datalog.Lines.Length;
                    dataToWrite = datalog.Lines[numberOfLines - 2];
                    writer.Write(dataToWrite);

                    writer.Close();
                }
            }
            catch
            {

            }

            if (datalog.Lines.Length > 50)
            {
                datalog.Select(0,commandBox.GetFirstCharIndexFromLine(datalog.Lines.Length-50));
                datalog.SelectedText = "";
            }

            timer1.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                mySerialPort.Write(commandBox.Text);
                commandBox.Text = "";
            }
            catch
            {

            }
        }

        private void connectToJoystick(Joystick joystick)
        {
            while (true)
            {
                string sticks = joystick.FindJoysticks();
                if (sticks != null)
                {
                    if (joystick.AcquireJoystick(sticks))
                    {
                        enableTimer();
                        break;
                    }
                }
            }
        }

        private void joystickTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                joystick.UpdateStatus();
                joystickButtons = joystick.buttons;

                # region decideAction
                if (flightMode == 2)
                {
                    m1ToWrite = 0;
                    m2ToWrite = 0;
                    m3ToWrite = 0;
                    m4ToWrite = 0;
                }

                if (flightMode == 1)
                {
                    #region calculate
                    m1ToWrite = (((joystick.Zaxis - 65535) * -1) / 1260) + 62;
                    m1ToWrite = m1ToWrite + ((joystick.Xaxis - 32768) / responsiveness);
                    m1ToWrite = m1ToWrite + ((joystick.Yaxis - 32768) / responsiveness);
                    m1ToWrite = m1ToWrite + ((joystick.Rotation - 32768) / responsiveness / 2);

                    m2ToWrite = (((joystick.Zaxis - 65535) * -1) / 1260) + 62;
                    m2ToWrite = m2ToWrite + ((joystick.Xaxis - 32768) * -1 / responsiveness);
                    m2ToWrite = m2ToWrite + ((joystick.Yaxis - 32768) / responsiveness);
                    m2ToWrite = m2ToWrite + ((joystick.Rotation - 32768) * -1 / responsiveness / 2);

                    m3ToWrite = (((joystick.Zaxis - 65535) * -1) / 1260) + 62;
                    m3ToWrite = m3ToWrite + ((joystick.Xaxis - 32768) / responsiveness);
                    m3ToWrite = m3ToWrite + ((joystick.Yaxis - 32768) * -1 / responsiveness);
                    m3ToWrite = m3ToWrite + ((joystick.Rotation - 32768) * -1 / responsiveness / 2);

                    m4ToWrite = (((joystick.Zaxis - 65535) * -1) / 1260) + 62;
                    m4ToWrite = m4ToWrite + ((joystick.Xaxis - 32768) * -1 / responsiveness);
                    m4ToWrite = m4ToWrite + ((joystick.Yaxis - 32768) * -1 / responsiveness);
                    m4ToWrite = m4ToWrite + ((joystick.Rotation - 32768) / responsiveness / 2);
                    #endregion
                }
                if (flightMode == 0)
                {
                    m1ToWrite = 40;
                    m2ToWrite = 40;
                    m3ToWrite = 40;
                    m4ToWrite = 40;
                }
                #endregion

                #region get Buttons
                for (int i = 0; i < joystickButtons.Length; i++)
                {
                    if (joystickButtons[i] == true)
                    {
                        if (i == 3)
                        {
                            flightMode = 2;
                            m1ToWrite = 0;
                            m2ToWrite = 0;
                            m3ToWrite = 0;
                            m4ToWrite = 0;

                        }
                        if (i == 2)
                        {
                            flightMode = 0;
                            m1ToWrite = 40;
                            m2ToWrite = 40;
                            m3ToWrite = 40;
                            m4ToWrite = 40;
                        }

                        if (i == 0)
                        {
                            flightMode = 1;
                        }

                        if (i == 5)
                        {
                            responsiveness = responsiveness - 100;
                        }

                        if (i == 6)
                        {
                            responsiveness = responsiveness + 100;
                        }
                    }
                }
                #endregion

                messageToSend = m1ToWrite.ToString() + " " + m2ToWrite.ToString() + " " + m3ToWrite.ToString() + " " + m4ToWrite.ToString();

                telemetryWindow.setOutput (messageToSend);

                responsivenessLabel.Text = "Responsiveness: " + responsiveness.ToString();
            }
            catch
            {
                joystickTimer.Enabled = false;
                connectToJoystick(joystick);
            }
        }

        private void enableTimer()
        {
            if (this.InvokeRequired)
            {
                BeginInvoke(new ThreadStart(delegate()
                {
                    joystickTimer.Enabled = true;
                }));
            }
            else
                joystickTimer.Enabled = true;
        }

        private void sendCommand_Tick(object sender, EventArgs e)
        {
            try
            {
                mySerialPort.Write(messageToSend);
            }
            catch
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        public void SerialConnectButton_Click(object sender, EventArgs e, string port)
        {
            try
            {
                mySerialPort = new SerialPort(port);
                timer1.Interval = 50;
                timer1.Enabled = true;

                mySerialPort.BaudRate = 115200;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;

                mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                mySerialPort.Open();

                ComPortBox.ReadOnly = true;
                fileDirectory.ReadOnly = true;
                SerialConnectButton.Enabled = false;

                sendCommand.Enabled = true;
                sendCommand.Start();
            }
            catch
            {

            }
        }

        internal void disconnect()
        {
            mySerialPort.Close();
        }
    }
}