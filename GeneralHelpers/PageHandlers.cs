using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SidnetTest.GeneralHelpers
{
    public static class PageHandlers
    {
        #region Generic

        public static By UsersId = By.Id("Users");

        public static By UserId = By.Id("User");

        public static By PasswordId = By.Id("Password");

        public static By Submit = By.Id("SubmitAndContinue");

        public static By Login = By.Id("LoginButton");

        public static By Logout = By.Id("LogoutButton");

        #endregion

        #region Navigation dashboards

        public static By NavigationDashboard = By.Id("nav-Dashboard");

        public static By AdminDashboard = By.Id("nav-Admin");

        public static By UserAvatar = By.XPath("//li[@class='UserAvatar']");

        #endregion

        #region Data module

        public static By AdminUserDataModule = By.XPath("//li[@data-module='AdminUser']");

        public static By AdminUserGroupDataModule = By.XPath("//li[@data-module='AdminUserGroup']");

        #endregion

        #region Hyperlinks

        public static By AdminNameInHyperlink = By.XPath("//a[.='admin']");

        #endregion

        #region Table elements

        public static By ReadWriteCheckboxForAdminRights = By.XPath("//input[@name='rw' and @value='2']");

        #endregion
    }
}
