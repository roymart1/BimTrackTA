
using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class HubProjectTemplateAPITests : GeneralTestBase
    {
        [Test]
        public void Test_GetHubProjectTemplates()
        {
            int hubId = __GetHubRandom();
            ProjectTemplateAPI prjtemplateApi = new ProjectTemplateAPI();
            List<ProjectTemplate> listPrjTemplates = prjtemplateApi.GetHubProjectTemplates(hubId);
        }

        [Test]
        public void Test_CreateHubProjectTemplate()
        {
            int hubId = __GetHubRandom();
            ProjectTemplateAPI projectTemplateApi = new ProjectTemplateAPI();
            
            ProjectAPI projectApi = new ProjectAPI();
            List<Project> listProject =  projectApi.GetHubProjectList(hubId);
            projectTemplateApi.CreateHubProjectTemplate(hubId, listProject[0].Id, "ZenSchool");
        }
        

        [Test]
        public void Test_DeleteHubProjectTemplate()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId);
            int prjTmplId = __GetHubProjectTemplateRandom(hubId, projectId, "SuperBuilding");
            
            ProjectTemplateAPI projectTemplateApi = new ProjectTemplateAPI();

            projectTemplateApi.DeleteHubProjectTemplate(hubId, prjTmplId);
        }
        
        


    }
}