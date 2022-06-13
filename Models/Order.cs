using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dagli.Models
{
    public class Order
    {
        public int ID { get; set; }

        public List<Product> Products { get; set; }

        public Login User { get; set; }
    }
}
