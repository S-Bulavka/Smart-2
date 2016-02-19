using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;

namespace demo.framework.Elements
{
    class Label : BaseElement
    {
        public Label(By locator, String name) : base(locator, name) { }
    }
    
}
