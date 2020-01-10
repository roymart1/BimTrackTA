using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectImageApiTests : GeneralTestBase
    {
        
        [Test]
        public void Test_UpdateImage()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj");
            
            string imageName = "AutoImageTest";
            string filePath = "../../../Tests/NUnitTests/API/TestResources/Colors.jpg";
            
            ProjectImageApi projectImageApi = new ProjectImageApi();
            projectImageApi.UpdateProjectImage(hubId, projectId, imageName, filePath);
        }
    }
}