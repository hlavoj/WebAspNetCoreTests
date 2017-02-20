using WebAspNetCoreTests.Models;

namespace WebAspNetCoreTests.Services
{
	public interface IPriceResolver
	{
		decimal? GetPrice(Customer customer, Product product);
	}
}