using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{

    public class ProjectAttribute
    {
        // This list can only be used if you have set the project attribute type to 'custom' or 'predefined'
        public List<AttributeValue> ProjectCustomAttributeValues { get; set; }
        public List<string> ProjectCustomAttributeTextValues { get; set; }
        public int Id { get; set; }
        // Values can be 'predefined' or 'custom'
        public string Type { get; set; }
        public string Name { get; set; }

        // You can use this to add a custom attribute. Colors are in hex format
        public int AddNewCustomAttributeValue(string name, string color)
        {
            var newValueObj = new AttributeValue();
            newValueObj.Color = color;
            newValueObj.Name = name;
            
            if (this.ProjectCustomAttributeValues == null)
            {
                this.ProjectCustomAttributeValues = new List<AttributeValue>();
            }
            this.ProjectCustomAttributeValues.Add(newValueObj);
            return this.ProjectCustomAttributeValues.Count;
        }
    }
}