using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dagli.Interfaces;
using Dagli.Models;
using Microsoft.AspNetCore.Http;
using Dagli.Pages.Products;


namespace Dagli.Pages.LoginService
{
    public class LoginToSideModel : PageModel
    {
        ILoginService userService;
        public int adminLogIn
        {
            get { return Convert.ToInt32(HttpContext.Session.GetInt32("Admin")); }
        }
        public int validUser
        {
            get { return Convert.ToInt32(HttpContext.Session.GetInt32("Login")); }
        }
        public LoginToSideModel(ILoginService service)
        {
            userService = service;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            return CheckLogin();
        }

        public IActionResult OnPostLogOut()
        {
            return LogOut();
        }
        IActionResult CheckLogin()
        {
            string password;
            string userName;
            userName = Request.Form["Email"];
            password = Request.Form["Password"];
            bool checkLogin = userService.CheckPassword(userName, password);
            if (checkLogin == true)
            {
                if (userName == "admin@admin.dk")
                {
                    HttpContext.Session.SetInt32("Login", 1);
                    HttpContext.Session.SetString("UserName", userName);
                    HttpContext.Session.SetInt32("Admin", 1);
                    return Redirect("~/Products/AllProducts");
                }
                else
                {
                    HttpContext.Session.SetInt32("Login", 1);
                    HttpContext.Session.SetString("UserName", userName);
                    HttpContext.Session.SetInt32("Admin", 0);
                    return Redirect("~/Products/AllProducts");
                }
            }
            else
            {
                HttpContext.Session.SetInt32("Login", 0);
                HttpContext.Session.SetString("UserName", "");
                return Page();
            }
        }

        IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("LoginToSide");
        }

    }
}
