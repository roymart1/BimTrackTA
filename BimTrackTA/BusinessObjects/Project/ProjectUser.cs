using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class ProjectUser
    {
        public int UserId { get; set; }
        public string Role { get; set; }
        public List<int> ProjectTeams { get; set; }
    }
}