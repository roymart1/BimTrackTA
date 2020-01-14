using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class IssueApi : ApiBase
    {
        public List<Issue> GetIssueList(int hubId, int projectId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues";
            return Perform_Get<List<Issue>>(connStr);
        }

        public Issue GetIssue(int hubId, int projectId, int issueId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId;
            return Perform_Get<Issue>(connStr);
        }
        
        public bool CreateIssue(int hubId, int projectId, Issue issue)
        {            
            // Required fields for Issue object are: 
            //     - Title (string)
            //     - TypeId (int: the id of a Type object present in the project)
            //     - PriorityId (int: the id of a Priority object present in the project)
            //     - StatusId (int: the id of a Status object present in the project)
            //
            // CTRL+Click on Issue for further details about the object's attributes
            //
            // Since you need a project id, that means that you need to have created a project in that hub first.
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues";
            IRestResponse response =  Perform_Create(connStr, issue);
            
            return response.IsSuccessful;
        }

        public bool UpdateIssue(int hubId, int projectId, int issueId, Issue issue)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId;
            IRestResponse response =  Perform_Update(connStr, issue);
            
            return response.IsSuccessful;
        }

        public Issue.IssueHistory GetIssueHistory(int hubId, int projectId, int issueId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId + "/history";
            return Perform_Get<Issue.IssueHistory>(connStr);
        }

        public bool ArchiveIssue(int hubId, int projectId, int issueId)
        {
            string jsonToSend = "{'ArchiveIssue': true}";
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId;
            IRestResponse response = Perform_Patch(connStr, jsonToSend);

            return response.IsSuccessful;
        }
        
        public bool PatchIssues(int hubId, int projectId, MultiUpdate multiUpdate)
        {
            // CTRL+Click on MultiUpdate for further details about the object's attributes. They are all required.
            //
            // Since you need a project id, that means that you need to have created a project in that hub first.
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues";
            IRestResponse response = Perform_Patch(connStr, multiUpdate);

            return response.IsSuccessful;
        }
    }
}

