﻿using EmployeesMonitor.Lib.Model;
using EmployeesMonitor.Lib.Monitor;
using System;
using System.Collections.Generic;
using System.Threading;

namespace EmpoleeysMonitor.Lib.Monitor.Sample
{
    public class SampleMonitor : IMonitor
    {
        private object locker = new object();
        private readonly List<UserAction> actions = new List<UserAction>();
        private readonly Random random = new Random();
        private Thread thread;

        public void Start()
        {
            thread = new Thread(GenerateSampleData);
            thread.Start();
        }

        public void End()
        {
            thread.Abort();
        }

        public IList<EmployeesMonitor.Lib.Model.UserAction> GetLatestUserActions()
        {
            lock (locker)
            {
                var items = actions.GetRange(0, actions.Count); // shallow copy of list before clear
                actions.Clear();
                return items;
            }
        }

        private void GenerateSampleData()
        {
            while (true)
            {
                Thread.Sleep(random.Next(3000, 10000));
                lock (locker)
                {
                    actions.Add(new UserAction()
                    {
                        ActionType = ActionType.Other,
                        Date =  DateTime.Now,
                        Info = "Test"
                    });
                }
            }
        }
    }
}
