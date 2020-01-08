using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{

    public class ProjectAttribute
    {
        public List<PredefinedAttributeValue> ProjectCustomAttributeValues { get; set; }
        public List<string> ProjectCustomAttributeTextValues { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }

        public int AddNewCustomAttributeValue(string name, string color)
        {
            var newValueObj = new PredefinedAttributeValue();
            newValueObj.Color = color;
            newValueObj.Name = name;
            
            if (this.ProjectCustomAttributeValues == null)
            {
                this.ProjectCustomAttributeValues = new List<PredefinedAttributeValue>();
            }
            this.ProjectCustomAttributeValues.Add(newValueObj);
            return this.ProjectCustomAttributeValues.Count;
        }
    }
}