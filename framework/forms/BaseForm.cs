using System;
using OpenQA.Selenium;
using demo.framework.Elements;

namespace demo.framework.forms
{
    public class BaseForm : BaseEntity
    {
        private readonly string _name;
        private readonly By _locator;
        protected BaseForm(By locator, string name)
        {   _locator = locator;
            _name = name;
            AssertIsPresent();
        }

        private void AssertIsPresent()
        {
            BaseElement.WaitForElementPresent(_locator, "Form " + _name);
            Log.Info(string.Format("Form '{0}' has appeared", _name));
        }

        public void CheckTextOnForm(string text)
        {
            BaseElement.WaitForElementPresent(By.XPath("//*[contains(.,'" + text + "')]"), text);
            Log.Info(string.Format("Text '{0}' is shown on the page", text));
        }
    }
}
