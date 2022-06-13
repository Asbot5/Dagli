using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dagli.Models;
using Dagli.Interfaces;
using Dagli.Services;
using Microsoft.AspNetCore.Http;

namespace Dagli.Pages.LoginService
{
    public class CreateUserModel : PageModel
    {
        ILoginService userService;
        public CreateUserModel(ILoginService service)
        {
            userService = service;
        }
        public Login login { get; set; }
        public string emailError { get; set; }
        public void OnPost()
        {
            List<Login> users = userService.GetLogins();

            if (ModelState.IsValid)
            {
                foreach (Login jsonUser in users)
                {
                    if (jsonUser.Email.ToLower() == Request.Form["Email".ToLower()])
                    {
                        emailError = "En bruger med denne email findes allerede";
                        return;
                    }
                }
            }
            Login user = new Login();
            user.Name = Request.Form["Navn"];
            user.Street = Request.Form["Vej"];
            user.ZipCode = Convert.ToInt32(Request.Form["Postnummer"]);
            user.Email = Request.Form["Email"];
            user.Password = Request.Form["Password"];

            userService.AddUser(user);
        }
        public int adminLogIn
        {
            get { return Convert.ToInt32(HttpContext.Session.GetInt32("Admin")); }
        }
        public int validUser
        {
            get { return Convert.ToInt32(HttpContext.Session.GetInt32("Login")); }
        }
    }
}