using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using EmployeesMonitor.Lib.Model;
using System.Collections.Generic;
using System.Threading;

namespace EmployeesMonitor.Lib.Monitor.Mouse
{
    public class MouseMonitor : IMonitor
    {
        private Thread thread;
        public static LowLevelMouseProc _proc = HookCallback;
        public static IntPtr _hookID = IntPtr.Zero;
        public static int lbutton = 0;
        public static int rbutton = 0;
        private object locker = new object();

        public void Start()
        {
            thread = new Thread(StartMonitoringMouse);
            thread.Start();
        }

        public void End()
        {
            thread.Abort();
        }

        public IList<UserAction> GetLatestUserActions()
        {
            return new List<UserAction>(); //?? jaki sens
        }

        public void StartMonitoringMouse()
        {
            _hookID = SetHook(_proc);
          while(thread.IsAlive)
            {
                
            }
            UnhookWindowsHookEx(_hookID);
        }

        public static IntPtr SetHook(LowLevelMouseProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return SetWindowsHookEx(WH_MOUSE_LL, proc, GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public delegate IntPtr LowLevelMouseProc(int nCode, IntPtr wParam, IntPtr lParam);


        public static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && MouseMessages.WM_LBUTTONDOWN == (MouseMessages)wParam)
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
               // Console.WriteLine(hookStruct.pt.x + ", " + hookStruct.pt.y + "\tkliknięcia LPM: " + ++lbutton);
                MessageBox.Show(hookStruct.pt.x + ", " + hookStruct.pt.y + "\tkliknięcia LPM: " + ++lbutton);

            }
            else if (nCode >= 0 && MouseMessages.WM_RBUTTONDOWN == (MouseMessages)wParam)
            {
                MSLLHOOKSTRUCT hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
             //   Console.WriteLine(hookStruct.pt.x + ", " + hookStruct.pt.y + "\tkliknięcia PPM: " + ++rbutton);
                MessageBox.Show(hookStruct.pt.x + ", " + hookStruct.pt.y + "\tkliknięcia PPM: " + ++rbutton);
            }
            else if (nCode >= 0 && MouseMessages.WM_MOUSEWHEEL == (MouseMessages)wParam)
            {

                //Console.WriteLine("Scroll");
                MessageBox.Show("Scroll");
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);
        }


        private const int WH_MOUSE_LL = 14;

        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }


        [StructLayout(LayoutKind.Sequential)]

        private struct POINT
        {
            public int x;
            public int y;
        }


        [StructLayout(LayoutKind.Sequential)]

        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(int idHook, LowLevelMouseProc lpfn, IntPtr hMod, uint dwThreadId);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool UnhookWindowsHookEx(IntPtr hhk);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true, CallingConvention = CallingConvention.Winapi)]
        public static extern short GetKeyState(int keyCode);
    }
}

