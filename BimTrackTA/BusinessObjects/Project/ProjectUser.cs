using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class ProjectUser
    {
        public User User { get; set; }
        public string Role { get; set; }
        public List<Team> Teams { get; set; }
//        public int DefaultFilterTemplateId { get; set; }      
        // DefaultFilterTemplateId: was removed from the DTO since it raises a casting exception 
    }
}