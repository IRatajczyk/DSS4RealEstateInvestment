using DecisionSystemForRealEastateInvestment.Application.DataManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionSystemForRealEastateInvestment.Application.DecisionSupport
{
    enum OptimizationMode
    {
        Minimize,
        Maximize
    }
    internal interface IDecisionSupportAlgorithm
    {
        List<DataModel> InferBestDecision();
    }
}
