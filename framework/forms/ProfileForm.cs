using demo.framework.Elements;
using OpenQA.Selenium;
using NUnit.Framework;

namespace demo.framework.forms
{
    public class ProfileForm : BaseForm {

        private readonly TextBox _txbFirstName = new TextBox(By.XPath("//input[contains(@name, 'FirstName')]"), "First Name text box");
        private readonly Button _btnRemember = new Button(By.XPath("//input[contains(@id,'updateBtn')]"), "Remember button");
        private readonly Label _lblSuccessMesssage = new Label(By.XPath("//div[contains(@id,'idChangeMessage')]"), "Successfully Updating message");

      
        public ProfileForm()
            : base(By.ClassName("w254v"), "My Profile")
        {
        }

        public void ChangeFirstName(string newFirstName)
        {
            _txbFirstName.SetText(newFirstName);
            _btnRemember.Click();

            Assert.AreEqual(true, _lblSuccessMesssage.IsPresent());
        }


    }
}
