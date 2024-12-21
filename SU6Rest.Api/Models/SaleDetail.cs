using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SU6Rest.Api.Models
{
	public class SaleDetail
	{
		public Guid SaleDetailId { get; set; }
		public Guid SaleId { get; set; }
		//[ForeignKey("Item")]
		public Guid ItemId { get; set; }
		public double Price { get; set; }
		public int Qty { get; set; }
		public double Total { get; set; }

		//public Item? Item { get; set; }
	}
}

