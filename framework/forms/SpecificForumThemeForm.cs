using OpenQA.Selenium;

namespace demo.framework.forms
{
    internal class SpecificForumThemeForm : BaseForm {
        public SpecificForumThemeForm(string name)
            :base(By.XPath("//h1[contains(text(), '"+name+"')]"), name+"Talk")
        {
        }
    }
}
