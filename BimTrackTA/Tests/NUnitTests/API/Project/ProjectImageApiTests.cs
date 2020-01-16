using BimTrackTA.Common.WebDriver;
using BimTrackTA.API;
using NUnit.Framework;
using SeleniumTest.BusinessObjects;

namespace BimTrackTA.Tests.NUnitTests.API
{
    public class ProjectImageApiTests : GeneralTestBase
    {
        
        [Test]
        public void Test1_UpdateImage()
        {
            int hubId = __GetHubRandom();
            int projectId = __GetProjectRandom(hubId, "AutoUpdatedNewPrj", true);
            
            string imageName = "AutoImageTest.jpg";
            string filePath = "../../../Tests/NUnitTests/API/TestResources/Colors.jpg";
            
            ProjectImageApi projectImageApi = new ProjectImageApi();
            projectImageApi.UpdateProjectImage(hubId, projectId, imageName, filePath);
        }
    }
}