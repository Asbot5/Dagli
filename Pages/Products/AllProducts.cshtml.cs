using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dagli.Models;
using Dagli.Interfaces;
using Dagli.Services;
using Dagli.Pages.Shopping;
using Microsoft.AspNetCore.Http;

namespace Dagli.Pages.Products
{
    public class AllProductsModel : PageModel
    {
        private IProductRepository repository;
        [BindProperty]
        public Product Product { get; set; }
        public Dictionary<int, Product> Products { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }
        public List<Product> ShoppingList { get; set; }
        public ShoppingCartService CartService { get; }
        public AllProductsModel(IProductRepository repo, ShoppingCartService cart)
        {
            repository = repo;
            CartService = cart;
        }

        public IActionResult OnGet()
        {
            Products = repository.AllProducts();

            if (!string.IsNullOrEmpty(Filter))
            {
                Products = repository.FilterProduct(Filter);
            }
            return Page();
        }

        public IActionResult OnPostAddToCart(int id)
        {
            Product product = repository.GetProduct(id);
            CartService.Add(product);
            ShoppingList = CartService.GetOrderedProducts();
            Products = repository.AllProducts();
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