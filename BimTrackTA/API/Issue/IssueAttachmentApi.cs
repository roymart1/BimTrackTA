using System.Collections.Generic;
using RestSharp;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.API
{
    public class IssueAttachmentApi : ApiBase
    {
        public List<Issue.Attachment> GetIssueAttachmentList(int hubId, int projectId, int issueId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId + "/attachments";
            return Perform_Get<List<Issue.Attachment>>(connStr);
        }

        public void CreateIssueAttachment(int hubId, int projectId, int issueId, string fileName, string pathToAttachment)
        {
            // Since we are using Multipart, you need to provide a file name and a filepath.
            //
            // Since you need a project id and an issue id, that means that you need to have created a project in that
            // hub first, as well as an issue for that project.
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId
                             + "/attachments";
            Perform_Create_Multipart(connStr, fileName, pathToAttachment);
        }
        
        public bool DeleteIssueAttachment(int hubId, int projectId, int issueId, int attachmentId)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId 
                             + "/attachments/" + attachmentId;
            IRestResponse response = Perform_Delete(connStr);

            return response.IsSuccessful;
        }
    }
}

