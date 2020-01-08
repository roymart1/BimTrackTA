using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class Status
    {
        public List<Team> TeamsAllowedForStatus { get; set; }
        public string Color { get; set; }
        public string Name { get; set; }
        public int Id { get; set; } 
        
    }
}