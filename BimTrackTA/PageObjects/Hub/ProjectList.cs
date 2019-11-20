using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Events;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.Common;

namespace SeleniumTest.PageObjects.Hub
{
    public class ProjectList : MainHub
    {
        private string projectFrameId = "projects";

        private string add_button_name = "btnCreateProjectModal";
        private string root_id = "form-projects";
        

        private IWebElement weProjectFrame = null;
        private ReadOnlyCollection<IWebElement> listProjectWe = null;


        private IWebElement GetRoot()
        {
            return CTX.driver.FindElement(By.Id(this.root_id));
        }
        
        public ProjectList()
        {
            this.InitLocators();
        }

        private void InitLocators()
        {
            weProjectFrame = CTX.driver.FindElement(By.Id(projectFrameId));
            while (listProjectWe == null || listProjectWe.Count == 0)
            {
                try
                {
                    listProjectWe = weProjectFrame.FindElements(By.XPath(".//div[@class='project-item']"));
                }
                catch(Exception)
                {
                }
            }
            
        }

        public void SelectProject(string szProjetName)
        {
            foreach (var weProject in listProjectWe)
            {
                if (weProject.Text.ToLower() == szProjetName.ToLower())
                {
                    weProject.Click();
                    return;
                }
            }
            throw new Exception("Project provided was not found");
            
//            listProjectWe[0].Click();
        }


        public AddProjectDialog ClickAddNewProject()
        {
            IWebElement wTemp = this.GetRoot().FindElement(By.Name(this.add_button_name));
            wTemp.Click();
            //  todo: Assert the click behaviour
            return new AddProjectDialog();
        }

        public class AddProjectDialog
        {
            private string edit_projectName_id = "project-creation-modal-name";
            private string select_projectTemplate_id = "SelectedProjectTemplate";
            private string button_cancel_id = "project-creation-modal-cancel-button";
            private string button_create_id = "project-creation-modal-submit-button";
                
            
            public void FillProjectForm(string name)
            {
                WebDriverWait waiting = new WebDriverWait(CTX.driver, TimeSpan.FromSeconds(10));
                waiting.Until(ExpectedConditions.ElementExists(By.Id(this.edit_projectName_id)));
                
                WebDriverWait wait = new WebDriverWait(CTX.driver, TimeSpan.FromSeconds(3));
                wait.Until(ExpectedConditions.ElementIsVisible(By.Id(this.edit_projectName_id)));

                IWebElement weTemp = WebElementHelper.SafeFindElementDisplayed(By.Id(this.edit_projectName_id));

                if (weTemp == null)
                {
                    Console.Error.WriteLine("Project creation dialog: Name text field not present");
                }
                
                //IWebElement weTemp =  CTX.driver.FindElement(By.Id(this.edit_projectName_id));
                weTemp.SendKeys(name);
            }    

            public void ClickCreateButton()
            {
                IWebElement weTemp = WebElementHelper.SafeFindElementDisplayed(By.Id(this.button_create_id));
//                CTX.driver.FindElement(By.Id(this.button_create_id)).Click();
                weTemp.Click();
            }


        }
        
    }
}