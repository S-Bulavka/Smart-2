using demo.framework.Elements;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    internal class WeatherForum : BaseForm
    {
        private readonly Link _lnkDetail = new Link(By.XPath("//a[contains(text(),'Подробно')]"), "Detail link");
        private readonly Label _tableWeekDetail = new Label(By.XPath("//div[contains(@class, 'b-future tab-pane active')]"), "Week Detail table");

        private readonly TextBox _txbSearch = new TextBox(By.XPath("//input[contains(@name,'str')]"), "Search text box");
        private readonly Button _btnSearch = new Button(By.XPath("//input[contains(@value,'Найти')]"), "Search button");

       
        public WeatherForum()
            : base(By.XPath("//div[contains(@class, 'logo')]/a[contains(text(), 'ПОГОДА')]"), "Weather page")
        {
        }

        public void GoToDetail()
        {
            _lnkDetail.Click();
            _tableWeekDetail.IsPresent();
        }
  
        public void SearchFor(string text)
        {
            _txbSearch.SetText(text);

            _btnSearch.Click();
            Browser.WaitForPageToLoad();

            var lblWeatherInCity = new Label(By.PartialLinkText(text), "Weather In City '" + text+"' label");
            lblWeatherInCity.IsPresent();
        }

    }
}
