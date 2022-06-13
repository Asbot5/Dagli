using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Dagli.Repositories;
using Dagli.Models;

namespace Dagli.Pages.Admin
{
    public class OrderAdministrationModel : PageModel
    {
        private JsonOrderRepository repository;
        public Login UserLogin { get; set; }
        [BindProperty]
        public Order Order { get; set; }
        public Dictionary<int, Order> Orders { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Filter { get; set; }
        public string totalPrice { get; set; }

        public OrderAdministrationModel(JsonOrderRepository repo)
        {
            repository = repo;
        }


        public IActionResult OnGet()
        {
            Orders = repository.AllOrders();

            if (!string.IsNullOrEmpty(Filter))
            {
                Orders = repository.FilterOrders(Filter);
            }

            return Page();
        }
        public decimal CalculateTotalPrice(int ID)
        {
            decimal totalPrice = 0.00M;

            foreach (Order order in Orders.Values)
            {
                if (order.ID == ID)
                {
                    foreach (Product product in order.Products)
                    {
                        totalPrice = totalPrice + (product.Price * product.ProductAmount);
                    }
                }
            }
            return totalPrice;
        }


        public IActionResult OnPostDelete(int id)
        {
            repository.DeleteOrder(id);
            return RedirectToPage("OrderAdministration");
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
