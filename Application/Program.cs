using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DecisionSystemForRealEastateInvestment.Application.DataManagement;

namespace DecisionSystemForRealEastateInvestment.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            NieruchomosciOnlineScraper scraper = new NieruchomosciOnlineScraper();
            string url = "https://krakow.nieruchomosci-online.pl/szukaj.html?3,mieszkanie,sprzedaz,,Kraków,,,,50000-750000,20-100,,,,,,1-9";
            scraper.Scrape(url);
            var dataModels = scraper.DataModels;
            DataModelUtils.SaveToJson(dataModels: dataModels, fileName: "nieruchomosci-online.json");
            Console.ReadKey();
        }
    }
}
