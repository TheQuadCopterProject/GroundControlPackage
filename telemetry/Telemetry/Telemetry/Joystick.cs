using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.DirectX.DirectInput;
using System.Windows.Forms;
using System;
using System.Diagnostics;

namespace Telemetry
{
    class Joystick
    {
        #region param

        private Device joystickDevice;
        private JoystickState state;
        public int Xaxis; // X-axis movement
        public int Yaxis; //Y-axis movement
        public int Zaxis;
        public int Rotation;
        private IntPtr hWnd;
        public bool[] buttons;
        private string systemJoysticks;

        #endregion

        public Joystick(IntPtr window_handle)
        {
            hWnd = window_handle;
            Xaxis = -1;
        }

        public string FindJoysticks()
        {
            systemJoysticks = null;
        //    Debug.Print("FindJoysticks");
            try
            {
                DeviceList gameControllerList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly);

                if (gameControllerList.Count > 0)
                {
                    foreach (DeviceInstance deviceInstance in gameControllerList)
                    {
                        joystickDevice = new Device(deviceInstance.InstanceGuid);
                        joystickDevice.SetCooperativeLevel(hWnd, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);

                        systemJoysticks = joystickDevice.DeviceInformation.InstanceName;

                        break;
                    }
                }
            }
            catch
            {
                return null;
            }

            return systemJoysticks;
        }

        public bool AcquireJoystick(string name)
        {
            try
            {
                DeviceList gameControllerList = Manager.GetDevices(DeviceClass.GameControl, EnumDevicesFlags.AttachedOnly);
                int i = 0;
                bool found = false;

                foreach (DeviceInstance deviceInstance in gameControllerList)
                {
                    if (deviceInstance.InstanceName == name)
                    {
                        found = true;
                        joystickDevice = new Device(deviceInstance.InstanceGuid);
                        joystickDevice.SetCooperativeLevel(hWnd, CooperativeLevelFlags.Background | CooperativeLevelFlags.NonExclusive);
                        break;
                    }
                    i++;
                }

                if (!found)
                    return false;

                joystickDevice.SetDataFormat(DeviceDataFormat.Joystick);

                joystickDevice.Acquire();

                UpdateStatus();
            }
            catch (Exception err)
            {
                return false;
            }

            return true;
        }

        public void ReleaseJoystick()
        {
            joystickDevice.Unacquire();
        }

        public void UpdateStatus()
        {
            Poll();

            int[] extraAxis = state.GetSlider();

            Xaxis = state.X;
            Yaxis = state.Y;
            Zaxis = state.Z;
            Rotation = state.Rz;

            byte[] jsButtons = state.GetButtons();
            buttons = new bool[jsButtons.Length];

            int i = 0;
            foreach (byte button in jsButtons)
            {
                buttons[i] = button >= 128;
                i++;
            }
        }

        private void Poll()
        {
            try
            {
                joystickDevice.Poll();
                state = joystickDevice.CurrentJoystickState;
            }
            catch
            {
                throw (null);
            }
        }
    }
}
