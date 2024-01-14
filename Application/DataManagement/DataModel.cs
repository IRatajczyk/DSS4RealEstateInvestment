using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Threading.Tasks;

namespace DecisionSystemForRealEastateInvestment.Application.DataManagement
{
    public struct DataModel
    {
        public string Id { get; }

        public string? Name { get; }
        public string? Description { get; }

        public double? Area { get; }

        public double? Price { get; }

        public bool IsActive { get; }

        public string Url { get; }

        public int? RoomsCount { get; }

        public int? BathroomsCount { get; }

        public bool? IsGarageAvailable { get; }

        public double[] Serialized { get => new double[] { Area ?? 0, Price ?? 0, RoomsCount ?? 0, BathroomsCount ?? 0, IsGarageAvailable == true ? 1 : 0 };}

        public DataModel(string id, string? name, string? description, double? area, double? price, bool isActive, string url, int? roomsCount, int? bathroomsCount, bool? isGarageAvailable)
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
            return $"Name: {Name}\nArea: {Area}\nPrice: {Price}\nRoomsCount: {RoomsCount}\nBathroomsCount: {BathroomsCount}";
        }
    }

    public static class DataModelUtils
    {
        public static void SaveToJson(List<DataModel> dataModels, string fileName)
        {
            try
            {
                var jsonString = JsonSerializer.Serialize(dataModels, new JsonSerializerOptions { WriteIndented = true });
                var filePath = @$"{Environment.CurrentDirectory}\{fileName}";
                File.WriteAllText(filePath, jsonString);
                Console.WriteLine($"{fileName} saved to {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while saving to JSON: {ex.Message}");
            }
        }
    }
}
