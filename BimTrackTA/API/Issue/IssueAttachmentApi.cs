using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class IssueAttachmentApi : ApiBase
    {
        public List<Issue.Attachment> GetIssueAttachmentList(int hubId, int projectId, int issueId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + ISSUE_ROUTE + "/" +
                             issueId + ATTACH_ROUTE;
            return Perform_Get<List<Issue.Attachment>>(connStr);
        }

        public void CreateIssueAttachment(int hubId, int projectId, int issueId, string fileName, string pathToAttachment)
        {
            // Since we are using Multipart, you need to provide a file name and a filepath.
            //
            // Since you need a project id and an issue id, that means that you need to have created a project in that
            // hub first, as well as an issue for that project.
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + ISSUE_ROUTE + "/" +
                             issueId + ATTACH_ROUTE;
            Perform_Create_Multipart(connStr, fileName, pathToAttachment);
        }
        
        public bool DeleteIssueAttachment(int hubId, int projectId, int issueId, int attachmentId)
        {
            string connStr = API_VERSION + HUB_ROUTE + "/" + hubId + PROJ_ROUTE + "/" + projectId + ISSUE_ROUTE + "/" + issueId +
                             ATTACH_ROUTE + "/" + attachmentId;
            IRestResponse response = Perform_Delete(connStr);

            return response.IsSuccessful;
        }
    }
}

