using System;

namespace SeleniumTest.Common.Exceptions
{
    public class BTException : Exception
    {
        public BTException()
        {
        }

        public BTException(string message) : base(message)
        {    
            
        }
    }
}