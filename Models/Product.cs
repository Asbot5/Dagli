using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Dagli
{
    public class Product
    {
        public int ID { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Du skal have et navn, og det kan maks være 40 tegn.")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Beskrivelse skal udfyldes, og kan maks fylde 150 tegn")]
        [StringLength(150)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price required")]
        [Range(typeof(decimal), "1", "10000",
        ErrorMessage = "Pris skal være mellem 1 og 10.000 kroner")]
        public decimal Price { get; set; }

        public string ImageName { get; set; }

        [Required(ErrorMessage = "Du skal vælge en produkt-type.")]

        public string ProductType { get; set; }
        public int ProductAmount { get; set; }

        public override string ToString()
        {
            return $"{ProductAmount} {Name} - {Price}";
        }
    }
}