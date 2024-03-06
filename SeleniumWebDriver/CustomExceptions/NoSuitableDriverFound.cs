using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriver.CustomExceptions
{
    public class NoSuitableDriverFound : Exception
    {
        public NoSuitableDriverFound (string msg) : base (msg) { }
    }
}
