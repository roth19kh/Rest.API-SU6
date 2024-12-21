using System;
using System.ComponentModel.DataAnnotations;

namespace SU6Rest.Api.Models
{
	public class Item
	{
        [Key]
        public Guid ItemId { get; set; }
        public Guid CategoryId { get; set; } 
        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Qty { get; set; }
        public string Image { get; set; } = string.Empty;
        public bool IsStock { get; set; }
    }
}

