using Dagli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dagli.Pages;

namespace Dagli.Services
{
    public class ShoppingCartService
    {
        List<Product> _cartProducts;
        public ShoppingCartService()
        {
            _cartProducts = new List<Product>();
        }

        public void Add(Product product)
        {
            foreach (Product p in _cartProducts)
            {
                if (product.ID == p.ID)
                {
                    p.ProductAmount = p.ProductAmount + 1;
                    return;
                }
            }
            _cartProducts.Add(product);
        }

        public List<Product> GetOrderedProducts()
        {
            return _cartProducts;
        }

        public void RemoveAllFromCart()
        {
            _cartProducts.Clear();
        }

        public void RemoveProduct(int id)
        {
            foreach (Product product in _cartProducts)
            {
                if (product.ID == id)
                {
                    _cartProducts.Remove(product);
                    return;
                }
            }
        }

        public void ReduceAmount(int id)
        {
            foreach (Product product in _cartProducts)
            {
                if (product.ID == id)
                {
                    product.ProductAmount = product.ProductAmount - 1;

                    if (product.ProductAmount <= 0)
                    {
                        RemoveProduct(id);
                        return;
                    }
                }
            }
        }

        public void AddAmount(int id)
        {
            foreach (Product product in _cartProducts)
            {
                if (product.ID == id)
                {
                    product.ProductAmount = product.ProductAmount + 1;
                }
            }
        }

        public decimal CalculateTotalPrice()
        {
            decimal totalPrice = 0.00M;

            foreach (Product product in _cartProducts)
            {
                totalPrice = totalPrice + (product.Price * product.ProductAmount);
            }
            return totalPrice;
        }
    }
}