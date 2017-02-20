using System.Collections.Generic;
using WebAspNetCoreTests.Models;

namespace WebAspNetCoreTests.Repositories
{
	public interface ICustomerRepository
	{
		IEnumerable<Customer> GetAll();

		Customer GetObject(int customerId);
	}
}