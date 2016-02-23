using demo.framework.Elements;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    internal class AfishaForum : BaseForm
    {
        private readonly Link _lnkWhereToGoToday = new Link(By.XPath("//a[contains(text(),'Куда сходить сегодня')]"), "Where To Go Today link");
       
        public AfishaForum()
            : base(By.XPath("//div[contains(@class, 'logo')]/a[contains(text(), 'АФИША')]"), "Afisha page")
        {
        }

        public void GoToWhereToGoToday()
        {
            _lnkWhereToGoToday.Click();
        }

    }
}
