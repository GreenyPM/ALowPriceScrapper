using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumTester
{
    internal class CLI
    {   public static void Main(String[] args)
        {
            Console.WriteLine("ALDI'S LOWEST PRICE SCRAPPER 1.0 - Patrick Madonna");
            Console.WriteLine("Please Enter the product name you wish to see the lowest price for!");
            string key = Console.ReadLine();
            if (key == null || key == "")
            {
                Console.WriteLine("Since nothing was entered, seraching for default value: rice");
                Aldis s = new Aldis();
                List<string> prices = s.GetPrices();
                List<string> links = s.GetDetail();
                Console.WriteLine();
                Console.WriteLine($"Price of Product: {s.GetLowestPrice(prices)}");
                Console.WriteLine($"Link to Product: {s.GetLowestPriceDetail(links)}");
            }
            else
            {
                Aldis s = new Aldis(key);
                List<string> prices = s.GetPrices();
                List<string> links = s.GetDetail();
                Console.WriteLine();
                Console.WriteLine($"Price of Product: {s.GetLowestPrice(prices)}");
                Console.WriteLine($"Link to Product: {s.GetLowestPriceDetail(links)}");
            }
            Console.WriteLine("Press Enter to Complete");
            Console.ReadKey();
        }
    }
}
