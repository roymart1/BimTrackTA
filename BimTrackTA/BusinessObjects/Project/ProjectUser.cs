using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class ProjectUser
    {
        // The user object of the ProjectUser.
        public int? UserId { get; set; }
        public User User { get; set; }
        public string Role { get; set; }
        public List<Team> ProjectTeams { get; set; }
        public string DefaultFilterTemplateId { get; set; }
    }
}