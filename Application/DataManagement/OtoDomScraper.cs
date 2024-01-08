using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace DecisionSystemForRealEastateInvestment.Application.DataManagement
{
    internal class OtoDomScraper : IScraper
    {

        public List<DataModel> DataModels { get; private set; }

        public OtoDomScraper() { }
        public async void Scrape(string url)
        {

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            HttpContent content = response.Content;
            string html = await content.ReadAsStringAsync();


        }
    }
}
