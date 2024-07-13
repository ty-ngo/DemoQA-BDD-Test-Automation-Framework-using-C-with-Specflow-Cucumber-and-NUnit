using AventStack.ExtentReports.Utils;
using Core.Element;
using Core.WebDriver;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace DemoQA.BDDTesting.Page
{
    public class ProfilePage:BasePage
    {

        private Element _lnkLogin = new Element(By.XPath("//a[text()='login']"));

        private Element _lblBookTitle(string bookTitle)
        {
            return new Element(By.XPath($"//a[text()='{bookTitle}']"));
        }

        private Element _btnDelete(string bookTitle)
        {
            return new Element(By.XPath($"//a[text()='{bookTitle}']/ancestor::div[@role='row']//span[contains(@id,'delete')]"));
        }

        private Element _btnOK = new Element(By.XPath("//button[text()='OK']"));

        public void clickLoginLink()
        {
            _lnkLogin.Click();
        }

        public void deleteBook(string bookTitle)
        {
            if (checkBookExist(bookTitle))
            {
                _btnDelete(bookTitle).Click();
                _btnOK.Click();
                DriverHelper.AcceptAlert();
            }
        }

        public bool checkBookExist(string bookTitle)
        {
            return _lblBookTitle(bookTitle).WaitForElementToBeVisible() != null;
        }
    }
}
