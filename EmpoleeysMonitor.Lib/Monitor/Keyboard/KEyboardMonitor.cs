using EmployeesMonitor.Lib.Model;
using EmployeesMonitor.Lib.Monitor;
using Keystroke.API;
using Keystroke.API.CallbackObjects;
using SaveToFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmpoleeysMonitor.Lib.Monitor.Sample
{
    public class KeyboardMonitor : IMonitor
    {
        private static string KeyString = String.Empty;
        private object locker = new object();
        private List<UserAction> actions = new List<UserAction>();
        private Random random = new Random();
        private Thread thread;

        public void Start()
        {
            thread = new Thread(GenerateSampleData);
            thread.Start();
        }

        public void End()
        {
            thread.Abort();
        }

        public IList<EmployeesMonitor.Lib.Model.UserAction> GetLatestUserActions()
        {
            lock (locker)
            {
                var items = actions.GetRange(0, actions.Count); // shallow copy of list before clear
                actions.Clear();
                return items;
            }
        }

        private void GenerateSampleData()
        {
            using (var api = new KeystrokeAPI())
            {
                api.CreateKeyboardHook(KeyPressedCallback);
                Application.Run();
            }


            while (true)
            {
                lock (locker)
                {
                    actions.Add(new UserAction()
                    {
                        ActionType = ActionType.KeyboardPressed,
                        Date = DateTime.UtcNow,
                        Info = KeyString
                    });
                }
            }
        }


        private static void KeyPressedCallback(KeyPressed obj)
        {
            KeyString += obj.ToString();
            //Console.WriteLine(MyStorage.logStorage);
        }
    }
}
