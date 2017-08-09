using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Forms;
using System.Threading;
using System.Timers;

namespace MONITOR_FOR_EMPLOYEES_PROJECT
{
    class MenagerOfTimerClass
    {
        System.Timers.Timer timer;  
        public MenagerOfTimerClass(int intervalOfSaveDataToDB)
        {
            timer =  new System.Timers.Timer(); //tworze timer
            //dispatcherTimer.Tick += HandlerMethodOfDispatcher;      //tu podpinam funkcje którą ktos przesle w parametrze( bedzie ona uruchamiana np co godzine)
            timer.Interval = 1000;   //new TimeSpan(0,0,1);
            //dispatcherTimer.Start();                                 //startuje Dispatcher
        }

        public void addHandlerFunctionToDispatcherTimer(ElapsedEventHandler HandlerMethodOfDispatcher)
        {
            timer.Elapsed += HandlerMethodOfDispatcher;
        }

        public void startTimer()
        {
            timer.Start();
            
        }
    }
}
