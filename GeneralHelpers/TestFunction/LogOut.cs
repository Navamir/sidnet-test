using OpenQA.Selenium;

namespace SidnetTest.GeneralHelpers.TestFunction
{
    public class LogOut
    {
        public void DoLogOut(IWebDriver driver)
        {
            driver.FindElement(PageHandlers.UserAvatar).Click();
            driver.FindElement(PageHandlers.Logout).Click();

            driver.Close();
        }
    }
}
