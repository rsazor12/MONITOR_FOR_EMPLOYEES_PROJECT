using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Threading;

namespace MONITOR_FOR_EMPLOYEES_PROJECT
{
    /// <summary>
    /// Klasa obługująca DispatcherTimer , który bedzie wywoływał zdarzenie co określony czas(potrzebne do monitorowania funkcje zbierajace dane beda sie odpalac np. co godzine)
    /// </summary>
    class MenagerOfDispatcherClass
    {
        MenagerOfDispatcherClass(EventHandler HandlerMethodOfDispatcher, TimeSpan intervalOfGeneratingReport)
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer(); //tworze timer
            dispatcherTimer.Tick +=  HandlerMethodOfDispatcher;      //tu podpinam funkcje którą ktos przesle w parametrze( bedzie ona uruchamiana np co godzine)
            dispatcherTimer.Interval = intervalOfGeneratingReport;   //new TimeSpan(0,0,1);
            dispatcherTimer.Start();                                 //startuje Dispatcher
        }              
    }
}