using OpenQA.Selenium;

namespace demo.framework.forms
{
    internal class AfishaTodayForum : BaseForm
    {        
        public AfishaTodayForum()
            : base(By.XPath("//h1[contains(text(), 'Афиша на сегодня')]"), "Afisha for Today page")
        {
        }
    }
}
