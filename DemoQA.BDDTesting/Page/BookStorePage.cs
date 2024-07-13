using Core.Element;
using Core.WebDriver;
using OpenQA.Selenium;

namespace DemoQA.BDDTesting.Page
{
    public class BookStorePage : BasePage
    {
        private Element _lnkBookTitle(string bookName) { return new Element(By.XPath($"//a[text()='{bookName}']")); }
        private Element _lblResultsInColumn(string columnName)
        {
            if (columnName == "Title")
            {
                return new Element(By.XPath($"//div[not(contains(@class,'-padRow'))]/div[@role='gridcell'][count(//div[@role='columnheader' and .='{columnName}']/preceding-sibling::div) + 1]//a"));
            }

            else if (columnName == "Author" || columnName == "Publisher")
            {
                return new Element(By.XPath($"//div[not(contains(@class,'-padRow'))]/div[@role='gridcell'][count(//div[@role='columnheader' and .='{columnName}']/preceding-sibling::div) + 1]"));
            }

            else
            {
                return null;
            }
        }

        public void GoToBookDetailPage(string bookName)
        {
            _lnkBookTitle(bookName).Click();
        }

        public bool checkSearchResult(string searchValue)
        {
            IList<IWebElement> titleList = _lblResultsInColumn("Title").FindAllElements();
            IList<IWebElement> authorList = _lblResultsInColumn("Author").FindAllElements();
            IList<IWebElement> publisherList = _lblResultsInColumn("Publisher").FindAllElements();

            for (int i = 0; i < titleList.Count; i++)
            {
                if (!titleList[i].Text.ToLower().Trim().Contains(searchValue.ToLower().Trim()) &&
                    !authorList[i].Text.ToLower().Trim().Contains(searchValue.ToLower().Trim()) &&
                    !publisherList[i].Text.ToLower().Trim().Contains(searchValue.ToLower().Trim()))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
