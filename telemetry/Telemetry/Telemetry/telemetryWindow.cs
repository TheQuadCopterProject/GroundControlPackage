using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using System.Globalization;
using ZedGraph;
using System.Threading;
using System.Diagnostics;
using System.Management;

namespace Telemetry
{
    public partial class telemetryWindow : Form
    {
        #region variables
        string[] serialValues;
        double currentTime = 0;

        PointPairList pwmMotor1 = new PointPairList();
        PointPairList pwmMotor2 = new PointPairList();
        PointPairList pwmMotor3 = new PointPairList();
        PointPairList pwmMotor4 = new PointPairList();

        PointPairList pwmMotorUpperLimit = new PointPairList();
        PointPairList pwmMotorLowerLimit = new PointPairList();

        PointPairList PFD1Marker = new PointPairList();
        PointPairList PFDm1Marker = new PointPairList();
        PointPairList PFD10Marker = new PointPairList();
        PointPairList PFD20Marker = new PointPairList();
        PointPairList PFD30Marker = new PointPairList();
        PointPairList PFD40Marker = new PointPairList();
        PointPairList PFD50Marker = new PointPairList();
        PointPairList PFD60Marker = new PointPairList();
        PointPairList PFD70Marker = new PointPairList();
        PointPairList PFD80Marker = new PointPairList();
        PointPairList PFD90Marker = new PointPairList();
        PointPairList PFDm10Marker = new PointPairList();
        PointPairList PFDm20Marker = new PointPairList();
        PointPairList PFDm30Marker = new PointPairList();
        PointPairList PFDm40Marker = new PointPairList();
        PointPairList PFDm50Marker = new PointPairList();
        PointPairList PFDm60Marker = new PointPairList();
        PointPairList PFDm70Marker = new PointPairList();
        PointPairList PFDm80Marker = new PointPairList();
        PointPairList PFDm90Marker = new PointPairList();

        PointPairList centerLineHorizontal = new PointPairList();
        PointPairList centerLineVertical = new PointPairList();

        double angleAlpha;
        double angleBeta;
        double angleGamma = 90;
        double aMarkerOffset;
        double bMarkerOffset;

        #endregion

        public telemetryWindow()
        {
            InitializeComponent();
        }

