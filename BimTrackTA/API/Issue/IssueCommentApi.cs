using System.Collections.Generic;
using Newtonsoft.Json;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class IssueCommentApi : ApiBase
    {
        public List<BimComment> GetIssueCommentList(int hubId, int projectId, int issueId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId + "/comments";
            return Perform_Get<List<BimComment>>(connStr);
        }

        public bool CreateIssueComment(int hubId, int projectId, int issueId, BimComment bimComment)
        {
            // Required fields for BimComment object are: 
            //     - Comment (string)
            //
            // Since you need a project id and an issue id, that means that you need to have created a project in that
            // hub first, as well as an issue for that project.
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId
                             + "/comments";
            IRestResponse response =  Perform_Create(connStr, bimComment);
            
            return response.IsSuccessful;
        }
        
        public bool DeleteIssueComment(int hubId, int projectId, int issueId, int commentId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/comments/" + commentId;
            IRestResponse response = Perform_Delete(connStr);

            return response.IsSuccessful;
        }
    }
}

