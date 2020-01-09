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
            string jsonPayload = JsonConvert.SerializeObject(issue);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues";
            IRestResponse response =  Perform_Create(connStr, jsonPayload);
            
            return response.IsSuccessful;
        }

        public bool UpdateIssue(int hubId, int projectId, int issueId, Issue issue)
        {
            string jsonPayload = JsonConvert.SerializeObject(issue);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId;
            IRestResponse response =  Perform_Update(connStr, jsonPayload);
            
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
        
        public bool PatchIssues(int hubId, int projectId, string path, object value)
        {
            string jsonToSend;
            if (value is string || value is char)
            {
                jsonToSend = "{'op': 'replace', 'path': '" + path + "', 'value': '" + value + "'}";
            }
            else
            {               
                jsonToSend = "{'op': 'replace', 'path': '" + path + "', 'value': " + value + "}";
            }
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues";
            IRestResponse response = Perform_Patch(connStr, jsonToSend);

            return response.IsSuccessful;
        }
    }
}

