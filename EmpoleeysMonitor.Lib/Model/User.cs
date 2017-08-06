using System.Collections.Generic;

namespace EmpoleeysMonitor.Lib.Model
{
    public class User
    {
        public int IdUser { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
        public IList<int> ProjectIds { get; set; }
    }
}
