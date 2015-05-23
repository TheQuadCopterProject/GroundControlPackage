using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Telemetry
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new telemetryWindow());
        }
    }


    public class VerticalProgressBar : ProgressBar { 
        protected override CreateParams CreateParams { 
            get { 
            CreateParams cp = base.CreateParams; 
            cp.Style |= 0x04; 
            return cp; 
                } 
            } 
        }


}
