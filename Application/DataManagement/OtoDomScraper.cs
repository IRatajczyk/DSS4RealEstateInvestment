using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionSystemForRealEastateInvestment.Application.DataManagement
{
    internal class OtoDomScraper : IScraper
    {

        public List<DataModel> DataModels { get; private set; }

        public OtoDomScraper() { }
        public Task Scrape(string url)
        {
            throw new NotImplementedException();
        }
    }
}
