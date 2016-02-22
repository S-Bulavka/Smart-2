using OpenQA.Selenium;

namespace demo.framework.forms
{
    class AfishaTodayForum : BaseForm
    {
        //private readonly Link _lnkWhereToGoToday = new Link(By.XPath("//a[contains(text(),'Куда сходить сегодня')]"), "Where To Go Today link");

        public AfishaTodayForum()
            : base(By.XPath("//h1[contains(text(), 'Афиша на сегодня')]"), "Afisha for Today page")
        {
        }

       

    }
}
