using System;
using System.Collections.Generic;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common;
using SeleniumTest.PageObjects;
using SeleniumTest.PageObjects.Hub;
using SeleniumTest.PageObjects.Project;
using SeleniumTest.PageObjects.ScreenDecorator;

namespace SeleniumTest
{
    class AddNewUserTestB : SeleniumTestBase
    {
        
        /*
           Environnement:
            DEV: https://dev.bimtrack.co/en/Login
            QA: https://qa.bimtrack.co/en/Login
            PROD: https://bimtrackapp.co/en/Login (edited) 
         */
        
        public void createUser()
        {
            KeyChain kc = CTX.keyChain;

            CTX.driver.Url = kc.UrlBimtrack;
            
            BTLogin login = new BTLogin();
            login.LogIn(kc.LoginUsername, kc.LoginPassword);
            
            BTHubsTracks btHubsTracks = new BTHubsTracks();
            ProjectList prjList = btHubsTracks.OpenHubByName(kc.HubName);
            
            prjList.SelectProject(kc.DefaultProject);
            
            MainProject mainProject = new MainProject();

            SideBarMenu sideBarMenu = mainProject.GetSidebarMenu();
            sideBarMenu.ClickMenuItem("Hub Settings");
            HubSettings hubSettings = new HubSettings();
            UserManagementForm userForm = hubSettings.ClickButtonAddUser();

            var emailSuffix = BimTrackUser.GetNewUserSuffix();
            var email = BimTrackUser.GetUniqueUserEmail(emailSuffix);
            if (userForm.AddNewUser(new BimTrackUser(email, true)))
            {
                // PROCESS EMAIL
                BimEmailProcessor proc = new BimEmailProcessor();
                string szLink = null;
                while (szLink == null)
                {
                    szLink = proc.GetLatestActivationForUser(emailSuffix);    
                    Console.Out.WriteLine("Loop waiting");
                    Thread.Sleep(1500);
                }
            
                Console.Out.WriteLine("SzLink == " + szLink);
                CTX.driver.Close();  
            
                // Complete the user creation
                new CompleteUserFormTest().ActivateUser(szLink);
            
                //hubSettings.FillNewUserInformation(userSuffix, true);

                Thread.Sleep(1500);
            }

            CTX.driver.Close();   
        }
    }
}