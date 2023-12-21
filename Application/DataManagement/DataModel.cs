using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionSystemForRealEastateInvestment.Application.DataManagement
{
    internal struct DataModel
    {
        public string Id { get; }

        public string Name { get;}
        public string Description { get; }

        public double Area { get; }

        public double Price { get; }

        public bool IsActive { get; }

        public string Url { get; }

        public int RoomsCount { get; }

        public int BathroomsCount { get; }

        public bool? IsGarageAvailable { get; }
    }
}
