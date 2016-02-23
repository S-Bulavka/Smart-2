using demo.framework.Elements;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    internal class ResourcesForm : BaseForm {

        private readonly Link _themeHeaders = new Link(By.XPath("//a[contains(@class, 'gray')]"), "Most Popular themes");
  
        public ResourcesForm()
            : base(By.ClassName("m_header"), "All Forums")
        {
        }

        public void ChooseRandomForum(string[] expectedText)
        {
            _themeHeaders.ClickRandomElementFromTheList();
        }
    }
}
