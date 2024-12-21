using System;
using SU6Rest.Api.Models;

namespace SU6Rest.Api.Services
{
	public interface ICustomerService
	{
		Task<List<Customer>> GetCustomers();
		Task<Customer?> GetCustomer(Guid Id);
		Task<string> Save(Customer cusotmer);
		Task<string> Update(Guid Id, Customer customer);
		Task<string> Delete(Guid Id);
	}
}

