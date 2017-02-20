using System.Collections.Generic;
using System.Linq;
using WebAspNetCoreTests.Models;

namespace WebAspNetCoreTests.Repositories
{
	public class CustomerRepository : ICustomerRepository
	{
		private readonly ApplicationDbContext applicationDbContext;

		public CustomerRepository(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public IEnumerable<Customer> GetAll()
		{
			return applicationDbContext.Customers.ToList();
		}

		public Customer GetObject(int customerId)
		{
			return applicationDbContext.Customers.SingleOrDefault(c => c.CustomerId == customerId);
		}
	}
}