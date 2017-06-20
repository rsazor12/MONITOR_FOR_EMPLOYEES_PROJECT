using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MONITOR_FOR_EMPLOYEES_PROJECT.MonitoringClasses.MouseMonitorClass;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using MONITOR_FOR_EMPLOYEES_PROJECT.MonitoringClasses.FileMonitorClasses;

namespace MONITOR_FOR_EMPLOYEES_PROJECT
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tu Tworz
            FileMonitorClass obFileMonitorClass = new FileMonitorClass("c:\\Workspace");


            /*MouseMonitorClass._hookID = MouseMonitorClass.SetHook(MouseMonitorClass._proc);
            Application.Run();
            MouseMonitorClass.UnhookWindowsHookEx(MouseMonitorClass._hookID);
            Console.ReadKey();//push1*/

            connect();
        }

        public static void connect()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            string myConnectionString;

            myConnectionString = "server=149.156.136.151:3306;uid=kbielski;" + "pwd=1234567890;database=kbielski;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}