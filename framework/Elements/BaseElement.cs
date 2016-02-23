using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace demo.framework.Elements
{
    public abstract class BaseElement : BaseEntity
    {
        private readonly RemoteWebElement _element;
        private readonly string _name;
        private readonly By _locator;
        private readonly string _text;
        private List<IWebElement> _elements;

        protected BaseElement(By locator, string name)
        {
            this._name = name;
            this._locator = locator;
        }

        protected BaseElement()
        {
        }

        public RemoteWebElement GetElement()
        {   
            WaitForElementPresent();
            return (RemoteWebElement)Browser.GetDriver().FindElement(_locator); 
        }

        public string GetName()
        {
            return _name;
        }
        public string GetText()
        {
            WaitForElementPresent();
            Log.Info("Element with the following text: " + this.GetElement().Text + " is present");
            return this.GetElement().Text;
        }

        public string GetText(string valueToOutput)
        {
            WaitForElementPresent();
            Log.Info(valueToOutput + this.GetElement().Text);
            return this.GetElement().Text;
        }

        protected By GetLocator()
        {
            return _locator;
        }


        public string RandomText;
        public void ClickRandomElementFromTheList()
        {
            WaitForElementPresent();
            _elements = Browser.GetDriver().FindElements(_locator).ToList();

            var rnd = new Random();
            var tempIndex = 0; //радомный индекс для выбора
            tempIndex = rnd.Next(0, _elements.Count);
            Log.Info("Random selected item is " + _elements[tempIndex].Text);
            RandomText = _elements[tempIndex].Text;
            _elements[tempIndex].Click();

            Log.Info(string.Format("{0} :: click", GetName()));
           
        }

        public bool AreElementsContainsText(string[] expectedText)
        {
            var isPresentTotal = true;
            var isPresentOne= false;
            WaitForElementPresent();
            _elements = Browser.GetDriver().FindElements(_locator).ToList();
            foreach (var element in _elements)
            {   
                isPresentOne = false;
                foreach (var text in expectedText)
                {
                    isPresentOne = element.Text.Contains(text);
                    if (isPresentOne)
                    {
                        Log.Info(element.Text + " is correct Result : Header contains the following text: " + text);
                        break;
                    }
                }
                if (!isPresentOne)
                {
                    isPresentTotal = false;
                    Log.Info(element.Text + " is INCORRECT result");
                }
            }
            return isPresentTotal;
        }

        public void Click()
        {
            WaitForElementPresent();
            GetElement().Click();
            Log.Info(string.Format("{0} :: click", GetName()));
        }

        public bool IsPresent()
        {
            WaitForElementPresent();
            var isPresent = Browser.GetDriver().FindElements(_locator).Count > 0;
            Log.Info(GetName() + " : is present : " + isPresent);
            return isPresent;
        }

        protected void WaitForElementPresent()
        {
            var wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until(waiting =>
                {
                    var webElements = Browser.GetDriver().FindElements(_locator);
                    return webElements.Count != 0;
                });
            }
            catch (TimeoutException)
            {
                Log.Fatal(string.Format("Element with locator: '{0}' does not exists!", _locator));
            }
        }

        public static void WaitForElementPresent(By locator, String name)
        {
            var wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromMilliseconds(Convert.ToDouble(Configuration.GetTimeout())));
            try
            {
                wait.Until(waiting =>
                {
                    try
                    {
                        var webElements = Browser.GetDriver().FindElements(locator);
                        return webElements.Count != 0;
                    }
                    catch (Exception e)
                    {
                        return false;
                    }
                });
            }
            catch (TimeoutException)
            {
                Log.Fatal(string.Format("Element with locator: '{0}' does not exists!", locator));
            }
        }

    }
}
