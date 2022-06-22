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

            Assert.IsTrue(driver.FindElements(By.Id("nav-Dashboard")).Count == 1);
            Assert.IsTrue(driver.FindElements(By.Id("nav-Admin")).Count == 0);

            logOutHelper.DoLogOut(driver);
        }
    }
}
