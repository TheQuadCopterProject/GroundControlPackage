using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Globalization;
using ZedGraph;
using System.Management;

namespace Telemetry
{
    public partial class telemetryWindow : Form
    {
        #region variables
        string[] serialValues;
        double currentTime = 0;
        Form1 serialData = new Form1();

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
            
            readValues();
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
            updateTimer.Start();
        }

        private void readValues()
        {
            try
            {
                using (StreamReader reader = new StreamReader(pathBox.Text))
                {
                    string indata = reader.ReadLine();
                    serialValues = indata.Split(' ');

                    reader.Close();
                }

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

                pwm1Box.Text = serialValues[0];
                pwm2Box.Text = serialValues[1];
                pwm3Box.Text = serialValues[2];
                pwm4Box.Text = serialValues[3];
                xAccelBox.Text = serialValues[4];
                yAccelBox.Text = serialValues[5];
                zAccelBox.Text = serialValues[6];
                rollBox.Text = serialValues[7];
                pitchBox.Text = serialValues[8];
                hdgBox.Text = serialValues[9];
                altBox.Text = serialValues[11];
                temp1Box.Text = serialValues[12];
                voltBox.Text = serialValues[13];

                

                /*hdgBox.Text = serialValues[6];
                rollBox.Text = serialValues[4];
                pitchBox.Text = serialValues[5];
                //xAccelBox.Text = serialValues[5];
                //yAccelBox.Text = serialValues[6];
                //zAccelBox.Text = serialValues[7];
                altBox.Text = serialValues[8];
                //rpm1Box.Text = serialValues[14];
                //rpm2Box.Text = serialValues[15];
                //rpm3Box.Text = serialValues[16];
                //rpm4Box.Text = serialValues[17];
                temp1Box.Text = serialValues[9];*/
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
            serialData.SerialConnectButton_Click(sender, e, comPortBox.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            serialData.disconnect();
        }
    }
}
