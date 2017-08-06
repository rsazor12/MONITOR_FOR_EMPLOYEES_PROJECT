using System;

namespace EmpoleeysMonitor.Lib.Model
{
    public class UserAction
    {
        public int IdAction { get; set; }
        public int UserId { get; set; }
        public int ProjectId { get; set; }
        public DateTime Date { get; set; }
        public ActionType Action { get; set; }
        public string Info { get; set; }
    }
}
