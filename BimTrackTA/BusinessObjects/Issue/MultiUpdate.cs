using System.Collections.Generic;

namespace SeleniumTest.BusinessObjects
{
    public class MultiUpdate
    {
        // List of the ids of the issues you want to update
        public List<int> IssueIds { get; set; }
        // List of the operations that you want to make for all issues (path and value are needed)
        public List<Operation> Operations { get; set; }
        
        public class Operation
        {
            // The operation is always "replace"
            private string op = "replace";
            // Possible values are '/AssignedToUserId', '/DueDate', '/Group', '/LabelIds', '/PriorityId', '/PhaseId',
            // '/StatusId', '/TeamIds', '/TypeId', '/ZoneId' and '/CustomAttributes'.
            public string path { get; set; }
            // The type of the value needs to be (in the same order as the path): int, string, string, List<int>, int
            // int, int, List<int>, int, int, List<CustomAttribute>.
            public object value { get; set; }
        }
    }
}