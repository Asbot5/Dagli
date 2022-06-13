using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dagli.Services;
using Dagli.Interfaces;
using Dagli.Models;
using Microsoft.AspNetCore.Http;

namespace Dagli.Pages.Shopping
{
    public class ShoppingCartModel : PageModel
    {
        public ShoppingCartService CartService { get; }
        public List<Product> ShoppingList { get; set; }
        private IProductRepository repo;
        [BindProperty]
        public Product Product { get; set; }

        public ShoppingCartModel(IProductRepository repository, ShoppingCartService cart)
        {
            repo = repository;
            CartService = cart;
            ShoppingList = new List<Product>();
        }

        public IActionResult OnGet(int id)
        {
            Product product = repo.GetProduct(id);
            ShoppingList = CartService.GetOrderedProducts();
            return Page();
        }

        public IActionResult OnPostReduceAmount(int id)
        {
            CartService.ReduceAmount(id);
            ShoppingList = CartService.GetOrderedProducts();
            return Page();
        }

        public IActionResult OnPostAddAmount(int id)
        {
            CartService.AddAmount(id);
            ShoppingList = CartService.GetOrderedProducts();
            return Page();
        }

        public IActionResult OnPostDelete(int id)
        {
            CartService.RemoveProduct(id);
            ShoppingList = CartService.GetOrderedProducts();
            return Page();
        }

        public IActionResult OnPostCheckOut()
        {
            return Page();
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
