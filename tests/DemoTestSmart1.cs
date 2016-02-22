using System.Linq;
using NUnit.Framework;
using demo.framework;
using demo.framework.forms;

namespace demo.tests
{
   [TestFixture]
    public class DemoTestSmart1 : BaseTest
    {
       private const string Login = "kaktusflash";
       private const string Password = "solnyhko";
       private const string FirstName = "123";
       private const string NewFirstName = "123new";
       private const string LastName = "456";
       private double InitialAmount = 21000.00;
       private double InitialAmount2 = 100000.00;
       private const string City= "Витебск";
       private const string SearchText = "специалист по тестированию";
       private readonly string[] _arrayOfVerifiedWords = new string[] { "специалист по тестированию", 
                                                "Cпециалист по тестированию", 
                                                "Тестировщик",
                                                "тестировщик", 
                                                "QA Engineer", 
                                                "QA engineer",
                                                "qa",
                                                "Tester", 
                                                "tester", 
                                                "тестирования",
                                                "тестированию",
                                                "QA",
                                                "тестировщиком" };

       [Test]
        public void ChangeFirstNameOfUserTest()
        {
           Log.Step();
           var testForm = new TutByHomePageForm();
            
           Log.Step();
           testForm.GoToLoginPopUp();

           Log.Step();
           testForm.FillInLoginPopUp(Login, Password, FirstName, LastName);
           
           Log.Step();
           testForm.GoToProfile();

          // Log.Info(Browser.GetDriver().PageSource);
           Log.Info(Browser.GetDriver().Title);
           Log.Info(Browser.GetDriver().Url);


           Browser.GetDriver().SwitchTo().Window(Browser.GetDriver().WindowHandles.Last());
           Log.Info(Browser.GetDriver().Title);
           Log.Info(Browser.GetDriver().Url);

           Log.Step();
           var myProfileForm = new ProfileForm();

           Log.Step();
           myProfileForm.ChangeFirstName(NewFirstName);
        }

       [Test]
       public void OpenRandomCatalogTest()
       {
           Log.Step();
           var testForm = new TutByHomePageForm();

           Log.Step();
           testForm.OpenForums();

           Log.Step();
           testForm.GoToTalks();

          // Browser.GetDriver().SwitchTo().Window(Browser.GetDriver().WindowHandles.Last());
           var talksForm = new TalksForm();
           
           Log.Step();
           talksForm.GoToMostPopular();

           var topTalksForm = new TopListTalksForm();

           Log.Step();
           string theme = topTalksForm.ChooseRandomForum();

           var specificTalkForm = new SpecificForumThemeForm(theme);

          // Log.Step();
          // specificTalkForm.ChooseRandomForum();
       }

       [Test]
       public void CheckCurrencyConverter()
       {
           Log.Step();
           var testForm = new TutByHomePageForm();

           Log.Step();
           testForm.OpenBestCurrencyCources();


           var exchangeRatesForm = new ExchangeRates();
           Log.Step();
           exchangeRatesForm.TypeInitialAmount(InitialAmount);
           Log.Step();
           exchangeRatesForm.TypeInitialAmount(InitialAmount2);
       }

       [Test]
       public void CheckTodayAfisha()
       {
           Log.Step();
           var testForm = new TutByHomePageForm();

           Log.Step();
           testForm.GoToAfisha();

           var afishaForm = new AfishaForum();
           Log.Step();
           afishaForm.GoToWhereToGoToday();
           Log.Step();
           var afishaForTodayForm = new AfishaTodayForum();

       }

       [Test]
       public void CheckWeatherForecastFor2Weeks()
       {
           Log.Step();
           var testForm = new TutByHomePageForm();
           
           Log.Step();
           testForm.GoToWeatherViaWidjet();

           var weatherForm = new WeatherForum();
           
           Log.Step();
           weatherForm.SearchFor(City);

           Log.Step();
           weatherForm.GoToDetail();

       }
    }
}
