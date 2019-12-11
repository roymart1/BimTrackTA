
using System;

namespace SeleniumTest.BusinessObjects
{

    public class HubUser
    {
        public User User { get; set; }
        public string Role { get; set; }
        public DateTime? LastWebLogin { get; set; }
        public DateTime? LastAddinLogin { get; set; }
        public bool IsActivated { get; set; }
    }
}