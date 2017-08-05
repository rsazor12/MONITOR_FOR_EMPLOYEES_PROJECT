using EmpoleeysMonitor.Lib;
using EmpoleeysMonitor.Lib.Monitor.File;
using System;

namespace EmployeesMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tu musimy tworzyć nasze obiekty monitorujące
            FileMonitor obFileMonitorClass = new FileMonitor("C:\\Workspace");

            //Tu musimy przypisać Handlery z tych naszych monitorujących klas do Dispatchera
            MonitorManager monitorManager = new MonitorManager(60);
            monitorManager.StartMonitoring();
           
            /*MouseMonitorClass._hookID = MouseMonitorClass.SetHook(MouseMonitorClass._proc);
            Application.Run();
            MouseMonitorClass.UnhookWindowsHookEx(MouseMonitorClass._hookID);
            Console.ReadKey();//push1*/

            Console.ReadKey();

            Connect();
        }

        public static void Connect()
        {
            //MySql.Data.MySqlClient.MySqlConnection conn;
            //string myConnectionString;

            //myConnectionString = "server=149.156.136.151:3306;uid=kbielski;" + "pwd=1234567890;database=kbielski;";

            //try
            //{
            //    conn = new MySql.Data.MySqlClient.MySqlConnection();
            //    conn.ConnectionString = myConnectionString;
            //    conn.Open();
            //}
            //catch (MySql.Data.MySqlClient.MySqlException ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}