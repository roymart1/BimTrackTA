using System;

namespace SeleniumTest.Common.Exceptions
{
    public class CustomObjectAttributeException : Exception
    {
        public CustomObjectAttributeException(){}

        public CustomObjectAttributeException(string message) : base(message)
        {
            
        }
        
        public CustomObjectAttributeException(string missingAttribute, string objectMissingAttribute) : 
            base("You must provide " + missingAttribute + " for your " + objectMissingAttribute + ".")
        {
        }
    }
}