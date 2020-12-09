using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Ciceksepeti.UITestProject.Models
{
    public class BasePage
    {

        IWebDriver driver;
        WebDriverWait wait;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
        }

        public IWebElement FindElement(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(by));
            return driver.FindElement(by);
        }
        public void NavigateUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }

        public void ClickElement(By by)
        {
            FindElement(by).Click();
        }

        public void SendKeys(By by, String value)
        {
            FindElement(by).SendKeys(value);
        }

        public void Wait(int second)
        {
            Thread.Sleep(TimeSpan.FromSeconds(second));
        }
        public bool IsElementVisible(By by)
        {
            return FindElement(by).Displayed && FindElement(by).Enabled;
        }

        public string GetText(By by)
        {
            return FindElement(by).Text;
        }

        public string GetAttributeValue(By by,string value)
        {
            return FindElement(by).GetAttribute(value);
        }
    }
}
