using NUnit.Framework;
using System.Collections.Specialized;
using OpenQA.Selenium;
using SidnetTest.GeneralHelpers.TestFunction;
using SidnetTest.GeneralHelpers;
using System.Configuration;

namespace SidnetTest.TestCases
{
    internal class LogInAsNormalUser
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
            logInHelper.DoLogIn(driver, ConfigValues.AgentUserName, ConfigValues.AgentPassword);

            Assert.IsTrue(driver.FindElements(PageHandlers.NavigationDashboard).Count == 1, 
                "Was expecting to be logged but user dashboard is not present.");
            Assert.IsTrue(driver.FindElements(PageHandlers.AdminDashboard).Count == 0, 
                "Was expecting normal user but admin dashbord is present.");

            logOutHelper.DoLogOut(driver);
        }
    }
}
