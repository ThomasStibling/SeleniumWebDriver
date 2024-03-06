using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriver.Configuration
{
    public class CardSettings
    {
        public string Browser { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string Cvc { get; set; }
        public string Website { get; set; }
        public SampleNestedSettings NestedSetting { get; set; }
    }
}
