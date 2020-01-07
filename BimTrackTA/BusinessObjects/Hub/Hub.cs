using System;

namespace SeleniumTest.BusinessObjects
{
    public class Hub
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Author HubAuthor { get; set; }
        public Image HubImage { get; set; }
        public string CreationDate { get; set; }
    }
}