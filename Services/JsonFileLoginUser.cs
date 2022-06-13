using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dagli.JsonHelpers;
using Dagli.Interfaces;
using Dagli.Models;

namespace Dagli.Services
{
    public class JsonFileLoginUser
    {
        string JsonFileName = @".\Data\jsonLogin.json";

        public List<Login> GetJsonUsers()
        {
            return JsonFileReader.ReadJsonLogin(JsonFileName);
        }
        public void SaveJsonUser(List<Login> users)
        {
            JsonFileWriter.WriteToJsonLogin(users, JsonFileName);
        }
    }
}
