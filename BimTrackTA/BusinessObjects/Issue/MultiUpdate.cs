using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class MultiUpdate
    {
        public List<int> IssueIds { get; set; }
        public List<Operation> Operations { get; set; }
    }
}