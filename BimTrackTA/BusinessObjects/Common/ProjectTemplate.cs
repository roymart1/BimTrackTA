using System;

namespace SeleniumTest.BusinessObjects
{
    public class ProjectTemplate : Project
    {
        public int HubId { get; set; }
        public new int Id { get; set; }
        public Author ProjectTemplateAuthor { get; set; }
        public new string Name { get; set; }
        public new DateTime CreationDate { get; set; }
    }
}