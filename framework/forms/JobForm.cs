using demo.framework.Elements;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    public class JobForm : BaseForm {

        private readonly TextBox _txbSearchJobBar = new TextBox(By.XPath("//input[contains(@class, 'Navi-SearchSelector')]"), "Job Search bar"); 
        private readonly Button _btnSubmitSearch = new Button(By.XPath("//button[contains(@class, 'bloko-button                            bloko-button_primary                            bloko-button_stretched')]"), "Search button"); 

        public JobForm()
            : base(By.XPath("//span[contains(@class,'navi-logo navi-logo_jobs-tut-by')][contains(@title,'Работа TUT')]"), "Job Page")
        {
        }

        public void SearchFor(string text)
        {

            _txbSearchJobBar.SetText(text);
            _btnSubmitSearch.Click();
            Browser.WaitForPageToLoad();

        }
    }
}
