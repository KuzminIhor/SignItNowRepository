using System.Collections.Generic;

namespace SignItNow.Model
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Dictionary<string, string> Metadata { get; set; } = new Dictionary<string, string>();
        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
        public List<TaskInfo> CreatedTasks { get; set; } = new List<TaskInfo>();
        public List<TaskSigner> SigningTasks { get; set; } = new List<TaskSigner>();
//        public bool IsBanned { get; set; }
    }
}
