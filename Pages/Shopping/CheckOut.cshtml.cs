using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dagli.Repositories;
using Dagli.Services;
using Dagli.Models;
using Dagli.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Dagli.Pages.Shopping
{
    public class CheckOutModel : PageModel
    {
        
        private JsonOrderRepository repository;
        private ShoppingCartService cart;
        ILoginService userService;

        [BindProperty]
        public Login UserLogin { get; set; }
        public Order Order { get; set; }

        public string userName { get; set; }

        public List<Product> checkoutList { get; set; }

        public string totalPrice { get; set; }

        public CheckOutModel(JsonOrderRepository repo, ShoppingCartService cartService, ILoginService users)
        {
            repository = repo;
            cart = cartService;
            userService = users;
        }

        public void OnGet()
        {
            checkoutList = cart.GetOrderedProducts();
            totalPrice = cart.CalculateTotalPrice().ToString();

            userName = HttpContext.Session.GetString("UserName");

            List<Login> users = userService.GetLogins();

            if (HttpContext.Session.GetString("UserName") != null)
            {
                foreach (Login login in users)
                {
                    if (login.Email == userName)
                    {
                        UserLogin = login;
                    }
                }
            }
        }

        public IActionResult OnPostConfirm()
        {
            List<Login> users = userService.GetLogins();
            Order order = new Order();

            userName = HttpContext.Session.GetString("UserName");

            if (HttpContext.Session.GetString("UserName") != null)
            {
                foreach (Login login in users)
                {
                    if (login.Email == userName)
                    {
                        order.User = login;
                    }
                }
            }

            order.Products = cart.GetOrderedProducts();
            repository.AddOrder(order);
            cart.RemoveAllFromCart();
            return RedirectToPage("Confirmation");
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
