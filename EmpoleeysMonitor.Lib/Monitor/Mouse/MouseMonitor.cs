using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using EmployeesMonitor.Lib.Model;
using System.Collections.Generic;
using System.Threading;
using static EmpoleeysMonitor.Lib.Monitor.Mouse.User32;
using EmpoleeysMonitor.Lib.Monitor.Mouse;
using EmpoleeysMonitor.Lib.Monitor.Mouse.CallbackObjects;

namespace EmployeesMonitor.Lib.Monitor.Mouse
{
    public class MouseMonitor : IMonitor 
    {
        private Thread thread;
        private List<UserAction> actions = new List<UserAction>();
        private object locker = new object();

        public void End()
        {
            thread.Abort();
        }

        public IList<UserAction> GetLatestUserActions()
        {
            lock (locker)
            {
                var items = actions.GetRange(0, actions.Count);
                actions.Clear();
                return items;
            }
        }

        public void Start()
        {
            thread = new Thread(Init);
            thread.Start();
        }

        private void Init()
        {
            using (var api = new MouseMonitorAPI())
            {
                api.CreateMouseHook(MouseClickedCallback);
                Application.Run();
            }
        }

        private void MouseClickedCallback(MouseClicked obj)
        {

            if (obj.typeOfEvent == ActionType.LeftMouseClick || obj.typeOfEvent == ActionType.RightMouseClick || obj.typeOfEvent == ActionType.Scroll)
            {
                lock (locker)
                {
                    actions.Add(new UserAction()
                    {
                        ActionType = obj.typeOfEvent,
                        Date = DateTime.UtcNow,
                        Info = obj.ToString()
                    });
                }
            }
            else return;
        }
    }
}

