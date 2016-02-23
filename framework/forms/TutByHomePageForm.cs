using demo.framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    public class TutByHomePageForm : BaseForm {

        private readonly Link _lnkUserName = new Link(By.XPath("//span[contains(@class,'uname')]"), "User Name link");
        private readonly Link _lnkProfile = new Link(By.XPath("//a[contains(@href, 'http://profile.tut.by/')]"), "My Profile link");
        private readonly Link _lnkForums = new Link(By.XPath("//a[contains(@class, 'topbar-burger')]"), "Forums link");
        private readonly Link _lnkAllForums = new Link(By.XPath("//li[contains(@class, 'topbar__li mores')]"), "All Forums link");
        private readonly Link _lnkTalksForum = new Link(By.XPath("//a[contains(@title, 'Форумы')]"), "Talks Forum link");
        private readonly Link _lnkAfishaForum = new Link(By.XPath("//a[contains(@title, 'Афиша')]"), "Afisha Forum link");
        private readonly Link _lnkCurrency = new Link(By.XPath("//a[contains(@data-ua-hash, 'widget_finance')]"), "Best course of exchange link");
        private readonly Link _lnkWeather = new Link(By.XPath("//a[contains(@data-ua-hash, 'widget_weather')]"), "Weather link");

        private readonly Button _btnLogin = new Button(By.XPath("//a[contains(@class,'enter')]"), "Login button");
        private readonly Button _btnLoginOnPopUp = new Button(By.XPath("//input[contains(@class,'button auth__enter')]"), "Login button");

        private readonly TextBox _txbLogin = new TextBox(By.XPath("//input[contains(@class,'i-p')][contains(@name,'login')]"), "Login text box");
        private readonly TextBox _txbPassword = new TextBox(By.XPath("//input[contains(@class,'i-p')][contains(@name,'password')]"), "Password text box");

        private readonly PopUp _puLogin = new PopUp(By.XPath("//div[contains(@class,'b-popup-i')]"), "Authorization Pop up");

        public TutByHomePageForm()
            : base(By.ClassName("header-logo"), "Tut by")
        {
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
            
            var userName = string.Concat(firstName, " ", lastName);
            Assert.AreEqual(userName, _lnkUserName.GetText());
        }

        public void GoToProfile()
        {
            _lnkUserName.Click();
            _lnkProfile.Click();
        }

        public void OpenForums()
        {
            _lnkForums.Click();
            Assert.AreEqual(true, _lnkAllForums.IsPresent());
        }

        public void GoToTalks()
        {
            _lnkTalksForum.Click();
        }
        public void GoToAfisha()
        {
            _lnkAfishaForum.Click();
        }
        public void OpenBestCurrencyCources()
        {
            _lnkCurrency.Click();
        }

        public void GoToWeatherViaWidjet()
        {
            _lnkWeather.Click();
        }
    }
}
