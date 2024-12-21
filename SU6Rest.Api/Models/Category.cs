using System;
using System.ComponentModel.DataAnnotations;

namespace SU6Rest.Api.Models
{
    public class Category
    {
        [Key]
        public Guid CategoryId { get; set; }
        [Required]
        [MaxLength(50)]
        public string CategoryName { get; set; } = string.Empty;
        public List<Item> Items { get; set; } = new();
        public List<Sale> Sales { get; set; } = new();
    }
}