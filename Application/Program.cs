using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DecisionSystemForRealEastateInvestment.Application.DataManagement;

namespace DecisionSystemForRealEastateInvestment.Application
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //NieruchomosciOnlineScraper scraper = new();
            //NieruchomosciOnlineController controller = new(city: "Kraków");

            //await controller.Run(scraper, 1, 20);

            OtoDomScraper scraper = new();
            await scraper.Scrape("https://www.otodom.pl/pl/wyniki/sprzedaz/mieszkanie/malopolskie/krakow/krakow/krakow?viewType=listing");
            var dataModels = scraper.DataModels;
            DataModelUtils.SaveToJson(dataModels: dataModels, fileName: "nieruchomosci-online.json");
            Console.ReadKey();
        }
    }
}
