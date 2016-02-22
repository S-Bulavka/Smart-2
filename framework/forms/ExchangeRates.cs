using System;
using demo.framework.Elements;
using NUnit.Framework;
using OpenQA.Selenium;

namespace demo.framework.forms
{
    class ExchangeRates : BaseForm
    {

       private readonly TextBox _txbBYR = new TextBox(By.XPath("//input[contains(@data-currency,'BYR')]"), "BYR text box");
        private readonly TextBox _txbUSD = new TextBox(By.XPath("//input[contains(@data-currency,'USD')]"), "USD text box");
      //  private readonly TextBox _txbEUR = new TextBox(By.XPath("//input[contains(@data-currency,'USD')]"), "USD text box");

        private readonly Label _lblUSDCourse = new Label(By.XPath("//tr[2]/td[contains(@class,'inctances')]"), "USD course by NBRB");
        private readonly Label _lblEURCourse = new Label(By.XPath("//tr[3]/td[contains(@class,'inctances')]/big"), "EUR course by NBRB");

        private readonly Button _btnChangeCurrency = new Button(By.XPath("//button[contains(@data-title,'USD')]"), "Change Currency button");
        private readonly Button _btnChangeToEuro = new Button(By.XPath("//li[2][contains(@class,'selected')]/a"), "Change Currency to EUR button");
      
     
        public ExchangeRates()
            : base(By.XPath("//h1[contains(text(), 'Курсы валют')]"), "Exchange Rates page")
        {
        }

        public void TypeInitialAmount(double _initialAmount)
        {
            _txbBYR.ClearText();
            _txbBYR.SetText(_initialAmount.ToString());
            string str = _lblUSDCourse.GetText("Course to calculate is ");
            str = str.Replace(" ", string.Empty);

            double expectedAmount = _initialAmount / Double.Parse(str);
            expectedAmount = Math.Round(expectedAmount, 2);
            try
            {
                Assert.AreEqual(expectedAmount.ToString(), _txbUSD.GetElement().GetAttribute("value"));

                Log.Info("Expected value is equal to calculated amount. ("+_initialAmount+"BYR = " + expectedAmount.ToString() + "USD)");
            }
            catch (Exception e)
            {
                Log.Info("Error happens. Details: " + e.Message);
                Assert.AreEqual(true, false);

            }
        }

      /*  public void ChangeExpectedCurrency(double _initialAmount)
        {
            _btnChangeCurrency.Click();
            _btnChangeToEuro.Click();


            Thread.Sleep(5000);
            string str = _lblEURCourse.GetText("Course to calculate is ");
            str = str.Replace(" ", string.Empty);

            double expectedAmount = _initialAmount / Double.Parse(str);
            expectedAmount = Math.Round(expectedAmount, 2);
            try
            {
                Assert.AreEqual(expectedAmount.ToString(), _txbUSD.GetElement().GetAttribute("value"));

                Log.Info("Expected value is equal to calculated amount. (" + _initialAmount + "BYR = " + expectedAmount.ToString() + "EUR)");
            }
            catch (Exception e)
            {
                Log.Info("Error Expected value is equal to calculated amount. (" + _initialAmount + "BYR = " + _txbUSD.GetElement().GetAttribute("value") + "EUR)");
            }

            //
        } */
    }
}
