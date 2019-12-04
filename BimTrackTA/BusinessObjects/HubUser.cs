
using System;

namespace SeleniumTest.BusinessObjects
{

    public class HubUser : User
    {
        public class RootObject
        {
            public User User { get; set; }
            public string Role { get; set; }
            public DateTime? LastWebLogin { get; set; }
            public object LastAddinLogin { get; set; }
            public bool IsActivated { get; set; }
        }
    }
}