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
        //Entry point for aplication S
        //komentarz
        static void Main(string[] args)
        {

            FileMonitorClass obFileMonitorClass = new FileMonitorClass("c:\\Workspace");
            /*MouseMonitorClass._hookID = MouseMonitorClass.SetHook(MouseMonitorClass._proc);
            Application.Run();
            MouseMonitorClass.UnhookWindowsHookEx(MouseMonitorClass._hookID);
            Console.ReadKey();//push1*/


        }
    }
}