using System;
using System.Linq;
using NUnit.Framework;
using demo.framework;
using demo.framework.forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

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
        public void RunTest()
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
  //Browser.GetDriver().Close();
           /*
           var jobForm = new JobForm();

           Log.Step();
           jobForm.SearchFor(SearchText);

           var jobSearchResultsForm = new JobSearchResultsForm();

           Log.Step();
           jobSearchResultsForm.GetSearchResult(_arrayOfVerifiedWords);*/
        }
    }
}
