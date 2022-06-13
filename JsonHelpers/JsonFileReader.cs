using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Dagli.Models;
using System.IO;

namespace Dagli.JsonHelpers
{
    public class JsonFileReader
    {
        public static Dictionary<int, Product> ReadJson(string JsonFile)
        {
            string jsonString = File.ReadAllText(JsonFile);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int, Product>>(jsonString);
        }

        public static List<Login> ReadJsonLogin(string JsonFileLogin)
        {
            string jsonStringLogin = File.ReadAllText(JsonFileLogin);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<List<Login>>(jsonStringLogin);
        }

        public static Dictionary<int,Order> ReadJsonOrders(string JsonFileOrders)
        {
            string jsonStringLogin = File.ReadAllText(JsonFileOrders);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int,Order>>(jsonStringLogin);
        }
    }
}
