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

            Assert.IsTrue(driver.FindElements(PageHandlers.NavigationDashboard).Count == 1,
                "Was expecting to be logged but user dashboard is not present.");
            Assert.IsTrue(driver.FindElements(PageHandlers.AdminDashboard).Count == 1,
                "Was expecting to be normal user with admin rights but admin panel is not present.");

            logOutHelper.DoLogOut(driver);
        }
    }
}
