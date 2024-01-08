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

        public DataModel(string id, string name, string description, double area, double price, bool isActive, string url, int roomsCount, int bathroomsCount, bool? isGarageAvailable)
        {
            Id = id;
            Name = name;
            Description = description;
            Area = area;
            Price = price;
            IsActive = isActive;
            Url = url;
            RoomsCount = roomsCount;
            BathroomsCount = bathroomsCount;
            IsGarageAvailable = isGarageAvailable;
        }

        override public string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Description: {Description}, Area: {Area}, Price: {Price}, IsActive: {IsActive}, Url: {Url}, RoomsCount: {RoomsCount}, BathroomsCount: {BathroomsCount}, IsGarageAvailable: {IsGarageAvailable}";
        }
    }
}
