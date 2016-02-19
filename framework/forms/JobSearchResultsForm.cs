using System;
using demo.framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    public class JobSearchResultsForm : BaseForm {
       
        private readonly Link _searchResultHeader = new Link(By.XPath("//a[contains(@data-qa, 'vacancy-serp__vacancy-title')]"), "Search result header");
  
        public JobSearchResultsForm()
            : base(By.XPath("//div[contains(@class, 'resumesearch__result-count')]"), "Job Search Result Page")
        {
        }

        public void GetSearchResult(string[] expectedText)
        {
            Assert.AreEqual(true, _searchResultHeader.IsPresent());
            try
            {
                Assert.AreEqual(true, _searchResultHeader.AreElementsContainsText(expectedText));
            }
            catch (Exception e)
            {
                Log.Info("Test is failed. \n" + e.Message);
                Assert.Fail();
            }

        }


    }
}
