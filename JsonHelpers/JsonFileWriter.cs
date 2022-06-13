using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using Dagli.Models;


namespace Dagli.JsonHelpers
{
    public class JsonFileWriter
    {
        public static void WriteToJson(Dictionary<int, Product> product, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(product, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
        public static void WriteToJsonLogin(List<Login> login, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(login, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
        public static void WriteToJsonOrders(Dictionary<int,Order> orders, string JsonFileName)
        {
            string output = Newtonsoft.Json.JsonConvert.SerializeObject(orders, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(JsonFileName, output);
        }
    }
}