using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class IssueViewPointCommentApi : ApiBase
    {
        // This type of comment is the same as the ones you can have directly in the issue
        public List<Comment> GetIssueViewPointCommentList(int hubId, int projectId, int issueId, int viewPointId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/viewpoints/" + viewPointId + "/comments";
            return Perform_Get<List<Comment>>(connStr);
        }

        public bool CreateIssueViewPointComment(int hubId, int projectId, int issueId, int viewPointId, string name)
        {
            string jsonToSend = "{'Name': '" + name + "'}";
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/viewpoints/" + viewPointId + "/comments";
            IRestResponse response =  Perform_Create(connStr, jsonToSend);
            
            return response.IsSuccessful;
        }
        
        public bool DeleteIssueViewPointComment(int hubId, int projectId, int issueId, int viewPointId, 
            int viewPointCommentId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/viewpoints/" + viewPointId + "/comments/" + viewPointCommentId;
            IRestResponse response = Perform_Delete(connStr);

            return response.IsSuccessful;
        }
    }
}

