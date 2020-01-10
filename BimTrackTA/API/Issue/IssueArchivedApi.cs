using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class IssueArchivedApi : ApiBase
    {
        public List<Issue> GetIssueArchivedList(int hubId, int projectId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/archivedissues";
            return Perform_Get<List<Issue>>(connStr);
        }

        public Issue GetIssueArchived(int hubId, int projectId, int issueId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/archivedissues/" + issueId;
            return Perform_Get<Issue>(connStr);
        }

        public bool RestoreArchivedIssue(int hubId, int projectId, int issueId, int statusId)
        {
            
            string jsonToSend = "{'ArchiveIssue': false, 'StatusId': " + statusId + "}";
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/archivedissues/" + issueId;
            IRestResponse response = Perform_Patch(connStr, jsonToSend);

            return response.IsSuccessful;
        }

        public bool DeleteArchivedIssue(int hubId, int projectId, int issueId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/archivedissues/" + issueId;
            IRestResponse response = Perform_Delete(connStr);

            return response.IsSuccessful;
        }
    }
}

