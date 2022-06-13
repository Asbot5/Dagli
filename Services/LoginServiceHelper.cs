using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dagli.Models;
using Dagli.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace Dagli.Services
{
    public class LoginServiceHelper : ILoginService
    {
        private List<Login> users;
        private JsonFileLoginUser JsonFileUserService;

        public LoginServiceHelper(JsonFileLoginUser jsonFileService)
        {
            JsonFileUserService = jsonFileService;
            users = JsonFileUserService.GetJsonUsers();
        }

        public void AddUser(Login user)
        {
            user.Password = PasswordHash(user.Email, user.Password);
            users.Add(user);
            JsonFileUserService.SaveJsonUser(users);
        }

        public List<Login> GetLogins()
        {
            return users;
        }

        public Login GetLogin(string email)
        {
            foreach (Login login in users)
            {
                if (login.Email == email)
                {
                    return login;
                }
            }
            return new Login();
        }
        
        public bool CheckPassword(string userName, string password)
        {
            bool loggedIn = false;
            foreach (var v in users)
            {
                if (v.Email == userName)
                {
                    string jsonPassword = v.Password;
                    PasswordHasher<string> pw = new PasswordHasher<string>();
                    var verificationResult = pw.VerifyHashedPassword(userName, jsonPassword, password);
                    if (verificationResult == PasswordVerificationResult.Success)
                        loggedIn = true;
                    else
                        loggedIn = false;
                    return loggedIn;
                }
            }
            return loggedIn;
        }
        public string PasswordHash(string userName, string password)
        {
            PasswordHasher<string> pw = new PasswordHasher<string>();
            string passwordHashed = pw.HashPassword(userName, password);
            return passwordHashed;
        }
    }
}

