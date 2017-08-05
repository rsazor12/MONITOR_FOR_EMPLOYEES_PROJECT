using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeesMonitor.MonitoringClasses.MouseMonitorClass;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using EmployeesMonitor.MonitoringClasses.FileMonitorClasses;
using System.Timers;

namespace EmployeesMonitor
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tu musimy tworzyć nasze obiekty monitorujące
            FileMonitorClass obFileMonitorClass = new FileMonitorClass("C:\\Workspace");

            //Tu musimy przypisać Handlery z tych naszych monitorujących klas do Dispatchera
            MenagerOfTimerClass obMenagerOfDispatcherClass = new MenagerOfTimerClass(60);

            obMenagerOfDispatcherClass.AddHandlerFunctionToDispatcherTimer(new ElapsedEventHandler(obFileMonitorClass.FileMonitorHandlerOfDispatcher));

            //Startujemy Dispatcher - UWAGA - tu wątek główny(main) BLOKUJE SIĘ !!!! nic pod tą linijką się nie wykona
            obMenagerOfDispatcherClass.StartTimer();

           
            /*MouseMonitorClass._hookID = MouseMonitorClass.SetHook(MouseMonitorClass._proc);
            Application.Run();
            MouseMonitorClass.UnhookWindowsHookEx(MouseMonitorClass._hookID);
            Console.ReadKey();//push1*/

            Console.ReadKey();

            connect();
        }

        public static void connect()
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