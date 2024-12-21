using System;
using System.ComponentModel.DataAnnotations;

namespace SU6Rest.Api.Models
{
	public class Customer
	{
		[Key]
		public Guid CusotmerId {get;set;}
		[MaxLength(50)]
		public string CustomerName { get; set; } = string.Empty;
        [Required]
        [MaxLength(15)]
		[Phone]
		public string Phone { get; set; } = string.Empty;
		[MaxLength(50)]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;
		[MaxLength(100)]
		public string Address { get; set; } = string.Empty;
		
	}
}

