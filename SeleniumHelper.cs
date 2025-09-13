using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V137.Extensions;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTester
{
    internal class SeleniumHelper : ISeleniumSite
    {
        protected EdgeDriver driver;
        protected ReadOnlyCollection<IWebElement> siteItems;

        public void ConnectToURL(string url)
        {
            var edgeOptions = new EdgeOptions();
            edgeOptions.AddArguments("headless");
            edgeOptions.AddArguments("disable-gpu");
            driver = new EdgeDriver(edgeOptions);

            driver.Navigate().GoToUrl(url);

        }

        public ReadOnlyCollection<IWebElement> FindMatchingCSSTags(string tag)
        {
            ReadOnlyCollection<IWebElement> productItems = driver.FindElements(By.CssSelector($".{tag}"));
            Console.WriteLine($"Found {productItems.Count} matches");
            return productItems;
        }

        public virtual List<string> GetPrices()
        {
            List<string> prices = new List<string>();
            return prices;
        }

        public virtual string GetLowestPrice(List<string> prices)
        {
            return prices[0];
        }

        public virtual string GetLowestPriceDetail(List<string> links)
        {
            return links[0];
        }

        public virtual List<string> GetDetail()
        {
            List<string> links = new List<string>();
            return links;
        }



    }
}
