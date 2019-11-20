using NUnit.Framework;
using SeleniumTest;

namespace Tests
{
    public class ProjectTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreateNewProjectTest()
        {
            ProjectCreationTest prjTest = new ProjectCreationTest();
            
            prjTest.CreateNewProject("MyTestProject");
        }
    }
}