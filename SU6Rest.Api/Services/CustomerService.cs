using System;
using Microsoft.EntityFrameworkCore;
using SU6Rest.Api.Date;
using SU6Rest.Api.Models;

namespace SU6Rest.Api.Services
{
	public class CustomerService:ICustomerService,IDisposable
	{
        private readonly AppDbContext _context;
		public CustomerService(AppDbContext context)
		{
            _context = context;
		}

        public async Task<string> Delete(Guid Id)
        {
            try
            {
                var customer = await _context.Customer.FindAsync(Id);
                if (customer is null)
                    return "Invalid ID";
                _context.Customer.Remove(customer);
                await _context.SaveChangesAsync();

                return "Success";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }

        public void Dispose() => _context?.Dispose();

        //SELECT * FROM Customer WHERE CusomterId=Id
        public async Task<Customer?> GetCustomer(Guid Id)
            => await _context.Customer.FindAsync(Id);

        //Select * from customer
        public async Task<List<Customer>> GetCustomers()
            => await _context.Customer.ToListAsync();

        public async Task<string> Save(Customer cusotmer)
        {
            try
            {
                if (await IsPhoneExist(cusotmer.Phone))
                    return "Phone Number exist";
                cusotmer.CusotmerId = Guid.NewGuid();
                _context.Customer.Add(cusotmer);
                await _context.SaveChangesAsync();
                return "Success";
            }catch(Exception ex)
            {
                return ex.Message.ToString();
            }
        }
        private async Task<bool> IsPhoneExist(string phone)
            => await _context.Customer.AnyAsync(x => x.Phone.Equals(phone));

        public async Task<string> Update(Guid Id, Customer customer)
        {
            try
            {
                var oldCustomer = await _context.Customer.FindAsync(Id);
                if (oldCustomer is null)
                    return "invalid Cusomter";
                _context.Customer.Attach(oldCustomer);
                oldCustomer.Address = customer.Address;
                oldCustomer.Email = customer.Email;
                oldCustomer.CustomerName = customer.CustomerName;
                await _context.SaveChangesAsync();
                return "Success";

            }catch(Exception ex)
            {
                return ex.Message.ToString();
            }
        }
    }
}

