using demo.framework.Elements;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    public class TutSearchForm : BaseForm {

	
        private readonly Link _lnkJob = new Link(By.XPath("//a[contains(@class,'topbar__link')][contains(@title,'Работа')]"), "Job link");
   
                   
        public TutSearchForm()
            : base(By.Id("search_from_str"), "Tut by")
        {
        }
        
        public void GoToJob()
        {
            _lnkJob.Click();
        }
    }
}
