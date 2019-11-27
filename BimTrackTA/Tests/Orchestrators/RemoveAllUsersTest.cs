using System;
using System.Threading;
using SeleniumTest.BusinessObjects;
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

            BTLogin login = new BTLogin();
            login.LogIn(kc.LoginUsername, kc.LoginPassword);
            
            BTHubsTracks btHubsTracks = new BTHubsTracks();
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