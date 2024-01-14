using HtmlAgilityPack;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.AccessControl;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using static System.Windows.Forms.LinkLabel;

namespace DecisionSystemForRealEastateInvestment.Application.DataManagement
{
    internal class OtoDomController
    {
        private string baseURL = "https://www.otodom.pl/pl/wyniki/sprzedaz/mieszkanie";
        public string City { get; set; }
        public string Voivodeship { get; set; }

        public OtoDomController(string city)
        {
            City = city;
            var voivodeship = Utils.GetCityVoivodeship(City);
            if (voivodeship == null)
            {
                throw new ApplicationException($"no voivodeship found for {City}");
            }
            Voivodeship = voivodeship;
        }

        public string BuildQueryURL(int pageNumber)
        {
            return Utils.EncodePolishToLatin($"{baseURL}/{Voivodeship}/{City}/{City}/{City}?viewType=listing&page={pageNumber}").ToLower();
        }

        public async Task Run(OtoDomScraper scraper, int startPage, int endPage)
        {
            if (startPage < 1)
            {
                startPage = 1;
            }
            if (endPage < startPage)
            {
                throw new ApplicationException("endPage has to be >= startPage");
            }


            var scrapingTasks = new List<Task>();
            for (int i = startPage; i <= endPage; i++)
            {
                string url = BuildQueryURL(i);
                Console.WriteLine(url);
                scrapingTasks.Add(scraper.Scrape(url));
            }

            await Task.WhenAll(scrapingTasks);
        }
    }

    internal class OtoDomScraper : IScraper
    {
        private readonly HttpClient _httpClient = new();
        private readonly ConcurrentBag<DataModel> _dataModels = new();

        public List<DataModel> DataModels => new(_dataModels);

        public OtoDomScraper() { }
        public async Task Scrape(string url)
        {
            var offerLinks = await ExtractOfferLinksAsync(url);
            if (offerLinks == null || offerLinks.Count == 0)
            {
                Console.WriteLine("No matching links found.");
                return;
            }
            foreach (var link in offerLinks)
            {
                var offerHtml = await _httpClient.GetStringAsync(link);
                var htmlDocument = new HtmlAgilityPack.HtmlDocument();
                htmlDocument.LoadHtml(offerHtml);

                var dataModel = ExtractDataModel(htmlDocument, link);
                if (dataModel != null)
                {
                    _dataModels.Add(dataModel.Value);
                }
            }
        }

        private async Task<HashSet<string>?> ExtractOfferLinksAsync(string url)
        {
            var html = await _httpClient.GetStringAsync(url);
            var htmlDocument = new HtmlAgilityPack.HtmlDocument();
            htmlDocument.LoadHtml(html);

            var links = htmlDocument.DocumentNode.SelectNodes("//a[@data-cy='listing-item-link']");
            if (links == null)
            {
                return null;
            }

            var offerLinks = new HashSet<string>();
            foreach (var link in links)
            {
                var extractedLink = link.GetAttributeValue("href", string.Empty);
                if (!String.IsNullOrEmpty(extractedLink))
                {
                    offerLinks.Add($"https://www.otodom.pl{extractedLink}");
                }
            }
            return offerLinks;
        }

        private DataModel? ExtractDataModel(HtmlAgilityPack.HtmlDocument htmlDocument, string offerLink)
        {
            Console.WriteLine($"Extracting data model for {offerLink}");

            try
            {
                return new DataModel(
                    Guid.NewGuid().ToString(),
                    ExtractName(htmlDocument),
                    ExtractDescription(htmlDocument),
                    ExtractArea(htmlDocument),
                    ExtractPrice(htmlDocument),
                    true,
                    offerLink,
                    ExtractRoomsCount(htmlDocument),
                    ExtractBathroomsCount(htmlDocument),
                    ExtractIsGarageAvailable(htmlDocument)
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting data model for {offerLink}: {ex.Message}");
                return null;
            }
        }

        private double? ParseDouble(string value)
        {
            return double.TryParse(value, out double result) ? result : (double?)null;
        }

        private double? ParsePrice(string priceString)
        {
            if (string.IsNullOrEmpty(priceString))
                return null;

            var numericString = System.Text.RegularExpressions.Regex.Replace(priceString, @"\D", "");
            return double.TryParse(numericString, out double result) ? result : (double?)null;
        }

        private int? ParseInt(string value)
        {
            return int.TryParse(value, out int result) ? result : (int?)null;
        }

        private string? ExtractName(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            var nameNode = htmlDocument.DocumentNode.SelectSingleNode("//h1[@data-cy='adPageAdTitle']");
            return nameNode?.InnerText.Trim();
        }

        private string? ExtractDescription(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            var descriptionNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@data-cy='adPageAdDescription']");
            return descriptionNode?.InnerText.Trim();
        }

        private double? ExtractArea(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            var areaNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@data-testid='table-value-area']");
            return areaNode != null ? ParseDouble(areaNode.InnerText.Replace("m²", "").Trim()) : null;
        }

        private double? ExtractPrice(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            var priceNode = htmlDocument.DocumentNode.SelectSingleNode("//strong[@aria-label='Cena']");
            return priceNode != null ? ParsePrice(priceNode.InnerText) : null;
        }

        private int? ExtractRoomsCount(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            var roomsCountNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@data-testid='table-value-rooms_num']");
            return roomsCountNode != null ? ParseInt(roomsCountNode.InnerText.Trim()) : null;
        }

        private int ExtractBathroomsCount(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            // Assuming that each aparment has at least 1 bathroom. It can be sometimes extracted from the description.
            return 1;
        }

        private bool? ExtractIsGarageAvailable(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            var isGarageAvailableNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@data-testid='table-value-car']");
            if (isGarageAvailableNode == null)
            {
                return null;
            }
            if (isGarageAvailableNode.InnerText.ToLower().Contains("zapytaj"))
            {
                return null;
            }
            return isGarageAvailableNode.InnerText.ToLower().Contains("garaż") || isGarageAvailableNode.InnerText.ToLower().Contains("miejsce parkingowe");
        }
    }
}
