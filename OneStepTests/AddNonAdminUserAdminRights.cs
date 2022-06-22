using NUnit.Framework;
using OpenQA.Selenium;
using SidnetTest.GeneralHelpers;
using SidnetTest.GeneralHelpers.TestFunction;

namespace SidnetTest.TestCases
{
    internal class AddNonAdminUserAdminRights
    {
        IWebDriver driver;
        LogIn logInHelper;
        LogOut logOutHelper;

        public void Initiate()
        {
            driver = PKTestDriver.PrepareWebDriver();
            logInHelper = new LogIn();
            logOutHelper = new LogOut();
        }

        public void Run()
        {
            Initiate();

            logInHelper.DoLogIn(driver, ConfigValues.AdminUserName, ConfigValues.AdminPassword);

            CheckIfNotAlreadyAdmin();
            AddUserAdminRights();
            CheckIfUserIsAdmin();

            logOutHelper.DoLogOut(driver);
        }

        private void CheckIfNotAlreadyAdmin()
        {
            driver.FindElement(PageHandlers.AdminDashboard).Click();
            driver.FindElement(PageHandlers.AdminUserDataModule).Click();
            driver.FindElement(By.LinkText(ConfigValues.AgentUserName)).Click();

            Assert.IsTrue(driver.FindElements(PageHandlers.AdminNameInHyperlink).Count == 0,
                string.Format("Was expecting that {0} have no admin rights.", ConfigValues.AgentUserName));
            driver.FindElement(By.Id("nav-Admin")).Click();
        }

        private void CheckIfUserIsAdmin()
        {
            driver.FindElement(PageHandlers.AdminDashboard).Click();
            driver.FindElement(PageHandlers.AdminUserDataModule).Click();
            driver.FindElement(By.LinkText(ConfigValues.AgentUserName)).Click();

            Assert.IsTrue(driver.FindElements(PageHandlers.AdminNameInHyperlink).Count == 1,
                string.Format("Was expecting that {0} have admin rights.", ConfigValues.AgentUserName));
            driver.FindElement(PageHandlers.AdminDashboard).Click();
        }

        private void AddUserAdminRights()
        {
            driver.FindElement(PageHandlers.AdminUserGroupDataModule).Click();
            IWebElement userList = driver.FindElement(PageHandlers.UsersId);
            userList.FindElement(By.LinkText("agent2 (Agent Test)")).Click();
            driver.FindElement(PageHandlers.ReadWriteCheckboxForAdminRights).Click(); 
            driver.FindElement(PageHandlers.Submit).Click();

            driver.FindElement(PageHandlers.AdminDashboard).Click();
        }
    }
}
