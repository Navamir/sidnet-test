using NUnit.Framework;
using OpenQA.Selenium;
using SidnetTest.GeneralHelpers;
using SidnetTest.GeneralHelpers.TestFunction;
using System.Configuration;

namespace SidnetTest.TestCases
{
    internal class LogInAndCheckIfAdminRights
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

            logInHelper.DoLogIn(driver, ConfigValues.AgentUserName, ConfigValues.AdminPassword);

            Assert.IsTrue(driver.FindElements(By.Id("nav-Dashboard")).Count == 1);
            Assert.IsTrue(driver.FindElements(By.Id("nav-Admin")).Count == 1);

            logOutHelper.DoLogOut(driver);
        }
    }
}
