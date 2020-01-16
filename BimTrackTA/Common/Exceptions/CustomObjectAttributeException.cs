using System;

namespace SeleniumTest.Common.Exceptions
{
    public class CustomObjectAttributeException : Exception
    {
        public CustomObjectAttributeException(){}

        public CustomObjectAttributeException(string message) : base(message)
        {
            
        }
        
        public CustomObjectAttributeException(string youMustProvide, string forYour) : 
            base("You must provide " + youMustProvide + " for your " + forYour + ".")
        {
        }
    }
}