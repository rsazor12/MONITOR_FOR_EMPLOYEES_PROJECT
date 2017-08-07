using System;

namespace EmployeesMonitor.Lib.Model
{
    public class UserAction
    {
        public int ActionId { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public DateTime Date { get; set; }
        public ActionType ActionType { get; set; }
        public string Info { get; set; }
    }
}
