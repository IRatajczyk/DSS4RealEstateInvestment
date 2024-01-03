using System.Net;
using System.Text.RegularExpressions;


namespace DecisionSystemForRealEastateInvestment.Application.DataManagement
{
    // TODO: Klasa do sterowania scraperem Nieruchomosci-Online
    // nieruchomosci-online można odpytywać podając po 'szukaj.html?' zapytanie
    // `3,mieszkanie,sprzedaz,` - część stała zapytania
    // a parametry które chcemy zmienić wymieniamy kolejno po przecinku:
    // idk, MIASTO, idk, idk, idk, idk, CENA_OD-CENA_DO, METRY_OD-METRY_DO, idk, idk, idk, idk, idk, POKOJE_OD-POKOJE-DO
    // przykład: "https://krakow.nieruchomosci-online.pl/szukaj.html?3,mieszkanie,sprzedaz,,Kraków,,,,50000-750000,20-100,,,,,,1-9"
    // można również przejść na konkretną stronę z ogłoszeniami dodając do zapytania '&p=NUMER_STRONY'
    // przykład: "https://krakow.nieruchomosci-online.pl/szukaj.html?3,mieszkanie,sprzedaz,,Kraków&p=2"
    // Myślę, że można to wykorzystać, by sterować scraperem by od razu wyszukiwał wszystkie oferty z danego miasta i żeby wiedział jak przejść na kolejne strony z ofertami.
    internal class NieruchomosciOnlineScraper : IScraper
    {
        public List<DataModel> DataModels { get; private set; } = new List<DataModel>();

        public void Scrape(string url)
        {
            using (var webClient = new WebClient())
            {
                var htmlDocument = new HtmlAgilityPack.HtmlDocument();

                var html = webClient.DownloadString(url);
                htmlDocument.LoadHtml(html);

                var links = htmlDocument.DocumentNode.SelectNodes("//a[starts-with(@href, 'https://krakow.nieruchomosci-online.pl/')]");
                if (links == null || links.Count == 0)
                {
                    Console.WriteLine("No matching links found.");
                    return;
                }

                var offerLinks = new HashSet<string>();
                foreach (var link in links)
                {
                    // Don't include links to other offer pages
                    if (link.Attributes["href"].Value.Contains("szukaj.html?"))
                    {
                        continue;
                    }
                    offerLinks.Add(link.Attributes["href"].Value);
                }

                foreach (var link in offerLinks)
                {
                    var offerHtml = webClient.DownloadString(link);
                    htmlDocument.LoadHtml(offerHtml);

                    var dataModel = ExtractDataModel(htmlDocument, link);
                    if (dataModel != null)
                    {
                        DataModels.Add(dataModel.Value);
                    }
                }
            }
        }


        private DataModel? ExtractDataModel(HtmlAgilityPack.HtmlDocument htmlDocument, string offerLink)
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

        private static string ExtractOfferName(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            var nameNode = htmlDocument.DocumentNode.SelectSingleNode("//h1[@class='header-b mod-c desktop h1Title']");
            if (nameNode != null)
            {
                return nameNode.InnerText.Trim();
            }
            else
            {
                Console.WriteLine("Offer name not found.");
                return string.Empty;
            }
        }

        private static string ExtractOfferDescription(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            var descriptionNode = htmlDocument.DocumentNode.SelectSingleNode("//div[@id='boxCustomDesc']/div[@class='estate-desc-less']/p[1]");

            if (descriptionNode != null)
            {
                return descriptionNode.InnerText.Trim();
            }
            else
            {
                Console.WriteLine("Offer description not found.");
                return string.Empty;
            }
        }

        private static double ExtractArea(HtmlAgilityPack.HtmlDocument htmlDocument)
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
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting area: {ex.Message}");
                throw;
            }
        }

        private static double ExtractPrice(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            try
            {
                var priceNode = htmlDocument.DocumentNode.SelectSingleNode("//strong[text()='Cena:']/following-sibling::span");
                var priceText = priceNode.InnerText.Replace("&nbsp;", "").Replace("zł", "").Split(" ")[0];

                if (double.TryParse(priceText, out double price))
                {
                    return price;
                }
                else
                {
                    Console.WriteLine("Failed to parse price.");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting price: {ex.Message}");
                throw;
            }
        }

        private static int ExtractRoomsCount(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            try
            {
                var roomsNode = htmlDocument.DocumentNode.SelectSingleNode("//strong[text()='Charakterystyka mieszkania:']/following-sibling::span");
                var roomsText = roomsNode?.InnerText.Replace("&nbsp;", "").Split(',')[2].Trim();
                var roomsCount = ExtractTheNumberAStringStartsWith(roomsText);
                if (roomsCount != null)
                {
                    return roomsCount.Value;
                }
                else
                {
                    Console.WriteLine("Failed to parse rooms count.");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error extracting rooms count: {ex.Message}");
                throw;
            }
        }

        private static int ExtractBathRoomsCount(HtmlAgilityPack.HtmlDocument htmlDocument)
        {
            try
            {
                var bathroomsNode = htmlDocument.DocumentNode.SelectSingleNode("//strong[text()='Charakterystyka mieszkania:']/following-sibling::span");
                var batchroomsText = bathroomsNode?.InnerText.Replace("&nbsp;", "").Split(',')[3].Trim();
                var bathroomsCount = ExtractTheNumberAStringStartsWith(batchroomsText);
                if (bathroomsCount != null)
                {
                    return bathroomsCount.Value;
                }
                else
                {
                    Console.WriteLine("Failed to parse bathrooms count.");
                    return -1;
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
