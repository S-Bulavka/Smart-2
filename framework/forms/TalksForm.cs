using demo.framework.Elements;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    internal class TalksForm : BaseForm {

        private readonly Link _lnkMostPopular = new Link(By.XPath("//a[contains(text(), 'Самые популярные')]"), "The Most Popular link");
  

        public TalksForm()
            : base(By.XPath("//h1[contains(text(), 'Список форумов')]"), "Talks Forum")
        {
        }

        public void GoToMostPopular()
        {
            _lnkMostPopular.Click();
        }
    }
}
