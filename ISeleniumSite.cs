using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTester
{
    internal interface ISeleniumSite
    {
        protected void ConnectToURL(string url);
        protected ReadOnlyCollection<IWebElement> FindMatchingCSSTags(string tag);

        List<string> GetPrices();
        string GetLowestPrice(List<string> prices);
        string GetLowestPriceDetail(List<string> links);
        List<string> GetDetail();


    }
}
