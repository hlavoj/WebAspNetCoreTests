using System.Linq;
using WebAspNetCoreTests.Models;

namespace WebAspNetCoreTests.Repositories
{
	public class BasicPriceRepository : IBasicPriceRepository
	{
		private readonly ApplicationDbContext applicationDbContext;

		public BasicPriceRepository(ApplicationDbContext applicationDbContext)
		{
			this.applicationDbContext = applicationDbContext;
		}

		public decimal? GetBasicPriceForProduct(Product product)
		{
			return applicationDbContext.BasicPrices.SingleOrDefault(p => p.Product.ProductId == product.ProductId)?.Price;
		}
	}
}