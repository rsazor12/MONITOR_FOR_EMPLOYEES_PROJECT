using EmployeesMonitor.Lib.Model;
using EmpoleeysMonitor.Lib.Monitor.Mouse.CallbackObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EmpoleeysMonitor.Lib.Monitor.Mouse
{
    class MouseMonitorAPI : IDisposable 
    {
        private enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
            WM_MOUSEMOVE = 0x0200,
            WM_MOUSEWHEEL = 0x020A,
            WM_RBUTTONDOWN = 0x0204,
            WM_RBUTTONUP = 0x0205
        }

        private const int WH_MOUSE_LL = 14;
        private struct POINT
        {
            public int x;
            public int y;
        }

        private struct MSLLHOOKSTRUCT
        {
            public POINT pt;
            public uint mouseData;
            public uint flags;
            public uint time;
            public IntPtr dwExtraInfo;
        }
        private MSLLHOOKSTRUCT hookStruct;

        private IntPtr globalMouseHookId;
        private IntPtr currentModuleId;
        private User32.LowLevelHook HookMouseDelegate;
        private Action<MouseClicked> mouseClickedCallback;
        private ActionType mouseMessage;

        public MouseMonitorAPI()
        {
            Process currentProcess = Process.GetCurrentProcess();
            ProcessModule currentModudle = currentProcess.MainModule;
            this.currentModuleId = User32.GetModuleHandle(currentModudle.ModuleName);
        }

        public void CreateMouseHook(Action<MouseClicked> mouseClickedCallback)
        {
            this.mouseClickedCallback = mouseClickedCallback;
            this.HookMouseDelegate = HookMouseCallbackImplementation;
            this.globalMouseHookId = User32.SetWindowsHookEx(WH_MOUSE_LL, this.HookMouseDelegate, this.currentModuleId, 0);
        }


        private IntPtr HookMouseCallbackImplementation(int nCode, IntPtr wParam, IntPtr lParam)
        {
            MouseMessages WParam = (MouseMessages)wParam;
            ActionType actionType;
            if (WParam == MouseMessages.WM_LBUTTONDOWN) actionType = ActionType.LeftMouseClick;
            else if (WParam == MouseMessages.WM_RBUTTONDOWN) actionType = ActionType.RightMouseClick;
            else if (WParam == MouseMessages.WM_MOUSEWHEEL) actionType = ActionType.Scroll;
            else return IntPtr.Zero;

            if (nCode >= 0 && (WParam == MouseMessages.WM_LBUTTONDOWN || WParam == MouseMessages.WM_RBUTTONDOWN || WParam == MouseMessages.WM_MOUSEWHEEL))
            {

                hookStruct = (MSLLHOOKSTRUCT)Marshal.PtrToStructure(lParam, typeof(MSLLHOOKSTRUCT));
                mouseMessage = actionType;
                Console.WriteLine(hookStruct.pt.x + ", " + hookStruct.pt.y + " " + mouseMessage.ToString());

            }

            if (mouseMessage == ActionType.LeftMouseClick || mouseMessage == ActionType.RightMouseClick || mouseMessage == ActionType.Scroll)
                MouseParser(wParam, lParam);

            return User32.CallNextHookEx(globalMouseHookId, nCode, wParam, lParam);
        }

        private void MouseParser(IntPtr wParam, IntPtr lParam)
        {
            var key = new MouseClicked();
            key.typeOfEvent = mouseMessage;
            mouseClickedCallback.Invoke(key);
        }

        public void Dispose()
        {
            if (globalMouseHookId == IntPtr.Zero)
                User32.UnhookWindowsHookEx(globalMouseHookId);
        }
    }
}
