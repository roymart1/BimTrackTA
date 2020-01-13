using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class Status
    {
        // List of teams that are allowed to change this status. It must be a team that is part of the project.
        public List<Team> TeamsAllowedForStatus { get; set; }
        // Color in hex format
        public string Color { get; set; }
        public string Name { get; set; }
        public int Id { get; set; } 
        
    }
}