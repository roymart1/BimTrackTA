using System;

namespace SeleniumTest.BusinessObjects
{
    public class ProjectTemplate : Project
    {
        // Id of the hub in which it's in
        public int? HubId { get; set; }
        // Id of the project from which we want to create the template
        public int? SourceProjectId { get; set; }
        public new int? Id { get; set; }
        public Author ProjectTemplateAuthor { get; set; }
        public new string Name { get; set; }
        public new DateTime? CreationDate { get; set; }
    }
}