using OpenQA.Selenium;

namespace SidnetTest.GeneralHelpers.TestFunction
{
    public class LogOut
    {
        public void DoLogOut(IWebDriver driver)
        {
            driver.FindElement(By.XPath("//li[@class='UserAvatar']")).Click();
            driver.FindElement(By.Id("LogoutButton")).Click();

            driver.Close();
        }
    }
}
