using System.Linq;
using NUnit.Framework;
using demo.framework;
using demo.framework.forms;

namespace demo.tests
{
   [TestFixture]
    public class TestCasesSmart2 : BaseTest
    {
       private const string Login = "kaktusflash";
       private const string Password = "solnyhko";
       private const string FirstName = "Svetlana";
       private const string NewFirstName = "Svetlana";
       private const string LastName = "Bulavka";
       private static readonly double[] InitialAmount = new double[]{
           21644.00,
           43288.00};

       private const string City= "Витебск";

       [Test]
        public void ChangeFirstNameOfUserTest()
        {
           Log.Step();
           var homeTutByForm = new TutByHomePageForm();
            
           Log.Step();
           homeTutByForm.GoToLoginPopUp();

           Log.Step();
           homeTutByForm.FillInLoginPopUp(Login, Password, FirstName, LastName);
           
           Log.Step();
           homeTutByForm.GoToProfile();

           Browser.GetDriver().SwitchTo().Window(Browser.GetDriver().WindowHandles.Last());

           Log.Step();
           var myProfileForm = new ProfileForm();

           Log.Step();
           myProfileForm.ChangeFirstName(NewFirstName);

           Log.Info("End of test");
        }

       [Test]
       public void OpenRandomCatalogTest()
       {
           Log.Step();
           var homeTutByForm = new TutByHomePageForm();

           Log.Step();
           homeTutByForm.OpenForums();

           Log.Step();
           homeTutByForm.GoToTalks();

           var talksForm = new TalksForm();
           
           Log.Step();
           talksForm.GoToMostPopular();

           var topTalksForm = new TopListTalksForm();

           Log.Step();
           var theme = topTalksForm.ChooseRandomForum();

           var specificTalkForm = new SpecificForumThemeForm(theme);
           Log.Info("End of test");
       }

       [Test]
       public void CheckCurrencyConverter()
       {
           Log.Step();
           var homeTutByForm = new TutByHomePageForm();

           Log.Step();
           homeTutByForm.OpenBestCurrencyCources();

           var exchangeRatesForm = new ExchangeRates();

           Log.Step();
           exchangeRatesForm.TypeInitialAmount(InitialAmount[0]);

           Log.Step();
           exchangeRatesForm.TypeInitialAmount(InitialAmount[1]);

           Log.Info("End of test");
       }

       [Test]
       public void CheckTodayAfisha()
       {
           Log.Step();
           var homeTutByForm = new TutByHomePageForm();

           Log.Step();
           homeTutByForm.GoToAfisha();

           var afishaForm = new AfishaForum();

           Log.Step();
           afishaForm.GoToWhereToGoToday();

           Log.Step();
           var afishaForTodayForm = new AfishaTodayForum();

           Log.Info("End of test");
       }

       [Test]
       public void CheckDetailsWeatherForecastInCity()
       {
           Log.Step();
           var homeTutByForm = new TutByHomePageForm();
           
           Log.Step();
           homeTutByForm.GoToWeatherViaWidjet();

           var weatherForm = new WeatherForm();
           
           Log.Step();
           weatherForm.SearchFor(City);

           Log.Step();
           weatherForm.GoToDetail();

           Log.Info("End of test");
       }

    }
}
