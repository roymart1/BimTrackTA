using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{

    public class CustomAttribute
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public bool? IsMandatory { get; set; }
        private List<AttributeValue> PredefinedValues { get; set; }
        public string TextValue { get; set; }
    }
}