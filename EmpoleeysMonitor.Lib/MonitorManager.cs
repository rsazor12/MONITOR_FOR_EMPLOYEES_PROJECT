using EmployeesMonitor.Lib.DataBase;
using EmployeesMonitor.Lib.Model;
using EmployeesMonitor.Lib.Monitor;
using System.Collections.Generic;
using System.Timers;

namespace EmployeesMonitor.Lib
{
    public class MonitorManager
    {
        public User User { get; set; }
        public Project Project { get; set; }

        private readonly IList<IMonitor> monitors;
        private readonly SqlConnector dbConnector;
        private readonly Timer timer;

        public MonitorManager(int saveDataIntervalInSeconds)
        {
            timer = new Timer();
            timer.Interval = saveDataIntervalInSeconds * 1000;
            timer.Elapsed += SendActionsToDatabase;

            dbConnector = new SqlConnector();
            monitors = new List<IMonitor>();
        }

        public void RegisterMonitor(IMonitor monitor)
        {
            monitors.Add(monitor);
        }

        public void StartMonitoring()
        {
            foreach (var monitor in monitors)
            {
                monitor.Start();
            }

            timer.Start();
        }

        public void EndMonitoring()
        {
            timer.Stop();

            foreach (var monitor in monitors)
            {
                monitor.End();
            }
        }

        private async void SendActionsToDatabase(object sender, ElapsedEventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("Send");
            List<UserAction> actions = new List<UserAction>();
            foreach (var monitor in monitors)
            {
                actions.AddRange(monitor.GetLatestUserActions());
            }

            foreach (var action in actions)
            {
                action.ProjectId = Project != null ? Project.ProjectId : -1;
                action.UserId = User != null ? User.UserId : -1;
                await dbConnector.AddUserAction(action);
            }
        }
    }
}
