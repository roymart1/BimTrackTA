using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class IssueViewPointCommentApi : ApiBase
    {
        // This type of comment is the same as the ones you can have directly in the issue
        public List<BimComment> GetIssueViewPointCommentList(int hubId, int projectId, int issueId, int viewPointId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/viewpoints/" + viewPointId + "/comments";
            return Perform_Get<List<BimComment>>(connStr);
        }

        public int CreateIssueViewPointComment(int hubId, int projectId, int issueId, int viewPointId, BimComment comment)
        {
            // Required fields for BimComment object are: 
            //     - Comment (string)
            //
            // Since you need a project id, an issue id and a view point id, that means that you need to have created a
            // project in that hub first, as well as an issue and a viewpoint for that issue.
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/viewpoints/" + viewPointId + "/comments";
            return Perform_Create(connStr, comment);
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

