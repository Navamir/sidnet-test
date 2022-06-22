using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidnetTest.GeneralHelpers
{
    public class PKTestDriver
    {
        public static IWebDriver PrepareWebDriver()
        {
            IWebDriver driver = new ChromeDriver(@"E:\Repo\SidnetTest\drivers\");
            driver.Url = "https://otrs-test.sidnet.info/otrs/index.pl";
            driver.Manage().Window.Maximize();
            return driver;
        }

    }
}
