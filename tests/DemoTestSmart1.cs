using NUnit.Framework;
using demo.framework;
using demo.framework.forms;

namespace demo.tests
{
   [TestFixture]
    public class DemoTestSmart1 : BaseTest
    {
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
           var testForm = new TutSearchForm();
            
           Log.Step();
           testForm.GoToJob();

           var jobForm = new JobForm();

           Log.Step();
           jobForm.SearchFor(SearchText);

           var jobSearchResultsForm = new JobSearchResultsForm();

           Log.Step();
           jobSearchResultsForm.GetSearchResult(_arrayOfVerifiedWords);
        }
    }
}
