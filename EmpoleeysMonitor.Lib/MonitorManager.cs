using EmpoleeysMonitor.Lib.DataBase;
using EmpoleeysMonitor.Lib.Monitor;
using System.Collections.Generic;
using System.Timers;

namespace EmpoleeysMonitor.Lib
{
    public class MonitorManager
    {
        private IList<IMonitor> monitors;
        private SqlConnector dbConnector;
        private Timer timer;

        public MonitorManager(int saveDataIntervalInSeconds)
        {
            timer = new System.Timers.Timer();
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

        private void SendActionsToDatabase(object sender, ElapsedEventArgs e)
        {
            
        }
    }
}
