using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionSystemForRealEastateInvestment.Application.DataManagement
{
    internal interface IScraper
    {
        List<DataModel> DataModels { get; }
        public Task Scrape(string url);


    }
}
