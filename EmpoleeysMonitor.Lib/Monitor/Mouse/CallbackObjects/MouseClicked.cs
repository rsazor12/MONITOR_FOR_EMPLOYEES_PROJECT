using EmployeesMonitor.Lib.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpoleeysMonitor.Lib.Monitor.Mouse.CallbackObjects
{
    public class MouseClicked
    {
        public ActionType typeOfEvent { get; set; }
        public MouseClicked() { } 
    }
}
