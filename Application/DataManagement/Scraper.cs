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
        void Scrape(string url);
    }
}
