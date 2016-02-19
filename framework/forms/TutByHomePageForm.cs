using demo.framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    public class TutByHomePageForm : BaseForm {

	
        private readonly Link _lnkJob = new Link(By.XPath("//a[contains(@class,'topbar__link')][contains(@title,'Работа')]"), "Job link");
        private readonly Link _lnkUserName = new Link(By.XPath("//span[contains(@class,'uname')]"), "User Name link");
        private readonly Link _lnkProfile = new Link(By.XPath("//a[contains(@href, 'http://profile.tut.by/')]"), "My Profile link");

        private readonly Button _btnLogin = new Button(By.XPath("//a[contains(@class,'enter')]"), "Login button");
        private readonly Button _btnLoginOnPopUp = new Button(By.XPath("//input[contains(@class,'button auth__enter')]"), "Login button");

        private readonly TextBox _txbLogin = new TextBox(By.XPath("//input[contains(@class,'i-p')][contains(@name,'login')]"), "Login text box");
        private readonly TextBox _txbPassword = new TextBox(By.XPath("//input[contains(@class,'i-p')][contains(@name,'password')]"), "Password text box");

        private readonly PopUp _puLogin = new PopUp(By.XPath("//div[contains(@class,'b-popup-i')]"), "Authorization Pop up");

           
        public TutByHomePageForm()
            : base(By.ClassName("header-logo"), "Tut by")
        {
        }
        
        public void GoToJob()
        {
            _lnkJob.Click();
        }

        public void GoToLoginPopUp()
        {
            _btnLogin.Click();
           Assert.AreEqual(true, _puLogin.IsPresent());
        }
        public void FillInLoginPopUp(string login, string password, string firstName, string lastName)
        {
            _txbLogin.SetText(login);
            _txbPassword.SetText(password);
     
            _btnLoginOnPopUp.Click();
            
            string userName = string.Concat(firstName, " ", lastName);
            Assert.AreEqual(userName, _lnkUserName.GetText());
        }

        public void GoToProfile()
        {
            _lnkUserName.Click();
            _lnkProfile.Click();
        }
    }
}
