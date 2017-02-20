namespace WebAspNetCoreTests.Models
{
	public class CustomerPrice
	{
		public int CustomerPriceId { get; set; }

		public Product Product { get; set; }

		public Customer Customer { get; set; }

		public decimal Price { get; set; }
	}
}