using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class ProjectUser
    {
        public int UserId { get; set; }
        public User user { get; set; }
        public string Role { get; set; }
        public List<Team> ProjectTeams { get; set; }
        public string DefaultFilterTemplateId { get; set; }
    }
}