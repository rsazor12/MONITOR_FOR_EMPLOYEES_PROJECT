using System.Collections.Generic;

namespace EmpoleeysMonitor.Lib.Model
{
    public class Project
    {
        public int IdProject { get; set; }
        public string Name { get; set; }
        public int SupervisorId { get; set; }
        public string Info { get; set; }
        public IList<int> UserIds { get; set; }
    }
}
