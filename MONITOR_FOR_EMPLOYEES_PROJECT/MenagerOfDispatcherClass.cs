using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace MONITOR_FOR_EMPLOYEES_PROJECT
{
    class MenagerOfDispatcherClass
    {
        MenagerOfDispatcherClass(EventHandler HandlerMethodOfDispatcher, TimeSpan intervalOfSaveDataToDB)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer(); //tworze timer
            dispatcherTimer.Tick += HandlerMethodOfDispatcher;      //tu podpinam funkcje którą ktos przesle w parametrze( bedzie ona uruchamiana np co godzine)
            dispatcherTimer.Interval = intervalOfSaveDataToDB;   //new TimeSpan(0,0,1);
            dispatcherTimer.Start();                                 //startuje Dispatcher
        }
    }
}
