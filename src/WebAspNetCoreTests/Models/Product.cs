namespace WebAspNetCoreTests.Models
{
	public class Product
	{
		public int ProductId { get; set; }

		public string ProductNumber { get; set; }

		public ProductGroup ProductGroup { get; set; }
	}
}