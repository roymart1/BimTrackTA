using System;
using System.Threading;
using BimTrackTA.Common.WebDriver;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SeleniumTest;
using SeleniumTest.BusinessObjects;
using SeleniumTest.Common;
using SeleniumTest.PageObjects;
using SeleniumTest.PageObjects.Hub;
using SeleniumTest.PageObjects.Project;
using SeleniumTest.PageObjects.ScreenDecorator;


namespace Tests
{
    public class UserTests
    {
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void AddMultipleUsers()
        {
            Console.Out.WriteLine("START ---> " + DateTime.Now.ToString("MMdd_hhmmss"));
            for (int i = 0; i < 39; i++)
            {
                //create a new user                
                AddNewUserTest test1 = new AddNewUserTest();
                test1.createUser();
            }
            Console.Out.WriteLine("END ---> " + DateTime.Now.ToString("MMdd_hhmmss"));

        }        

        [Test]
        public void AddSingleUsers()
        {
            Console.Out.WriteLine("START ---> " + DateTime.Now.ToString("MMdd_hhmmss"));

            AddNewUserTest test1 = new AddNewUserTest();
            test1.createUser();
            
            Console.Out.WriteLine("END ---> " + DateTime.Now.ToString("MMdd_hhmmss"));

        }        

        
        [Test]
        public void DeleteAllUsers()
        {
            var removeAll = new RemoveAllUsersTest();
            removeAll.RemoveAllUsers();
        } 
        
        
        [Test]
        public void WriteToConsoleTest()
        {
            Console.WriteLine("---->>>> Console.WriteLine");
            Console.Out.WriteLine("---->>>> Console.Out.WriteLine");
        } 
        
        
        
    }
}