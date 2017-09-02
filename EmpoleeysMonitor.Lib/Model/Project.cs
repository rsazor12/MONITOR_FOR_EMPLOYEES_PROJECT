using System;

namespace EmployeesMonitor.Lib.Model
{
    public class Project : IComparable
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int SupervisorId { get; set; }
        public string Info { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return ProjectId;
        }

        public override bool Equals(object obj)
        {
            Project project = obj as Project;
            return project != null && ProjectId == project.ProjectId;
        }

        public int CompareTo(object obj)
        {
            Project project = obj as Project;
            return project != null ? ProjectId.CompareTo(project.ProjectId) : -1;
        }
    }
}
