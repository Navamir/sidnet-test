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

            Assert.IsTrue(driver.FindElements(By.Id("nav-Dashboard")).Count == 1);
            Assert.IsTrue(driver.FindElements(By.Id("nav-Admin")).Count == 1);

            logOutHelper.DoLogOut(driver);
        }
    }
}
