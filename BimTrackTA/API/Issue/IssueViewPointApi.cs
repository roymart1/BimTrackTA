using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class IssueViewPointApi : ApiBase
    {
        public List<Issue.ViewPoint> GetIssueViewPointList(int hubId, int projectId, int issueId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId + "/viewpoints";
            return Perform_Get<List<Issue.ViewPoint>>(connStr);
        }

        public bool CreateIssueViewPoint(int hubId, int projectId, int issueId, string viewName)
        {
            string jsonToSend = "{'ViewName': '" + viewName + "'}";
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId
                             + "/viewpoints";
            IRestResponse response =  Perform_Create(connStr, jsonToSend);
            
            return response.IsSuccessful;
        }

        public Issue.ViewPoint GetIssueViewPoint(int hubId, int projectId, int issueId, int viewPointId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/viewpoints/" + viewPointId;
            return Perform_Get<Issue.ViewPoint>(connStr);
        }
        
        public bool DeleteIssueViewPoint(int hubId, int projectId, int issueId, int viewPointId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/viewpoints/" + viewPointId;
            IRestResponse response = Perform_Delete(connStr);

            return response.IsSuccessful;
        }

        public bool UpdateIssueViewPoint(int hubId, int projectId, int issueId, int viewPointId, string key,
            object value)
        {
            string jsonToSend = Create_UpdateJsonString(key, value);
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/viewpoints/" + viewPointId;
            IRestResponse response = Perform_Update(connStr, jsonToSend);

            return response.IsSuccessful;
        }
    }
}

