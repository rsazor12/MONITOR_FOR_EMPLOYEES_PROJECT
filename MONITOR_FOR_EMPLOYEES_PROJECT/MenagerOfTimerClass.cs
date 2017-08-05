using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace EmployeesMonitor
{
    class MenagerOfTimerClass
    {
        System.Timers.Timer timer;  
        public MenagerOfTimerClass(int saveDataIntervalInMinutes)
        {
            timer =  new System.Timers.Timer();
            timer.Interval = saveDataIntervalInMinutes * 60 * 1000;  
        }

        public void AddHandlerFunctionToDispatcherTimer(ElapsedEventHandler HandlerMethodOfDispatcher)
        {
            timer.Elapsed += HandlerMethodOfDispatcher;
        }

        public void StartTimer()
        {
            timer.Start();            
        }





    }
}
