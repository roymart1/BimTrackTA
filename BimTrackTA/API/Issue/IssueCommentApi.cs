using System;
using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common.Exceptions;

namespace BimTrackTA.API
{
    public class IssueCommentApi : ApiBase
    {
        public List<BimComment> GetIssueCommentList(int hubId, int projectId, int issueId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId + "/comments";
            return Perform_Get<List<BimComment>>(connStr);
        }

        public int CreateIssueComment(int hubId, int projectId, int issueId, BimComment comment)
        {
            // Validate that the object is fine
            ValidateOperation(comment);
            
            // Required fields for BimComment object are: 
            //     - Comment (string)
            //
            // Since you need a project id and an issue id, that means that you need to have created a project in that
            // hub first, as well as an issue for that project.
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId
                             + "/comments";
            return Perform_Create(connStr, comment);
        }
        
        public bool DeleteIssueComment(int hubId, int projectId, int issueId, int commentId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/comments/" + commentId;
            IRestResponse response = Perform_Delete(connStr);

            return response.IsSuccessful;
        }

        private void ValidateOperation(BimComment comment)
        {
            if (comment == null) throw new ArgumentNullException(nameof(comment));
            if (comment.Comment == null)
            {
                throw new CustomObjectAttributeException("a comment value", "issue comment");
            }
        }
    }
}

