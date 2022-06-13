using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dagli.Models;

namespace Dagli.Interfaces
{
    public interface IProductRepository
    {
        Dictionary<int, Product> FilterProduct(string e);
        Dictionary<int, Product> AllProducts();
        void AddProduct(Product product);
        void DeleteProduct(int ID);
        void UpdateProduct(Product product);
        Product GetProduct(int ID);
    }
}
