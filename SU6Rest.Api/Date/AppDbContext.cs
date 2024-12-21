using System;
using Microsoft.EntityFrameworkCore;
using SU6Rest.Api.Models;

namespace SU6Rest.Api.Date
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
		{

		}
		public DbSet<Category> Categopry { get; set; }
		public DbSet<Customer> Customer { get; set; }

		public DbSet<Item> Item { get; set; }
		public DbSet<Sale> Sale { get; set; }
		public DbSet<SaleDetail> SaleDetail { get; set; }
	}

}