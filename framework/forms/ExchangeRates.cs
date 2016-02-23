using System;
using demo.framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    internal class ExchangeRates : BaseForm
    {

        private readonly TextBox _txbByr = new TextBox(By.XPath("//input[contains(@data-currency,'BYR')]"), "BYR text box");
        private readonly TextBox _txbUsd = new TextBox(By.XPath("//input[contains(@data-currency,'USD')]"), "USD text box");

        private readonly Label _lblUsdCourse = new Label(By.XPath("//tr[2]/td[contains(@class,'inctances')]"), "USD course by NBRB");
     
        public ExchangeRates()
            : base(By.XPath("//h1[contains(text(), 'Курсы валют')]"), "Exchange Rates page")
        {
        }

        public void TypeInitialAmount(double initialAmount)
        {
            _txbByr.ClearText();
            _txbByr.SetText(initialAmount.ToString());
            var str = _lblUsdCourse.GetText("Course to calculate is ");
            str = str.Replace(" ", string.Empty);

            var expectedAmount = initialAmount / double.Parse(str);
            expectedAmount = Math.Round(expectedAmount, 2);
            try
            {
                Assert.AreEqual(expectedAmount.ToString(), _txbUsd.GetElement().GetAttribute("value"));
                Log.Info("Expected value is equal to calculated amount. ("+initialAmount+"BYR = " + expectedAmount + "USD)");
            }
            catch (Exception e)
            {
                Log.Info("Error happens. Details: " + e.Message);
                Assert.AreEqual(true, false);
            }
        }
    }
}
