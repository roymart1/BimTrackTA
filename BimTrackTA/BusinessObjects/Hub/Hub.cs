using System;
using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class Hub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Author Author { get; set; }
        public BimImage BimImage { get; set; }
        public DateTime CreationDate { get; set; }
        public List<HubUser> Users { get; set; }
    }
}