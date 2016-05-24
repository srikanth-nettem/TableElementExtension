using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenQA.Selenium;

namespace TableElement_Extension
{
    public class TableElementExtention
    {
        private readonly IWebElement webTable;
        private readonly IWebDriver driver;

        public TableElementExtention(IWebDriver driver, IWebElement element)
        {
            webTable = element;
            this.driver = driver;
        }

        public int RowCount
        {
            get
            {
                return int.Parse(ExecuteJsCode(code => code.Append("return target.rowCount")).ToString());
            }
        }

        public int ColCount
        {
            get
            {
                return int.Parse(ExecuteJsCode(code => code.Append("return target.columnCount")).ToString());
            }
        }

        public string GetCellText(int row, int col)
        {
            return ExecuteJsCode(code => code.Append("return target.getCellText(arguments[1], arguments[2])"), row, col).ToString();
        }

        public int GetRowWithCellText(string text)
        {
            return int.Parse(ExecuteJsCode(code => code.Append("return target.getRowWithCellText(arguments[1])"), text).ToString());
        }

        private object ExecuteJsCode(Action<StringBuilder> action, params object[] args)
        {
            var arguments = new List<object> { webTable };
            arguments.AddRange(args);

            var javaScriptCode = new StringBuilder(File.ReadAllText("TableElementJs.js"));
            javaScriptCode.Append("var target=tableElementFunction(arguments[0]);");
            action(javaScriptCode);

            return ((IJavaScriptExecutor)driver).ExecuteScript(javaScriptCode.ToString(), arguments.ToArray());
        }
    }
}
