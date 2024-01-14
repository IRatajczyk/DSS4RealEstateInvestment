using System.Net.Http;
using System.Text.RegularExpressions;
using System.Collections.Concurrent;


namespace DecisionSystemForRealEastateInvestment.Application.DataManagement
{

    internal class NieruchomosciOnlineController
    {
        private string baseURL = "https://krakow.nieruchomosci-online.pl/szukaj.html?3,mieszkanie,sprzedaz,";
        public string City { get; set; }

        public NieruchomosciOnlineController(string city)
        {
            City = city;
        }

        public string BuildQueryURL(int pageNumber)
        {
            return $"{baseURL},{City}&p={pageNumber}";
        }

        public async Task Run(NieruchomosciOnlineScraper scraper, int startPage, int endPage)
        {
            if (startPage < 1)
            {
                startPage = 1;
            }
            if (endPage < startPage)
            {
                throw new Exception("endPage has to be >= startPage");
            }
            var scrapingTasks = new List<Task>();
            for (int i = startPage; i <= endPage; i++)
            {
                string url = BuildQueryURL(i);
                scrapingTasks.Add(scraper.Scrape(url));
            }

            await Task.WhenAll(scrapingTasks);
        }
    }
    internal class NieruchomosciOnlineScraper // : IScraper
    {
        private readonly HttpClient _httpClient = new();
        private readonly ConcurrentBag<DataModel> _dataModels = new();

        public List<DataModel> DataModels => new(_dataModels);

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

            var links = htmlDocument.DocumentNode.SelectNodes("//a[starts-with(@href, 'https://krakow.nieruchomosci-online.pl/')]");
            if (links == null)
            {
                return null;
            }

            var offerLinks = new HashSet<string>();
            foreach (var link in links)
            {
                if (!link.Attributes["href"].Value.Contains("szukaj.html?"))
                {
                    offerLinks.Add(link.Attributes["href"].Value);
                }
            }
            return offerLinks;
        }

        private static DataModel? ExtractDataModel(HtmlAgilityPack.HtmlDocument htmlDocument, string offerLink)
        {
            Console.WriteLine($"Extracting data model for {offerLink}");

            try
            {
                return new DataModel(
                    id: Guid.NewGuid().ToString(),
                    name: ExtractOfferName(htmlDocument),
                    description: ExtractOfferDescription(htmlDocument),
                    area: ExtractArea(htmlDocument),
                    price: ExtractPrice(htmlDocument),
                    isActive: true,
                    url: offerLink,
                    roomsCount: ExtractRoomsCount(htmlDocument),
                    bathroomsCount: ExtractBathRoomsCount(htmlDocument),
                    isGarageAvailable: CheckParkingAvailability(htmlDocument)
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting data model for {offerLink}: {ex.Message}");
                return null;
            }
        }

        private static string? ExtractOfferName(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            var nameNode = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='header-b mod-c desktop h1Title']");
            if (nameNode != null)
            {
                return nameNode.InnerText.Trim();
            }
            else
            {
                Console.WriteLine("Offer name not found.");
                return null;
            }
        }

        private static string? ExtractOfferDescription(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            var descriptionNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='boxCustomDesc']/div[@class='estate-desc-less']/p[1]");

            if (descriptionNode != null)
            {
                return descriptionNode.InnerText.Trim();
            }
            else
            {
                Console.WriteLine("Offer description not found.");
                return null;
            }
        }

        private static double? ExtractArea(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            try
            {
                var areaNode = htmlDocument.DocumentNode.SelectSingleNode("//strong[text()='Charakterystyka mieszkania:']/following-sibling::span");
                var areaText = areaNode?.InnerText.Split(',')[0].Replace("&nbsp;", "").Replace("m²", "").Trim();

                if (double.TryParse(areaText, out double area))
                {
                    return area;
                }
                else
                {
                    Console.WriteLine("Failed to parse area.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting area: {ex.Message}");
                throw;
            }
        }

        private static double? ExtractPrice(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            var priceNode = htmlDocument.DocumentNode.SelectSingleNode("//strong[text()='Cena:']/following-sibling::span");
            if (priceNode == null)
            {
                return null;
            }
            var priceText = priceNode.InnerText.Replace("&nbsp;", "").Replace("zł", "").Split(" ")[0];

            if (double.TryParse(priceText, out double price))
            {
                return price;
            }
            else
            {
                Console.WriteLine("Failed to parse price.");
                return null;
            }
        }

        private static int? ExtractRoomsCount(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            try
            {
                var roomsNode = htmlDocument.DocumentNode.SelectSingleNode("//strong[text()='Charakterystyka mieszkania:']/following-sibling::span");
                if (roomsNode == null)
                {
                    return null;
                }
                var roomsText = roomsNode.InnerText.Replace("&nbsp;", "").Split(',')[2].Trim();
                var roomsCount = ExtractTheNumberAStringStartsWith(roomsText);
                if (roomsCount != null)
                {
                    return roomsCount.Value;
                }
                else
                {
                    Console.WriteLine("Failed to parse rooms count.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting rooms count: {ex.Message}");
                throw;
            }
        }

        private static int? ExtractBathRoomsCount(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            try
            {
                var bathroomsNode = htmlDocument.DocumentNode.SelectSingleNode("//strong[text()='Charakterystyka mieszkania:']/following-sibling::span");
                if (bathroomsNode == null)
                {
                    return null;
                }
                var batchroomsText = bathroomsNode.InnerText.Replace("&nbsp;", "").Split(',')[3].Trim();
                var bathroomsCount = ExtractTheNumberAStringStartsWith(batchroomsText);
                if (bathroomsCount != null)
                {
                    return bathroomsCount.Value;
                }
                else
                {
                    Console.WriteLine("Failed to parse bathrooms count.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting bathrooms count: {ex.Message}");
                throw;
            }
        }

        private static int? ExtractTheNumberAStringStartsWith(string s)
        {
            var match = Regex.Match(s, @"\d+");
            if (match.Success)
            {
                if (int.TryParse(match.Value, out int number))
                {
                    return number;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        private static bool? CheckParkingAvailability(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            try
            {
                var parkingNode = htmlDocument.DocumentNode.SelectSingleNode("//strong[contains(text(), 'Miejsce parkingowe:')]/following-sibling::span") ??
                                  htmlDocument.DocumentNode.SelectSingleNode("//strong[contains(text(), 'Miejsce/a postojowe:')]/following-sibling::span");

                if (parkingNode == null)
                {
                    Console.WriteLine("Parking information not found.");
                    return null;
                }

                string parkingInfo = parkingNode.InnerText.Trim().ToLower();
                return !parkingInfo.Contains("brak");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting parking availability: {ex.Message}");
                return null;
            }
        }
    }
}
