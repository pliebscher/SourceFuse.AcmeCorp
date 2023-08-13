using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeCorp.Data.Models
{
    public class OrderItem
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Order.Id))]
        public int OrderId { get; set; }

        [Required]
        [ForeignKey(nameof(Product.Id))]
        public int ProductId { get; set; }

    }
}
