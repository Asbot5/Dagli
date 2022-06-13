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
    public class EditProductModel : PageModel
    {
        private IProductRepository repository;
        [BindProperty]
        public Product Product { get; set; }
        public Dictionary<int, Product> Products { get; set; }
        public EditProductModel(IProductRepository repo)
        {
            repository = repo;
        }
        public IActionResult OnGet(int ID)
        {
            Product = repository.GetProduct(ID);
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            repository.UpdateProduct(Product);
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
