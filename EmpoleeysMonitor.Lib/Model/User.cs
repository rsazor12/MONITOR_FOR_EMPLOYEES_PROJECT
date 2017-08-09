using System.Collections.Generic;

namespace EmployeesMonitor.Lib.Model
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
        //public IList<int> ProjectIds { get; set; }

        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }

}
