using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SidnetTest.GeneralHelpers.TestFunction;
using SidnetTest.GeneralHelpers;
using System.Configuration;

namespace SidnetTest.TestCases
{
    internal class LogInAsAdministrator
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

            Assert.IsTrue(driver.FindElements(PageHandlers.NavigationDashboard).Count == 1,
                "Was expecting to be logged but user dashboard is not present.");
            Assert.IsTrue(driver.FindElements(PageHandlers.AdminDashboard).Count == 1,
                "Was expecting to be logged as admin but admin dashboard is not present.");

            logOutHelper.DoLogOut(driver);
        }
    }
}
