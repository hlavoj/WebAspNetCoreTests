using WebAspNetCoreTests.Models;

namespace WebAspNetCoreTests.Repositories
{
	public interface ICustomerProductGroupDiscountRepository
	{
		decimal? GetDiscountForCustomerAndProductGroup(Customer customer, ProductGroup productGroup);
	}
}