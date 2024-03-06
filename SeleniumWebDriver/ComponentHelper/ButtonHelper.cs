using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriver.ComponentHelper
{
    public class ButtonHelper
    {
        private static IWebElement element;

        public static void ClickButton(By locator)
        {
            element = GenericHelper.GetElement(locator);
            element.Click();
        }
    }
}
