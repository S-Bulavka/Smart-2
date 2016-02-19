using demo.framework.Elements;
using OpenQA.Selenium;
using NUnit.Framework;

namespace demo.framework.forms
{
    public class ProfileForm : BaseForm {

        private readonly TextBox _txbFirstName = new TextBox(By.XPath("//input[contains(@name, 'FirstName')]"), "First Name text box");
       
        public ProfileForm()
            : base(By.ClassName("w254v"), "My Profile")
        {
        }

        public void ChangeFirstName(string newFirstName)
        {
            _txbFirstName.SetText(newFirstName);
        }


    }
}
