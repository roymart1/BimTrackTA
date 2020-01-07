using System;

namespace SeleniumTest.BusinessObjects
{
    public class ProjectTemplate : Project
    {
        public int HubId { get; set; }
        public int Id { get; set; }
        public Author ProjectTemplateAuthor { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    }
}