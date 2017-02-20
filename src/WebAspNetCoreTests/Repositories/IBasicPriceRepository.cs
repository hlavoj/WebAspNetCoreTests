using WebAspNetCoreTests.Models;

namespace WebAspNetCoreTests.Repositories
{
	public interface IBasicPriceRepository
	{
		decimal? GetBasicPriceForProduct(Product product);
	}
}