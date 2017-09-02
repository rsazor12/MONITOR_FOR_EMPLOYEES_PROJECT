using EmployeesMonitor.Lib.Model;
using EmployeesMonitor.Lib.Monitor;
using Keystroke.API;
using Keystroke.API.CallbackObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace EmpoleeysMonitor.Lib.Monitor.Sample
{
    public class KeyboardMonitor : IMonitor
    {
        private object locker = new object();
        private UserAction action;
        private Thread thread;

        public void Start()
        {
            thread = new Thread(Init);
            thread.Start();
        }

        public void End()
        {
            thread.Abort();
        }

        public IList<UserAction> GetLatestUserActions()
        {
            lock (locker)
            {
                List<UserAction> actionList = new List<UserAction> { action };
                action = null;
                return actionList;
            }
        }

        private void Init()
        {
            using (var api = new KeystrokeApi())
            {
                api.CreateKeyboardHook(KeyPressedCallback);
                Application.Run();
            }
        }


        private void KeyPressedCallback(KeyPressed obj)
        {
            lock (locker)
            {
                if (action == null)
                {
                    action = new UserAction()
                    {
                        ActionType = ActionType.KeyboardPressed,
                        Date = DateTime.UtcNow,
                        Info = obj.ToString()
                    };
                }
                else
                {
                    action.Info += obj.ToString();
                }
            }
        }
    }
}
