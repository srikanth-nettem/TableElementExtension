using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Xunit;

namespace TableElement_Extension
{
    public class Test
    {
        private readonly TableElementExtention _targetTableElement;
        private readonly IWebDriver driver;
        public Test()
        {
            driver = new FirefoxDriver();
            driver.Navigate().GoToUrl("http://www.w3schools.com/html/html_tables.asp");
            var locator = By.TagName("table");
            driver.WaitForElement(locator);
            var tableElement = driver.FindElement(locator);
            _targetTableElement = new TableElementExtention(driver, tableElement);
        }

        [Fact(DisplayName = "RowCount Test")]
        public void Test1()
        {
            var rowCount = _targetTableElement.RowCount;
            Assert.Equal(rowCount, 5);
        }

        [Fact(DisplayName = "ColCount Test")]
        public void Test2()
        {
            var colCount = _targetTableElement.ColCount;
            Assert.Equal(colCount, 4);
        }

        [Fact(DisplayName = "CellText Test")]
        public void Test3()
        {
            var cellText = _targetTableElement.GetCellText(3, 2);
            Assert.Equal(cellText, "Johnson");
        }

        [Fact(DisplayName = "RowWithCellText Test")]
        public void Test4()
        {
            var rowCount = _targetTableElement.GetRowWithCellText("Smith");
            Assert.Equal(rowCount, 4);
        }
    }
}
