using System.Collections.Generic;

namespace EmployeesMonitor.Lib.Model
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int SupervisorId { get; set; }
        public string Info { get; set; }
       // public IList<int> UserIds { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
