using WebAspNetCoreTests.Models;

namespace WebAspNetCoreTests.Repositories
{
	public interface ICustomerPriceRepository
	{
		decimal? GetCustomerPrice(Customer customer, Product product);
	}
}