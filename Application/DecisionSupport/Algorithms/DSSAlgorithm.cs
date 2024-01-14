using DecisionSystemForRealEastateInvestment.Application.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionSystemForRealEastateInvestment.Application.DecisionSupport.Algorithms
{
    public interface IAlgorithm
    {
        List<DataModel> GetBestOfferts(List<DataModel> dataModels);
    }
}
