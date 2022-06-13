using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dagli.Models;
using Dagli.JsonHelpers;

namespace Dagli.Repositories
{
    public class JsonOrderRepository
    {
        string JsonFileNameOrders = @".\Data\JsonOrders.json";

        public Dictionary<int,Order> AllOrders()
        {
            return JsonFileReader.ReadJsonOrders(JsonFileNameOrders);
        }

        public void AddOrder(Order order)
        {
            Dictionary<int, Order> orders = AllOrders();

            int i;
            if (orders is null || orders.Count == 0)
            {
                orders = new Dictionary<int, Order>();
                order.ID = 1;
                orders.Add(1, order);
            }
            else
            {
                i = MaxCount(orders);
                order.ID = i;
                orders.Add(i, order);
            }

            JsonFileWriter.WriteToJsonOrders(orders, JsonFileNameOrders);
        }

        public Dictionary<int, Order> FilterOrders(string e)
        {
            Dictionary<int, Order> filterOrders = new Dictionary<int, Order>();
            if (e != null)
            {
                foreach (Order order in AllOrders().Values)
                {
                    if (order.User.ZipCode.ToString().StartsWith(e))
                    {
                        filterOrders.Add(order.ID, order);
                    }
                }
            }
            return filterOrders;
        }

        public void DeleteOrder(int id)
        {
            Dictionary<int, Order> orders = AllOrders();
            orders.Remove(id);
            JsonFileWriter.WriteToJsonOrders(orders, JsonFileNameOrders);
        }

        public int MaxCount(Dictionary<int, Order> dict)
        {
            int max = dict.Keys.Max() + 1;
            return max;
        }

    }
}
