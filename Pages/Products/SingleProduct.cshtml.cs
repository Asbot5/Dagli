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
    public class SingleProductModel : PageModel
    {
        private IProductRepository repository;
        [BindProperty]
        public Product Product { get; set; }
        public Dictionary<int, Product> Products { get; set; }
        public SingleProductModel(IProductRepository repo)
        {
            repository = repo;
        }

        
        public List<string> Data { get; set; }

        public IActionResult OnGet(int ID)
        {
            Product = repository.GetProduct(ID);
            return Page();
        }

        public IActionResult OnPostDelete(int ID)
        {
            repository.DeleteProduct(ID);
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
