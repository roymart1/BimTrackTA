using System;

namespace SeleniumTest.BusinessObjects
{

    public class HubUser
    {
        public User User { get; set; }
        public string Role { get; set; }
        // TODO: Why optional? If this is true, I'll need to change the other data structures
        public DateTime? LastWebLogin { get; set; }
        public DateTime? LastAddinLogin { get; set; }
        public bool IsActivated { get; set; }
    }
}