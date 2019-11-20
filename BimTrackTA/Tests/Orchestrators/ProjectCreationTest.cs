using SeleniumTest.Common;
using SeleniumTest.PageObjects;
using SeleniumTest.PageObjects.Hub;


namespace SeleniumTest
{
    public class ProjectCreationTest : SeleniumTestBase
    {

        public void CreateNewProject(string name)
        {
            CTX.driver.Url = "https://qa.bimtrack.co/";

            BTLogin login = new BTLogin();
            login.LogIn("zenteliatest@gmail.com", "Z3nt3l1499!");
            
            BTHubsTracks btHubsTracks = new BTHubsTracks();
            ProjectList prjList = btHubsTracks.OpenHubByName("ZenyTest");

            prjList.ClickMenuItem("Projects");
            ProjectList.AddProjectDialog addProjectDialog = prjList.ClickAddNewProject();
            addProjectDialog.FillProjectForm(name);
            addProjectDialog.ClickCreateButton();
        }
        
        
        
        
    }
}