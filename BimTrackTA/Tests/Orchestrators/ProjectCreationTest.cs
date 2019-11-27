using SeleniumTest.Common;
using SeleniumTest.PageObjects;
using SeleniumTest.PageObjects.Hub;


namespace SeleniumTest
{
    public class ProjectCreationTest : SeleniumTestBase
    {

        public void CreateNewProject(string name)
        {
            KeyChain kc = CTX.keyChain;
            CTX.driver.Url = kc.UrlBimTrack;

            BTLogin login = new BTLogin();
            login.LogIn(kc.LoginUsername, kc.LoginPassword);
            
            BTHubsTracks btHubsTracks = new BTHubsTracks();
            ProjectList prjList = btHubsTracks.OpenHubByName(kc.HubName);

            prjList.ClickMenuItem("Projects");
            ProjectList.AddProjectDialog addProjectDialog = prjList.ClickAddNewProject();
            addProjectDialog.FillProjectForm(name);
            addProjectDialog.ClickCreateButton();
        }
        
        
        
        
    }
}