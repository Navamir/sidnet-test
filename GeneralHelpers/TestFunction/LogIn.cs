using OpenQA.Selenium;

namespace SidnetTest.GeneralHelpers.TestFunction
{
    public class LogIn
    {
        public void DoLogIn(IWebDriver driver, string user, string password)
        {
            driver.FindElement(By.Id("User")).SendKeys(user);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.Id("LoginButton")).Click();
        }
    }
}
