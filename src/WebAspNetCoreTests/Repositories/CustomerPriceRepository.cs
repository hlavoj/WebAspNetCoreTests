using System.Linq;
using WebAspNetCoreTests.Models;

namespace WebAspNetCoreTests.Repositories
{
	public class CustomerPriceRepository : ICustomerPriceRepository
	{
		private readonly ApplicationDbContext applicationDbContext;

		public CustomerPriceRepository(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public decimal? GetCustomerPrice(Customer customer, Product product)
		{
			return applicationDbContext.CustomerPrices.SingleOrDefault(p => (p.Customer.CustomerId == customer.CustomerId) && (p.Product.ProductId == product.ProductId))?.Price;
		}
	}
}