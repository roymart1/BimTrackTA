using System;
using System.Collections.Generic;
using System.IO;
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
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId);
            
            IssueAttachmentApi issueAttachment = new IssueAttachmentApi();
            List<Issue.Attachment> listAttachment =  issueAttachment.GetIssueAttachmentList(hubId, projectId, issueId);
        }    
        
        [Test]
        public void Test_CreateIssueAttachment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "AttachmentTest");
            string fileName = "AutoAttachment";
            string pathToAttachment = "../../../Tests/NUnitTests/API/TestResources/Attachment.txt";

            IssueAttachmentApi issueAttachment = new IssueAttachmentApi();
            issueAttachment.CreateIssueAttachment(hubId, projectId, issueId, fileName, pathToAttachment);
        }

        [Test]
        public void Test_DeleteIssueAttachment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId);
            int attachmentId = __GetIssueAttachmentRandom(hubId, projectId, issueId, "AutoAttachment");

            IssueAttachmentApi issueAttachment = new IssueAttachmentApi();
            issueAttachment.DeleteIssueAttachment(hubId, projectId, issueId, attachmentId);
        }
    }
}