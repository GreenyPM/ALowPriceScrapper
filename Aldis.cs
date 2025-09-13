using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V137.Browser;
using OpenQA.Selenium.DevTools.V137.Network;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTester
{
    internal class Aldis : SeleniumHelper
    {
        string keyword = "rice";

        public Aldis()
        {
            ConnectToURL($"https://www.aldi.us/results?q={keyword}&sort=price_asc");
            siteItems = FindMatchingCSSTags("product-grid");
        }

        public Aldis(string newKeyword) 
        {
            keyword = newKeyword;
            ConnectToURL($"https://www.aldi.us/results?q={keyword}&sort=price_asc");
            siteItems = FindMatchingCSSTags("product-grid");
        }

        public string getKeyword() 
        {
            return keyword;
        }


        override public List<string> GetPrices() 
        {
            List<string> prices = new List<string>();
            foreach (var productItem in siteItems)
            {
                ReadOnlyCollection<IWebElement> productPrices = driver.FindElements(By.CssSelector(".product-tile__price"));
                foreach (var price in productPrices)
                {
                    if (prices.Contains(price.Text))
                    {
                        continue;
                    }
                    else 
                    {
                        prices.Add(price.Text);
                    }
                }

            }
            if (prices.Count() > 0)
            {
                return prices;
            }
            else 
            {
                return ["None Found"];
            }
        }

        override public List<string> GetDetail() 
        {
            List <string> links = new List<string>();
            foreach (var productItem in siteItems)
            {
                ReadOnlyCollection<IWebElement> productLinks = driver.FindElements(By.CssSelector(".product-tile"));

                foreach (var link in productLinks)
                {
                    var linkElement = link.FindElement(By.CssSelector("a"));
                    string href = linkElement.GetAttribute("href");
                    if (links.Contains(href) || href == null)
                    {
                        continue;
                    }
                    else 
                    {
                       links.Add(href);
                    }
                }
            }
            if (links.Count() > 0)
            {
                return links;
            }
            else 
            {
                return ["Empty"];
            }
        }

    }
}
