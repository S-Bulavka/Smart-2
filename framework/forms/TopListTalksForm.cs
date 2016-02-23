using demo.framework.Elements;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    internal class TopListTalksForm : BaseForm {

        private readonly Link _themeHeaders = new Link(By.XPath("//a[contains(@class, 'gray')]"), "Most Popular themes");
  

    public TopListTalksForm()
        : base(By.XPath("//h1[contains(text(), 'Самые популярные')]"), "Top List of Talks")
        {
        }

    public string ChooseRandomForum()
    {
        _themeHeaders.ClickRandomElementFromTheList();
        return _themeHeaders.RandomText;
    }

    }
}
