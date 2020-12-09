using Ciceksepeti.UITestProject.Models.Cicekcsepeti.Login;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;

namespace Ciceksepeti.UITestProject.Tests.Ciceksepeti.Login
{
    [Binding]
    public sealed class LoginTest
    {
        private IWebDriver Driver { get; set; }
        private LoginModel loginModel;
        private readonly ScenarioContext context;
        public LoginTest(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }
        [BeforeScenario]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("start-maximized");
            options.AddArgument("disable-popup-blocking");
            options.AddArgument("disable-notifications");
            options.AddArgument("test-type");
            Driver = new ChromeDriver(options);
            loginModel = new LoginModel(Driver);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        [StepDefinition("'(.*)' sitesine gidilir")]
        public void OpenLoginPage(string url)
        {
            loginModel.OpenLoginPage(url);
        }

        [StepDefinition("Email alanına '(.*)' yazılır")]
        public void EnterEmail(string userEmail)
        {
            loginModel.EnterEmail(userEmail);
        }

        [StepDefinition("Password alanına '(.*)' yazılır")]
        public void EnterPassword(string password)
        {
            loginModel.EnterPassword(password);
        }

        [StepDefinition("Sign In butonuna tıklanır")]
        public void ClickSignInButton()
        {
            loginModel.ClickSignInButton();
        }

        [StepDefinition("Giriş yapıldığı görülür")]
        public void CheckLogin()
        {
           Assert.IsTrue(loginModel.IsMyAccountVisible(),"Login olunamadı!");
        }

        [StepDefinition("'(.*)' uyarısı geldiği görülür")]
        public void CheckAlertMessage(string alertText)
        {
            Assert.IsTrue(loginModel.GetAlertMessage().Contains(alertText), "Uyarı doğru gelmedi!");
        }


        [StepDefinition("Password alanının gizli olduğu görülür")]
        public void CheckIsPasswordShowDisabled()
        {
            Assert.IsTrue(loginModel.GetPasswordShowButtonValue().Contains("password"), "Password alanın gizli gelmedi!");
        }

        [StepDefinition("ShowPassword butonuna tıklanır")]
        public void ClickShowPasswordButton()
        {
            loginModel.ClickShowPasswordButton();
        }

        [StepDefinition("Password alanının gizlenmediği görülür")]
        public void ControlIPasswordShowEnabled()
        {
            Assert.IsTrue(loginModel.GetPasswordShowButtonValue().Contains("text"), "Password alanın görünür gelmedi!");
        }

        [StepDefinition("Forgot Password butonuna tıklanır")]
        public void ClickForgotPasswordButton()
        {
            loginModel.ClickForgotPasswordButton();
        }

        [StepDefinition("Mail alanına '(.*)' yazılır")]
        public void EnterForgotMail(string forgotMail)
        {
            loginModel.EnterForgotMail(forgotMail);
        }

        [StepDefinition("Send butonuna tıklanır")]
        public void ClickSendButton()
        {
            loginModel.ClickSendButton();
        }

        [StepDefinition("(.*) bilgilendirme mesajı geldiği görülür")]
        public void CheckForgotInfoMessage(string forgotInfoMessage)
        {
            Assert.IsTrue(loginModel.GetForgotInfoMessage().Contains(forgotInfoMessage), "Şifremi unuttum mesajı doğru gelmedi!");
        }

        [StepDefinition("Email alanında (.*) uyarı mesajı geldiği görülür")]
        public void ControlEmptyEmailAlertMessage(string emptyEmailAlertMessage)
        {
            Assert.IsTrue(loginModel.GetEmptyEmailAlertMessage().Contains(emptyEmailAlertMessage), "E mail uyarı mesajı eşleşmedi!");
        }

        [StepDefinition("Password alanında (.*) uyarı mesajı geldiği görülür")]
        public void ControlEmptyPasswordAlertMessage(string emptyPasswordAlertMessage)
        {
            Assert.IsTrue(loginModel.GetEmptyPasswordAlertMessage().Contains(emptyPasswordAlertMessage), "Password uyarı mesajı eşleşmedi!");
        }

        #region LoginValidation
        [StepDefinition("(.*) elementinin bulunduğu görülür")]
        public void ControlIsLoginElementVisible(string elementName)
        {
            Assert.IsTrue(loginModel.IsElementVisible(elementName), elementName+"elementi bulunamadı!");
        }

        #endregion

        [StepDefinition("(.*) saniye beklenir")]
        public void Wait(int second)
        {
            loginModel.Wait(second);
        }


        [AfterScenario]
        public void TearDown()
        {
            Driver.Quit();
        }
    }
}
