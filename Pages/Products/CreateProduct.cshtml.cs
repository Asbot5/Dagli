using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dagli.Models;
using Dagli.Interfaces;
using Microsoft.AspNetCore.Http;

namespace Dagli.Pages.Products
{
    public class CreateProductModel : PageModel
    {
        private IProductRepository repository;
        [BindProperty]
        public Product Product { get; set; }
        public Dictionary<int, Product> Products { get; set; }
        public CreateProductModel(IProductRepository repo)
        {
            repository = repo;
        }

        public void OnGet()
        {
            Products = repository.AllProducts();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repository.AddProduct(Product);
            Products = repository.AllProducts();
            return RedirectToPage("AllProducts");
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
