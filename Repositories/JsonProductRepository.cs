using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dagli.Interfaces;
using Newtonsoft.Json;
using Dagli.JsonHelpers;

namespace Dagli.Repositories
{
    public class JsonProductRepository : IProductRepository
    {
        string JsonFileName = @".\Data\JsonProducts.json";

        public Dictionary<int,Product> AllProducts()
        {
            return JsonFileReader.ReadJson(JsonFileName);
        }
        public string errorUpdate;
        public void AddProduct(Product product)
        {
            Dictionary<int, Product> products = AllProducts();
            int i;
            if (products is null || products.Count == 0)
            {
                products = new Dictionary<int, Product>();
                product.ID = 1;
                product.ProductAmount = 1;
                products.Add(1, product);
            }
            else
            {
                i = MaxCount(products);
                product.ID = i;
                product.ProductAmount = 1;
                products.Add(i, product);
            }
            JsonFileWriter.WriteToJson(products, JsonFileName);
        }
        public Product GetProduct(int ID)
        {
            foreach (var product in AllProducts().Values)
            {
                if (product.ID == ID)
                    return product;
            }
            return new Product();
        }
        public Dictionary<int, Product> FilterProduct(string e)
        {
            Dictionary<int, Product> filterProducts = new Dictionary<int, Product>();
            if (e != null)
            {
                foreach (Product product in AllProducts().Values)
                {
                    if (product.ProductType.ToLower().StartsWith(e.ToLower()))
                    {
                        filterProducts.Add(product.ID, product);
                    }
                }
            }
            return filterProducts;
        }
        public void UpdateProduct(Product product)
        {
            Dictionary<int, Product> products = AllProducts();
            Product oldProduct = products[product.ID];
            oldProduct.Name = product.Name;
            oldProduct.Description = product.Description;
            oldProduct.Price = product.Price;
            oldProduct.ImageName = product.ImageName;
            oldProduct.ProductType = product.ProductType;
            JsonFileWriter.WriteToJson(products, JsonFileName);
        }
        public void DeleteProduct(int id)
        {
            Dictionary<int, Product> products = AllProducts();
            products.Remove(id);
            JsonFileWriter.WriteToJson(products, JsonFileName);
        }

        public int MaxCount(Dictionary<int, Product> dict)
        {
            int max = dict.Keys.Max() + 1;
            return max;
        }
    }
}