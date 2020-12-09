using OpenQA.Selenium;

namespace Ciceksepeti.UITestProject.Models.Cicekcsepeti.Login
{
    public class LoginModel
    {
        private BasePage basePage;
        public LoginModel(IWebDriver driver)
        {
            basePage = new BasePage(driver);
        }
        #region webelements
        By txtEmail = By.Id("EmailLogin");
        By txtpassword = By.Id("Password");
        By btnSignIn = By.XPath("//button[contains(text(),'Sign In')]");
        By btnMyAccount = By.XPath("(//span[contains(text(),'My Account')])[1]");
        By txtalertMessage = By.ClassName("modal-body");
        By btnShowPassword = By.ClassName("js-show-type");
        By btnForgotPassword = By.ClassName("login__forgot-password");
        By txtForgotMail = By.Id("Mail");
        By btnSend = By.ClassName("js-password-recovery-button");
        By txtForgotInfoMessage = By.XPath("//span[@class='password-recovery-result__icon icon-check']");
        By txtEmailAlertMessage = By.Id("EmailLogin-error");
        By txtPasswordAlertMessage = By.Id("Password-error");
        By menuRegion = By.ClassName("container--main-menu");
        By btnFacebook = By.ClassName("login__facebook");
        By btnSignUp = By.ClassName("membership-advantages__button--member-login");
        #endregion
        public void OpenLoginPage(string url)
        {
            basePage.NavigateUrl(url);
        }

        public void EnterEmail(string userEmail)
        {
            basePage.SendKeys(txtEmail, userEmail);
        }

        public void EnterPassword(string userPassword)
        {
            basePage.SendKeys(txtpassword, userPassword);
        }

        public void ClickSignInButton()
        {
            basePage.ClickElement(btnSignIn);
        }

        public bool IsMyAccountVisible()
        {
            return basePage.IsElementVisible(btnMyAccount);
        }

        public string GetAlertMessage()
        {
            return basePage.GetText(txtalertMessage);
        }

        public string GetPasswordShowButtonValue()
        {
            return basePage.GetAttributeValue(txtpassword, "type");
        }

        public void ClickShowPasswordButton()
        {
            basePage.ClickElement(btnShowPassword);
        }

        public void ClickForgotPasswordButton()
        {
            basePage.ClickElement(btnForgotPassword);
        }

        public void EnterForgotMail(string forgotMail)
        {
            basePage.SendKeys(txtForgotMail, forgotMail);
        }

        public void ClickSendButton()
        {
            basePage.ClickElement(btnSend);
        }

        public string GetForgotInfoMessage()
        {
            return basePage.GetText(txtForgotInfoMessage);
        }

        public string GetEmptyEmailAlertMessage()
        {
            return basePage.GetText(txtEmailAlertMessage);
        }

        public string GetEmptyPasswordAlertMessage()
        {
            return basePage.GetText(txtPasswordAlertMessage);
        }

        #region LoginValidation
        bool isElemenVisible;
        public bool IsElementVisible(string elementName)
        {
            isElemenVisible = false;
            switch (elementName)
            {
                case "Menü":
                    isElemenVisible = basePage.IsElementVisible(menuRegion);
                    break;
                case "Email":
                    isElemenVisible = basePage.IsElementVisible(txtEmail);
                    break;
                case "Password":
                    isElemenVisible = basePage.IsElementVisible(txtpassword);
                    break;
                case "SignIn":
                    isElemenVisible = basePage.IsElementVisible(btnSignIn);
                    break;
                case "Forgot Password":
                    isElemenVisible = basePage.IsElementVisible(btnForgotPassword);
                    break;
                case "Sign In with Facebook":
                    isElemenVisible = basePage.IsElementVisible(btnFacebook);
                    break;
                case "SignUp":
                    isElemenVisible = basePage.IsElementVisible(btnSignUp);
                    break;
                default: throw new InvalidElementStateException(elementName);
            }
            return isElemenVisible;

        }
        #endregion

        public void Wait(int second)
        {
            basePage.Wait(second);
        }
    }
}
