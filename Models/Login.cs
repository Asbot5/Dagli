using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dagli.Models
{
    public class Login
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Street { get; set; }
        [Required]
        [Range(typeof(int), "1000", "9999",
        ErrorMessage = "Postnummer skal være 4 cifre")]
        public int ZipCode { get; set; }
    }
}