        private void telemetryWindow_Load(object sender, EventArgs e)
        {
            loadMotorData();
            loadPFD();
            updateTimer.Enabled = false;

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

        private void loadMotorData()
        {
            motorData.GraphPane.Chart.Fill = new Fill(System.Drawing.Color.Black);
            motorData.GraphPane.Fill = new Fill(System.Drawing.Color.Black);
            motorData.GraphPane.Title.FontSpec.FontColor = System.Drawing.Color.Lime;
            motorData.GraphPane.XAxis.Title.FontSpec.FontColor = System.Drawing.Color.Lime;
            motorData.GraphPane.YAxis.Title.FontSpec.FontColor = System.Drawing.Color.Lime;
            motorData.GraphPane.Chart.Border.Color = System.Drawing.Color.Lime;
            motorData.GraphPane.Legend.FontSpec.FontColor = System.Drawing.Color.Lime;
            motorData.GraphPane.Legend.Fill = new Fill(System.Drawing.Color.Black);
            motorData.GraphPane.Title.Text = "Motor PWM";
            motorData.GraphPane.YAxis.Title.Text = "PWM value";
            motorData.GraphPane.XAxis.Title.Text = "Time";
            motorData.GraphPane.XAxis.Color = System.Drawing.Color.Lime;
            motorData.GraphPane.XAxis.MajorTic.Color = System.Drawing.Color.Lime;
            motorData.GraphPane.YAxis.MajorGrid.Color = System.Drawing.Color.Lime;
            motorData.GraphPane.XAxis.MinorTic.Color = System.Drawing.Color.Lime;
            motorData.GraphPane.YAxis.MinorTic.Color = System.Drawing.Color.Lime;
            motorData.GraphPane.YAxis.MinorGrid.Color = System.Drawing.Color.Lime;
            motorData.GraphPane.YAxis.MajorTic.Color = System.Drawing.Color.Lime;
            motorData.GraphPane.XAxis.Scale.FontSpec.FontColor = System.Drawing.Color.Lime;
            motorData.GraphPane.YAxis.Scale.FontSpec.FontColor = System.Drawing.Color.Lime;
            motorData.GraphPane.YAxis.Scale.Max = 114;
            motorData.GraphPane.YAxis.Scale.Min = 62;
            motorData.GraphPane.XAxis.Scale.MajorStep = 5;
            motorData.GraphPane.YAxis.Scale.MajorStep = 10;
            
            pwmMotorUpperLimit.Add(0, 114);
            pwmMotorUpperLimit.Add(400, 114);

            pwmMotorLowerLimit.Add(0, 62);
            pwmMotorLowerLimit.Add(400, 62);

            LineItem pwmMotorUpperLimitLine = motorData.GraphPane.AddCurve("Upper Limit", pwmMotorUpperLimit, Color.White, SymbolType.None);

            LineItem pwmMotorLowerLimitLine = motorData.GraphPane.AddCurve("Lower Limit", pwmMotorLowerLimit, Color.White, SymbolType.None);

            LineItem pwmMotor1Line = motorData.GraphPane.AddCurve("Motor 1", pwmMotor1, System.Drawing.Color.Red, SymbolType.None);
            LineItem pwmMotor2Line = motorData.GraphPane.AddCurve("Motor 2", pwmMotor2, System.Drawing.Color.Blue, SymbolType.None);
            LineItem pwmMotor3Line = motorData.GraphPane.AddCurve("Motor 3", pwmMotor3, System.Drawing.Color.Yellow, SymbolType.None);
            LineItem pwmMotor4Line = motorData.GraphPane.AddCurve("Motor 4", pwmMotor4, System.Drawing.Color.Purple, SymbolType.None);
        }

        private void loadPFD()
        {
            try
            {

            PFD.GraphPane.CurveList.Clear();
            PFD.GraphPane.GraphObjList.Clear();
            PFD.GraphPane.Chart.Fill = new Fill(System.Drawing.Color.Black);
            PFD.GraphPane.Fill = new Fill(System.Drawing.Color.Black);
            PFD.GraphPane.Title.FontSpec.FontColor = System.Drawing.Color.Lime;
            PFD.GraphPane.XAxis.Title.FontSpec.FontColor = System.Drawing.Color.Lime;
            PFD.GraphPane.YAxis.Title.FontSpec.FontColor = System.Drawing.Color.Lime;
            PFD.GraphPane.Chart.Border.Color = System.Drawing.Color.Lime;
            PFD.GraphPane.Legend.FontSpec.FontColor = System.Drawing.Color.Lime;
            PFD.GraphPane.Legend.Fill = new Fill(System.Drawing.Color.Black);
            PFD.GraphPane.Title.Text = "Primary Flight Display";
            PFD.GraphPane.YAxis.Title.Text = "";
            PFD.GraphPane.XAxis.Title.Text = "";
            PFD.GraphPane.XAxis.Color = System.Drawing.Color.Lime;
            PFD.GraphPane.XAxis.MajorTic.Color = System.Drawing.Color.Lime;
            PFD.GraphPane.YAxis.MajorGrid.Color = System.Drawing.Color.Lime;
            PFD.GraphPane.XAxis.MinorTic.Color = System.Drawing.Color.Lime;
            PFD.GraphPane.YAxis.MinorTic.Color = System.Drawing.Color.Lime;
            PFD.GraphPane.YAxis.MinorGrid.Color = System.Drawing.Color.Lime;
            PFD.GraphPane.YAxis.MajorTic.Color = System.Drawing.Color.Lime;
            PFD.GraphPane.XAxis.Scale.FontSpec.FontColor = System.Drawing.Color.Lime;
            PFD.GraphPane.YAxis.Scale.FontSpec.FontColor = System.Drawing.Color.Lime;
            PFD.GraphPane.XAxis.Scale.Max = 45;
            PFD.GraphPane.XAxis.Scale.Min = -45;
            PFD.GraphPane.YAxis.Scale.Max = double.Parse(serialValues[8], CultureInfo.InvariantCulture.NumberFormat) + 45;
            PFD.GraphPane.YAxis.Scale.Min = double.Parse(serialValues[8], CultureInfo.InvariantCulture.NumberFormat) - 45;
            PFD.GraphPane.XAxis.Scale.MajorStep = 100;
            PFD.GraphPane.YAxis.Scale.MajorStep = 10;
            PFD.GraphPane.YAxis.Scale.MinorStep = 2.5;

            
                #region setMarkers
                angleAlpha = double.Parse(serialValues[7], CultureInfo.InvariantCulture.NumberFormat);
                angleBeta = 180 - angleAlpha - angleGamma;


                /* a/sin(angleAlpha) = 45/(angleGamma)
                 * 
                 * a = 45*sin(angleAlpha)/sin(angleBeta)
                 * 
                 * b/sin(angleBeta) = 45/sin(angleGamma)
                 * b = 45*sin(angleBeta)/sin(angleGamma)
                */

                aMarkerOffset = 45 * Math.Sin(angleAlpha * Math.PI / 180) / Math.Sin(angleBeta * Math.PI / 180);
                bMarkerOffset = 45 * Math.Sin(angleBeta * Math.PI / 180) / Math.Sin(angleGamma * Math.PI / 180);

                centerLineHorizontal.Clear();
                centerLineVertical.Clear();

                PFD1Marker.Clear();
                PFDm1Marker.Clear();

                PFD10Marker.Clear();
                PFD20Marker.Clear();
                PFD30Marker.Clear();
                PFD40Marker.Clear();
                PFD50Marker.Clear();
                PFD60Marker.Clear();
                PFD70Marker.Clear();
                PFD80Marker.Clear();
                PFD90Marker.Clear();

                PFDm10Marker.Clear();
                PFDm20Marker.Clear();
                PFDm30Marker.Clear();
                PFDm40Marker.Clear();
                PFDm50Marker.Clear();
                PFDm60Marker.Clear();
                PFDm70Marker.Clear();
                PFDm80Marker.Clear();
                PFDm90Marker.Clear();

                centerLineHorizontal.Add(-15, double.Parse(serialValues[8], CultureInfo.InvariantCulture.NumberFormat));
                centerLineHorizontal.Add(15, double.Parse(serialValues[8], CultureInfo.InvariantCulture.NumberFormat));

                centerLineVertical.Add(0, double.Parse(serialValues[8], CultureInfo.InvariantCulture.NumberFormat) + 15);
                centerLineVertical.Add(0, double.Parse(serialValues[8], CultureInfo.InvariantCulture.NumberFormat) - 15);

                PFD1Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset + 1);
                PFD1Marker.Add(bMarkerOffset, aMarkerOffset + 1);
                PFDm1Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset - 1);
                PFDm1Marker.Add(bMarkerOffset, aMarkerOffset - 1);
                PFD10Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset + 10);
                PFD10Marker.Add(bMarkerOffset, aMarkerOffset + 10);
                PFD20Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset + 20);
                PFD20Marker.Add(bMarkerOffset, aMarkerOffset + 20);
                PFD30Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset + 30);
                PFD30Marker.Add(bMarkerOffset, aMarkerOffset + 30);
                PFD40Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset + 40);
                PFD40Marker.Add(bMarkerOffset, aMarkerOffset + 40);
                PFD50Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset + 50);
                PFD50Marker.Add(bMarkerOffset, aMarkerOffset + 50);
                PFD60Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset + 60);
                PFD60Marker.Add(bMarkerOffset, aMarkerOffset + 60);
                PFD70Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset + 70);
                PFD70Marker.Add(bMarkerOffset, aMarkerOffset + 70);
                PFD80Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset + 80);
                PFD80Marker.Add(bMarkerOffset, aMarkerOffset + 80);
                PFD90Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset + 90);
                PFD90Marker.Add(bMarkerOffset, aMarkerOffset + 90);

                PFDm10Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset - 10);
                PFDm10Marker.Add(bMarkerOffset, aMarkerOffset - 10);
                PFDm20Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset - 20);
                PFDm20Marker.Add(bMarkerOffset, aMarkerOffset - 20);
                PFDm30Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset - 30);
                PFDm30Marker.Add(bMarkerOffset, aMarkerOffset - 30);
                PFDm40Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset - 40);
                PFDm40Marker.Add(bMarkerOffset, aMarkerOffset - 40);
                PFDm50Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset - 50);
                PFDm50Marker.Add(bMarkerOffset, aMarkerOffset - 50);
                PFDm60Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset - 60);
                PFDm60Marker.Add(bMarkerOffset, aMarkerOffset - 60);
                PFDm70Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset - 70);
                PFDm70Marker.Add(bMarkerOffset, aMarkerOffset - 70);
                PFDm80Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset - 80);
                PFDm80Marker.Add(bMarkerOffset, aMarkerOffset - 80);
                PFDm90Marker.Add(0 - bMarkerOffset, 0 - aMarkerOffset - 90);
                PFDm90Marker.Add(bMarkerOffset, aMarkerOffset - 90);

                #endregion
                #region drawMarkers
                PFD.GraphPane.AddCurve("", centerLineHorizontal, Color.Orange,SymbolType.None);
                PFD.GraphPane.AddCurve("", centerLineVertical, Color.Orange, SymbolType.None);
                
            PFD.GraphPane.AddCurve("", PFD1Marker, Color.Yellow, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFDm1Marker, Color.Yellow, SymbolType.None);

            PFD.GraphPane.AddCurve("", PFD10Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFD20Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFD30Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFD40Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFD50Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFD60Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFD70Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFD80Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFD90Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFDm10Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFDm20Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFDm30Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFDm40Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFDm50Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFDm60Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFDm70Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFDm80Marker, Color.White, SymbolType.None);
            PFD.GraphPane.AddCurve("", PFDm90Marker, Color.White, SymbolType.None);
            #endregion
            }
            catch
            {
            
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            Debug.Print("updateTimre_");
            readValues();
            try
            {
                motorData.Refresh();
                motorData.GraphPane.XAxis.Scale.Max = currentTime + 10;
                motorData.GraphPane.XAxis.Scale.Min = currentTime - 10;
                loadPFD();
                PFD.Refresh();

                currentTime = Math.Round(currentTime, 1);
                label6.Text = currentTime.ToString();
                currentTime = currentTime + 0.05f;

                pwmMotorUpperLimit.Add(currentTime + 35, 114);
                pwmMotorLowerLimit.Add(currentTime + 35, 62);
            }
            catch
            {

            }
        }

        private void readValues()
        {
            try
            {
                serialValues = new string[16];
                for (int i = 0; i < 16; ++i)
                {
                    byte[] vIncome = new byte[2];
                    vIncome[1] = datalog[i*2];
                    vIncome[0] = datalog[i * 2 + 1];
                    serialValues[i] = BitConverter.ToInt16(vIncome, 0).ToString();
                    Debug.Print("serialValue[" + i + "] = " + serialValues[i]);
                }
                serialOutput.Text = ConvertStringArrayToString (serialValues);
                try
                {
                    if (serialValues[7] == "0")
                    {
                        serialValues[7] = "0.01";
                    }
                }
                catch
                {

                }

                pwmMotorUpperLimit.Add(currentTime + 400, 114);
                pwmMotorLowerLimit.Add(currentTime + 400, 62);
                pwmMotor1.Add(currentTime, Convert.ToDouble(serialValues[0]));
                pwmMotor2.Add(currentTime, Convert.ToDouble(serialValues[1]));
                pwmMotor3.Add(currentTime, Convert.ToDouble(serialValues[2]));
                pwmMotor4.Add(currentTime, Convert.ToDouble(serialValues[3]));

                try
                {
                    pwmMotor1Bar.Value = Convert.ToInt32(serialValues[0]);
                    pwmMotor2Bar.Value = Convert.ToInt32(serialValues[1]);
                    pwmMotor3Bar.Value = Convert.ToInt32(serialValues[2]);
                    pwmMotor4Bar.Value = Convert.ToInt32(serialValues[3]);
                }
                catch
                {

                }

                pwm1Box.Text  = serialValues[0];
                pwm2Box.Text  = serialValues[1];
                pwm3Box.Text  = serialValues[2];
                pwm4Box.Text  = serialValues[3];
                xAccelBox.Text= serialValues[4];
                yAccelBox.Text= serialValues[5];
                zAccelBox.Text= serialValues[6];
                rollBox.Text  = serialValues[7];
                pitchBox.Text = serialValues[8];
                hdgBox.Text   = serialValues[9];
                rpm1Box.Text  = serialValues[10];
                rpm1Box.Text  = serialValues[11];
                rpm1Box.Text  = serialValues[12];
                rpm1Box.Text  = serialValues[13];
                voltBox.Text  = serialValues[14];
                altBox.Text   = serialValues[15];
            }
            catch
            {

            }
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            updateTimer.Enabled = true;
            updateTimer.Start();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            Debug.Print("connectButton_CLick");
            SerialConnectButton_Click(sender, e, comPortBox.Text);
            updateTimer.Enabled = true;
            updateTimer.Start();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            disconnect();
            updateTimer.Stop();
        }

        
        ///OTHER FILE!!!!!!!!!!!!!!!!!!!!!


        SerialPort mySerialPort;
        byte[] indata;
        int m1ToWrite;
        int m2ToWrite;
        int m3ToWrite;
        int m4ToWrite;
        int responsiveness = 6500; //responsiveness factor: the lower, the more responsive. Do not go below 2621 or over 8000. Default: 6553
        string messageToSend;
        int flightMode = 0; //0:cutoff  1:flight  2:slow shutdown

        private Joystick joystick;
        private bool[] joystickButtons;

        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            indata = Encoding.ASCII.GetBytes(mySerialPort.ReadExisting());
            for (int i = 0; i < indata.Length; ++i)
            {
                Debug.Write(indata[i] + ".");
            }
            Debug.Print("");
            mySerialPort.DiscardInBuffer();
            if (indata.Length > 66)
            {
                int index;
                for (index = indata.Length - 1; indata[index] != '\n'; --index) ;
                Debug.Print("index: " + index);
                int iD = 32;
                for (int i = index - 1; i >= index - 32; --i)
                {
                    --iD;
                    datalog[iD] = indata[i];
                }
                for (int i = 0; i < datalog.Length; ++i)
                {
                    Debug.Write(datalog[i]);
                }
                    Debug.Print("End of datalog");
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

                commandBox.Text = messageToSend;

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
                mySerialPort.BaudRate = 115200;
                mySerialPort.Parity = Parity.None;
                mySerialPort.StopBits = StopBits.One;
                mySerialPort.DataBits = 8;
                mySerialPort.Handshake = Handshake.None;
                mySerialPort.ReceivedBytesThreshold = 70;
                mySerialPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);

                mySerialPort.Open();
                //ComPortBox.ReadOnly = true;
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

        static string ConvertStringArrayToString(string[] array)
        {
            //
            // Concatenate all the elements into a StringBuilder.
            //
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
                builder.Append('.');
            }
            return builder.ToString();
        }

    }
}
