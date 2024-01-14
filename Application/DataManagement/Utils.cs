using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecisionSystemForRealEastateInvestment.Application.DataManagement
{
    internal class Utils
    {
        public static string EncodePolishToLatin(string input)
        {
            Dictionary<char, char> polishToLatinMap = new Dictionary<char, char>
        {
            {'ą', 'a'}, {'ć', 'c'}, {'ę', 'e'}, {'ł', 'l'},
            {'ń', 'n'}, {'ó', 'o'}, {'ś', 's'}, {'ź', 'z'},
            {'ż', 'z'}, {'Ą', 'A'}, {'Ć', 'C'}, {'Ę', 'E'},
            {'Ł', 'L'}, {'Ń', 'N'}, {'Ó', 'O'}, {'Ś', 'S'},
            {'Ź', 'Z'}, {'Ż', 'Z'}
        };

            char[] output = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                output[i] = polishToLatinMap.ContainsKey(input[i]) ? polishToLatinMap[input[i]] : input[i];
            }

            return new string(output);
        }

        public static string? GetCityVoivodeship(string city)
        {
            Dictionary<string, string> cityToVoivodeshipMap = new Dictionary<string, string>
        {
            {"warszawa", "Mazowieckie"},
            {"kraków", "Małopolskie"},
            {"łódź", "Łódzkie"},
            {"wrocław", "Dolnośląskie"},
            {"poznań", "Wielkopolskie"},
            {"gdańsk", "Pomorskie"},
            {"szczecin", "Zachodniopomorskie"},
            {"bydgoszcz", "Kujawsko--Pomorskie"},
            {"lublin", "Lubelskie"},
            {"katowice", "Śląskie"},
            {"białystok", "Podlaskie"},
            {"gdynia", "Pomorskie"},
            {"częstochowa", "Śląskie"},
            {"radom", "Mazowieckie"},
            {"sosnowiec", "Śląskie"},
            {"toruń", "Kujawsko--Pomorskie"}
        };

            if (cityToVoivodeshipMap.TryGetValue(city.ToLower(), out string voivodeship))
            {
                return voivodeship.ToLower();
            }
            return null;
        }
    }
}
