using OpenQA.Selenium;

namespace SidnetTest.GeneralHelpers.TestFunction
{
    public class LogIn
    {
        public void DoLogIn(IWebDriver driver, string user, string password)
        {
            driver.FindElement(PageHandlers.UserId).SendKeys(user);
            driver.FindElement(PageHandlers.PasswordId).SendKeys(password);
            driver.FindElement(PageHandlers.Login).Click();
        }
    }
}
