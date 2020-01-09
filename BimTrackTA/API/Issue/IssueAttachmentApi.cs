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

        public bool CreateIssueAttachment(int hubId, int projectId, int issueId, string fileName, string pathToAttachment)
        {
            string connStr = "v2/hubs/" + hubId + "/projects/" + projectId + "/issues/" + issueId
                             + "/attachments";
            IRestResponse response =  Perform_Create_Multipart(connStr, fileName, pathToAttachment);
            
            return response.IsSuccessful;
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

