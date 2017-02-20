namespace WebAspNetCoreTests.Models
{
	public class BasicPrice
	{
		public int BasicPriceId { get; set; }

		public Product Product { get; set; }

		public decimal Price { get; set; }
	}
}