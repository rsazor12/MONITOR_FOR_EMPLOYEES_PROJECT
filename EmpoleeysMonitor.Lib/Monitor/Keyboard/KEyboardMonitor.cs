using EmployeesMonitor.Lib.Model;
using EmployeesMonitor.Lib.Monitor;
using Keystroke.API;
using Keystroke.API.CallbackObjects;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace EmpoleeysMonitor.Lib.Monitor.Sample
{
    public class KeyboardMonitor : IMonitor
    {
        private object locker = new object();
        private readonly List<UserAction> actions = new List<UserAction>();
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
                var items = actions.GetRange(0, actions.Count); // shallow copy of list before clear
                actions.Clear();
                return items;
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
                actions.Add(new UserAction()
                {
                    ActionType = ActionType.KeyboardPressed,
                    Date = DateTime.UtcNow,
                    Info = obj.ToString()
                });
            }
        }
    }
}
