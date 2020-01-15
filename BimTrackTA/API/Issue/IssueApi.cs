using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{
    public class IssueApi : ApiBase
    {
        public List<Issue> GetIssueList(int hubId, int projectId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/issues";
            return Perform_Get<List<Issue>>(connStr);
        }

        public Issue GetIssue(int hubId, int projectId, int issueId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId;
            return Perform_Get<Issue>(connStr);
        }
        
        public int CreateIssue(int hubId, int projectId, Issue issue)
        {                        
            // Validate that the object is fine
            ValidateOperation(issue);
            
            // Required fields for Issue object are: 
            //     - Title (string)
            //     - TypeId (int: the id of a Type object present in the project)
            //     - PriorityId (int: the id of a Priority object present in the project)
            //     - StatusId (int: the id of a Status object present in the project)
            //
            // CTRL+Click on Issue for further details about the object's attributes
            //
            // Since you need a project id, that means that you need to have created a project in that hub first.
            //
            // N.B. : If you receive the message 'the requested resource was not found', it's because your typeId, your
            //        priorityId or your statusId doesn't come from an existing type, priority or status in your project.
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/issues";
            return Perform_Create(connStr, issue);
        }

        public bool UpdateIssue(int hubId, int projectId, int issueId, Issue issue)
        {
            // Validate that the object is valid
            ValidateOperation(issue);
            
            // Required fields for Issue object are: 
            //     - Title (string)
            //     - TypeId (int: the id of a Type object present in the project)
            //     - PriorityId (int: the id of a Priority object present in the project)
            //     - StatusId (int: the id of a Status object present in the project)
            //
            // So basically, it's the same thing as the creation.
            //
            // CTRL+Click on Issue for further details about the object's attributes
            //
            // Since you need a project id, that means that you need to have created a project in that hub first.
            //
            // N.B. : If you receive the message 'the requested resource was not found', it's because your typeId, your
            //        priorityId or your statusId doesn't come from an existing type, priority or status in your project.
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId;
            IRestResponse response =  Perform_Update(connStr, issue);
            
            return response.IsSuccessful;
        }

        public Issue.IssueHistory GetIssueHistory(int hubId, int projectId, int issueId)
        {
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId + "/history";
            return Perform_Get<Issue.IssueHistory>(connStr);
        }

        public bool ArchiveIssue(int hubId, int projectId, int issueId)
        {
            string jsonToSend = "{'ArchiveIssue': true}";
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId;
            IRestResponse response = Perform_Patch(connStr, jsonToSend);

            return response.IsSuccessful;
        }
        
        public bool PatchIssues(int hubId, int projectId, MultiUpdate multiUpdate)
        {
            // CTRL+Click on MultiUpdate for further details about the object's attributes. They are all required.
            //
            // Since you need a project id, that means that you need to have created a project in that hub first.
            string connStr = API_VERSION + "/hubs/" + hubId + "/projects/" + projectId + "/issues";
            IRestResponse response = Perform_Patch(connStr, multiUpdate);

            return response.IsSuccessful;
        }

        private void ValidateOperation(Issue issue)
        {
            if (issue == null) throw new ArgumentNullException(nameof(issue));
            if (issue.Title == null)
            {
                throw new CustomObjectAttributeException("a title", "project issue");
            }
        }
    }
}

