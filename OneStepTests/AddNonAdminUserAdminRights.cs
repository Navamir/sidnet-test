using NUnit.Framework;
using OpenQA.Selenium;
using SidnetTest.GeneralHelpers;
using SidnetTest.GeneralHelpers.TestFunction;
using System.Configuration;

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
            driver.FindElement(By.Id("nav-Admin")).Click();
            driver.FindElement(By.XPath("//li[@data-module='AdminUser']")).Click();
            driver.FindElement(By.LinkText("agent2")).Click();

            Assert.IsTrue(driver.FindElements(By.XPath("//a[.='admin']")).Count == 0);
            driver.FindElement(By.Id("nav-Admin")).Click();
        }

        private void CheckIfUserIsAdmin()
        {
            driver.FindElement(By.Id("nav-Admin")).Click();
            driver.FindElement(By.XPath("//li[@data-module='AdminUser']")).Click();
            driver.FindElement(By.LinkText("agent2")).Click();

            Assert.IsTrue(driver.FindElements(By.XPath("//a[.='admin']")).Count == 1);
            driver.FindElement(By.Id("nav-Admin")).Click();
        }

        private void AddUserAdminRights()
        {
            driver.FindElement(By.XPath("//li[@data-module='AdminUserGroup']")).Click();
            IWebElement userList = driver.FindElement(By.Id("Users"));
            userList.FindElement(By.LinkText("agent2 (Agent Test)")).Click();
            driver.FindElement(By.XPath("//input[@name='rw' and @value='2']")).Click(); 
            driver.FindElement(By.Id("SubmitAndContinue")).Click();

            driver.FindElement(By.Id("nav-Admin")).Click();
        }
    }
}
