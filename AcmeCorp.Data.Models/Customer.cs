using System;

using System.ComponentModel.DataAnnotations;

namespace AcmeCorp.Data.Models
{
    public class Customer
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<Contact> Contacts { get; set; } = new List<Contact>();
    }
}