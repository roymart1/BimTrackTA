using System.Collections.Generic;
using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class IssueAttachmentApiTests : GeneralTestBase
    {
        [Test]
        public void Test_GetIssueAttachmentList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            
            IssueAttachmentApi issueAttachment = new IssueAttachmentApi();
            List<Issue.Attachment> listAttachment =  issueAttachment.GetIssueAttachmentList(hubId, projectId, issueId);
        }    
        
        [Test]
        public void Test_CreateIssueAttachment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            
            IssueAttachmentApi issueAttachment = new IssueAttachmentApi();
            issueAttachment.CreateIssueAttachment(hubId, projectId, issueId, "AutoIssueAttachment");
        }

        [Test]
        public void Test_DeleteIssueAttachment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int issueId = __GetIssueRandom(hubId, projectId);
            int attachmentId = __GetIssueAttachmentRandom(hubId, projectId, issueId);

            IssueAttachmentApi issueAttachment = new IssueAttachmentApi();
            issueAttachment.DeleteIssueAttachment(hubId, projectId, issueId, attachmentId);
        }
    }
}