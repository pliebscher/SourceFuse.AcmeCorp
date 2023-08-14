using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeCorp.Data.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Contact.Id))]
        public int ShipToContactId { get; set; }

        public List<OrderItem> Items { get; set; } = new List<OrderItem>();
    }
}
