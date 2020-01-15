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
        [Test, Order(1)]
        public void Test_CreateIssueAttachment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            // We need to create an issue for us to be able to create its attachment
            Issue issue = new Issue
            {
                Title = "IssueAttachmentTest",
                TypeId = __GetProjectTypeRandom(hubId, projectId),
                PriorityId = __GetProjectPriorityRandom(hubId, projectId),
                StatusId = __GetProjectStatusRandom(hubId, projectId)
            };
            IssueApi issueApi = new IssueApi();
            int issueId = issueApi.CreateIssue(hubId, projectId, issue);
            
            // Now that it's created, we can create its attachment 
            string fileName = "AutoAttachment.txt";
            string pathToAttachment = "../../../Tests/NUnitTests/API/TestResources/Attachment.txt";

            IssueAttachmentApi issueAttachment = new IssueAttachmentApi();
            issueAttachment.CreateIssueAttachment(hubId, projectId, issueId, fileName, pathToAttachment);
        }

        [Test, Order(2)]
        public void Test_GetIssueAttachmentList()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "IssueAttachmentTest");
            
            IssueAttachmentApi issueAttachment = new IssueAttachmentApi();
            issueAttachment.GetIssueAttachmentList(hubId, projectId, issueId);
        }  
        
        [Test, Order(3)]
        public void Test_DeleteIssueAttachment()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            int issueId = __GetIssueRandom(hubId, projectId, "IssueAttachmentTest");
            int attachmentId = __GetIssueAttachmentRandom(hubId, projectId, issueId, "AutoAttachment.txt");

            IssueAttachmentApi issueAttachment = new IssueAttachmentApi();
            issueAttachment.DeleteIssueAttachment(hubId, projectId, issueId, attachmentId);
            
            // We now need to delete the temporary issue to clean up the test
            IssueApi issueApi = new IssueApi();
            issueApi.ArchiveIssue(hubId, projectId, issueId);
            IssueArchivedApi issueArchivedApi = new IssueArchivedApi();
            issueArchivedApi.DeleteArchivedIssue(hubId, projectId, issueId);
        }
    }
}