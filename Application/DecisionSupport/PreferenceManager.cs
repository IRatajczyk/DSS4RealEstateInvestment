using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionSystemForRealEastateInvestment.Application.DecisionSupport
{

    public class ConstraintWrapper
    {
        public double MinValue;
        
        public double MaxValue;

        public bool IsValid;

        public ConstraintWrapper(bool isValid, double minValue = 0.0, double maxValue = Double.MaxValue)
        {
            MinValue = minValue;
            MaxValue = maxValue;
            IsValid = isValid;
        }

        public bool IsSatified(double? value)
        {
            if (IsValid) return value!=null && value >= MinValue && value <= MaxValue;
            else return true;   
        }   
   
    }
    public class PreferenceManager
    {
        public double AreaWeight;

        public double PriceWeight;

        public double RoomsCountWeight;

        public double BathroomsCountWeight;

        public ConstraintWrapper AreaConstraint;

        public ConstraintWrapper PriceConstraint;

        public ConstraintWrapper RoomsCountConstraint;

        public ConstraintWrapper BathroomsCountConstraint;

        public PreferenceManager(double areaWeight, double priceWeight, double roomsCountWeight, double bathroomsCountWeight, ConstraintWrapper areaConstraint, ConstraintWrapper priceConstraint, ConstraintWrapper roomsCountConstraint, ConstraintWrapper bathroomsCountConstraint)
        {
            AreaWeight = areaWeight;
            PriceWeight = priceWeight;
            RoomsCountWeight = roomsCountWeight;
            BathroomsCountWeight = bathroomsCountWeight;
            AreaConstraint = areaConstraint;
            PriceConstraint = priceConstraint;
            RoomsCountConstraint = roomsCountConstraint;
            BathroomsCountConstraint = bathroomsCountConstraint;
        }

        public static PreferenceManager Default()
        {
            return new PreferenceManager(
                0.5,
                0.5, 
                0.5, 
                0.5,
                new ConstraintWrapper(true, 0, 200), 
                new ConstraintWrapper(true, 0, 1000000), 
                new ConstraintWrapper(true, 1, 10), 
                new ConstraintWrapper(false, 1, 20));
        }

        public bool IsSatisfied(DataManagement.DataModel dataModel)
        {
            return AreaConstraint.IsSatified(dataModel.Area) 
                && PriceConstraint.IsSatified(dataModel.Price) 
                && RoomsCountConstraint.IsSatified(dataModel.RoomsCount) 
                && BathroomsCountConstraint.IsSatified(dataModel.BathroomsCount);
        }

    }
}
