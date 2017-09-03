using EmployeesMonitor.Lib.Model;
using EmpoleeysMonitor.Lib.Monitor.Mouse;
using EmpoleeysMonitor.Lib.Monitor.Mouse.CallbackObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace EmployeesMonitor.Lib.Monitor.Mouse
{
    public class MouseMonitor : IMonitor 
    {
        private Thread thread;
        private readonly List<UserAction> actions = new List<UserAction>();
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
            using (var api = new MouseMonitorApi())
            {
                api.CreateMouseHook(MouseClickedCallback);
                Application.Run();
            }
        }

        private void MouseClickedCallback(MouseClicked obj)
        {
            if (obj.TypeOfEvent == ActionType.LeftMouseClick || obj.TypeOfEvent == ActionType.RightMouseClick || obj.TypeOfEvent == ActionType.Scroll)
            {
                lock (locker)
                {
                    UserAction action = actions.FirstOrDefault(x => x.ActionType == obj.TypeOfEvent);
                    if (action == null)
                    {
                        actions.Add(new UserAction()
                        {
                            ActionType = obj.TypeOfEvent,
                            Date =  DateTime.Now,
                            Info = "1"
                        });
                    }
                    else
                    {
                        action.Info = (int.Parse(action.Info) + 1).ToString();
                    }
                }
            }
        }
    }
}

