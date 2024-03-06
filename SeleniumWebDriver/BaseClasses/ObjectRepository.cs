using OpenQA.Selenium;
using SeleniumWebDriver.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriver.BaseClasses
{
    public class ObjectRepository
    {
        public static IConfig Config { get; set; }
        public static IWebDriver Driver { get; set; }
    }
}
