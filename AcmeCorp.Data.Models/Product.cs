using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;

namespace AcmeCorp.Data.Models
{
    public class Product
    {

        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; } = "Description not provided.";

        [Required]
        public double Price { get; set; }


    }
}
