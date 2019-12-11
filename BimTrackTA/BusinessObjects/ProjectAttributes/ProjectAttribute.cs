
using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{

    public class ProjectAttribute
    {
        public List<ProjectCustomAttributeValue> ProjectCustomAttributeValues { get; set; }
        public List<string> ProjectCustomAttributeTextValues { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
    }
}