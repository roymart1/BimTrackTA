using SeleniumTest.Common;
using SeleniumTest.PageObjects;
using SeleniumTest.PageObjects.Hub;
using SeleniumTest.PageObjects.Project;
using SeleniumTest.PageObjects.ScreenDecorator;

namespace SeleniumTest
{
    public class RemoveAllUsersTest : SeleniumTestBase
    {
        public void RemoveAllUsers()
        {
            KeyChain kc = CTX.keyChain;
            
            CTX.driver.Url = kc.UrlBimTrack;

            BtLogin login = new BtLogin();
            login.LogIn(kc.LoginUsername, kc.LoginPassword);
            
            BtHubsTracks btHubsTracks = new BtHubsTracks();
            ProjectList prjList = btHubsTracks.OpenHubByName(kc.HubName);
            
            prjList.SelectProject(kc.DefaultProject);
            
            MainProject mainProject = new MainProject();

            SideBarMenu sideBarMenu = mainProject.GetSidebarMenu();
            sideBarMenu.ClickMenuItem("Hub Settings");
            HubSettings hubSettings = new HubSettings();

            UserManagementForm userForm = new UserManagementForm(hubSettings.GetRoot());
            userForm.RemoveAllUsers();
       
            CTX.driver.Close();   
        }
        

    }
}