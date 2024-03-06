using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using SeleniumWebDriver.BaseClasses;
using SeleniumWebDriver.ComponentHelper;

namespace CreditCard.Steps;

[Binding]
public class ValidCreditCardStepDefinitions
{
    [Given(@"user fills the three inputs")]
    public void GivenUserFillsTheThreeInputs()
    {
        TextBoxHelper.TypeInTextBox(By.Id("creditCardNumber"),"1234567899876543");
        TextBoxHelper.TypeInTextBox(By.Id("expirationDate"),"10/2023");
        TextBoxHelper.TypeInTextBox(By.Id("cvc"),"123");
    }

    [Given(@"credit card number is sixteen digits long")]
    public void GivenCreditCardNumberIsSixteenDigitsLong()
    {
        string textBoxValue = TextBoxHelper.GetTextBoxValue(By.Id("creditCardNumber"));
        Assert.AreEqual(textBoxValue.Length, 16);
    }

    [Given(@"expiration date is at format MM/YYYY")]
    public void GivenExpirationDateIsAtFormatMmyyyy()
    {
        string textBoxValue = TextBoxHelper.GetTextBoxValue(By.Id("expirationDate"));
        /*string pattern = @"^(0[1-9]|1[0-2])\/(20[2-9][0-9]|2[1-9][0-9]{2}|3[01])\/(0[1-9]|1[0-9]|2[0-9]|3[0-9]|4[0-9]|5[0-3])[0-9]{2}$";
        bool isValidDate = Regex.IsMatch(textBoxValue, pattern);
        Assert.IsTrue(isValidDate);*/
        
        Assert.AreEqual(textBoxValue.Substring(2, 1), "/");
        Assert.IsTrue(int.TryParse(textBoxValue.Substring(0, 2), out int month));
        Assert.IsTrue(int.TryParse(textBoxValue.Substring(3, 4), out int year));
        Assert.IsTrue(month >= 1 && month <= 12);
        Assert.IsTrue(year >= 1987 && year <= 2099);
    }

    [Given(@"cvc is three digits long")]
    public void GivenCvcIsThreeDigitsLong()
    {
        string textBoxValue = TextBoxHelper.GetTextBoxValue(By.Id("cvc"));
        Assert.AreEqual(textBoxValue.Length, 3);
    }

    [When(@"submit button is pressed")]
    public void WhenSubmitButtonIsPressed()
    {
        ButtonHelper.ClickButton(By.Id("submitCard"));
        //comment vérifier si bouton est bien clique ? 
    }

    [Then(@"user is on page paymentConfirmed")]
    public void ThenUserIsOnPagePaymentConfirmed()
    {
        Assert.AreEqual(Path.Combine(ObjectRepository.Config.GetWebsite(), "Workshop_note/paymentConfirmed.html"), PageHelper.GetPageUrl());
    }

    [Given(@"credit card number is not sixteen digits long")]
    public void GivenCreditCardNumberIsNotSixteenDigitsLong()
    {
        TextBoxHelper.ClearTextBox(By.Id("creditCardNumber"));
        TextBoxHelper.TypeInTextBox(By.Id("creditCardNumber"),"12345");
        string textBoxValue = TextBoxHelper.GetTextBoxValue(By.Id("creditCardNumber"));
        Assert.AreNotEqual(textBoxValue.Length, 16);
    }

    [Then(@"user is on homePage")]
    public void ThenUserIsOnHomePage()
    {
        Assert.AreEqual(Path.Combine(ObjectRepository.Config.GetWebsite(), "Workshop_note/Workshop.html"), PageHelper.GetPageUrl());
    }

    [Given(@"expiration date is not at format MM/YYYY")]
    public void GivenExpirationDateIsNotAtFormatMmyyyy()
    {
        TextBoxHelper.ClearTextBox(By.Id("expirationDate"));
        TextBoxHelper.TypeInTextBox(By.Id("expirationDate"),"2023-12" );
        
        string textBoxValue = TextBoxHelper.GetTextBoxValue(By.Id("expirationDate"));
        Assert.AreNotEqual(textBoxValue.Substring(2, 1), "/");
        
    }

    [Given(@"cvc is not three digits long")]
    public void GivenCvcIsNotThreeDigitsLong()
    {
        TextBoxHelper.TypeInTextBox(By.Id("cvc"),"12323");
    }
}