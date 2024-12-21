using System;
using System.ComponentModel.DataAnnotations;

namespace SU6Rest.Api.Models
{
	public class Sale
	{
		[Key]
		public Guid SaleId { get; set; }
		public Guid CustomerId { get; set; }
		[MaxLength(12)]
		public string InvoiceNumber { get; set; } = string.Empty;
		public DateTime? IssueDate { get; set; }
		public double Total { get; set; }
		public int Discount { get; set; }
		public double GrandTotal { get; set; }

		public List<SaleDetail> SaleDetails { get; set; } = new();
	}
}

