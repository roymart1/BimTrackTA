using System.Collections.Generic;
using BimTrackTA.API;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{

    public class HubProjectTemplateApiTests : GeneralTestBase
    {
        [Test, Order(1)]
        public void Test_CreateHubProjectTemplate()
        {
            int hubId = __GetHubRandom();
            ProjectTemplateApi projectTemplateApi = new ProjectTemplateApi();
            
            ProjectApi projectApi = new ProjectApi();
            List<Project> listProject =  projectApi.GetHubProjectList(hubId);
            projectTemplateApi.CreateHubProjectTemplate(hubId, listProject[1].Id, "ZenAirport");
        }
        
        [Test, Order(2)]
        public void Test_GetHubProjectTemplates()
        {
            int hubId = __GetHubRandom();
            ProjectTemplateApi prjtemplateApi = new ProjectTemplateApi();
            List<ProjectTemplate> listPrjTemplates = prjtemplateApi.GetHubProjectTemplates(hubId);
        } 

        [Test, Order(3)]
        public void Test_DeleteHubProjectTemplate()
        {
            int hubId = __GetHubRandom();
            int prjTmplId = __GetHubProjectTemplateRandom(hubId, "BimHubSuper");
            
            ProjectTemplateApi projectTemplateApi = new ProjectTemplateApi();

            projectTemplateApi.DeleteHubProjectTemplate(hubId, prjTmplId);
        }
    }
}