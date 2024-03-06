using Microsoft.Extensions.Configuration;
using SeleniumWebDriver.BaseClasses;
using SeleniumWebDriver.CustomExceptions;
using SeleniumWebDriver.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumWebDriver.Configuration
{
    public class ConfigReader : IConfig
    {

        private CardSettings settings;

        public ConfigReader()
        {
            IConfiguration config = new ConfigurationBuilder()
                .AddJsonFile("/Users/thomas/Documents/m2i/bdd/SeleniumWebDriver/SeleniumWebDriver/Properties/appsettings.json")
                .AddEnvironmentVariables()
                .Build();

            settings = config.GetRequiredSection(nameof(CardSettings)).Get<CardSettings>();
        }

        public BrowserType GetBrowser()
        {
            string browser = settings.Browser;

            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
            catch (ArgumentException)
            {
                throw new NoSuitableDriverFound("Aucun driver n'a été trouvé  : " + settings.Browser);
            }
        }

        public string GetCreditCardNumber()
        {
            return settings.CreditCardNumber;
        }

        public string GetExpirationDate()
        {
            return settings.ExpirationDate;
        }

        public string GetCvc()
        {
            return settings.Cvc;
        }
        
        public string GetWebsite()
        {
            return settings.Website;
        }
    }
}
