using System;
using System.Threading;
using demo.framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    class ExchangeRates : BaseForm
    {

       private readonly TextBox _txbBYR = new TextBox(By.XPath("//input[contains(@data-currency,'BYR')]"), "BYR text box");
        private readonly TextBox _txbUSD = new TextBox(By.XPath("//input[contains(@data-currency,'USD')]"), "USD text box");
     // USD

        private readonly TextBox _txbU = new TextBox(By.XPath("//tr[2]/td[contains(@class,'inctances')]"), "USD text");
    

        public ExchangeRates()
            : base(By.XPath("//h1[contains(text(), 'Курсы валют')]"), "Exchange Rates page")
        {
        }

        public void TypeInitialAmount(double _initialAmount)
        {
            _txbBYR.SetText(_initialAmount.ToString());
            string str = _txbU.GetText("Course to calculate is ");
            str = str.Replace(" ", string.Empty);

            double expectedAmount = _initialAmount / Double.Parse(str);
            expectedAmount = Math.Round(expectedAmount, 2);
            Assert.AreEqual(expectedAmount.ToString(), _txbUSD.GetElement().GetAttribute("value"), "Values are equal");

        }
    }
}
