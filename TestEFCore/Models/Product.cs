using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TestEFCore.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        [RegularExpression(@"^[1-9]\d{0,15}(\.\d{1,2})?$", ErrorMessage = "Invalid Price (must be positive, of type decimal(18, 2))")]
        public decimal Price { get; set; }
    }
}
