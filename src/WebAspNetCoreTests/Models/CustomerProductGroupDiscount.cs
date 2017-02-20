namespace WebAspNetCoreTests.Models
{
	public class CustomerProductGroupDiscount
	{
		public int CustomerProductGroupDiscountId { get; set; }

		public ProductGroup	ProductGroup { get; set; }

		public Customer Customer { get; set; }

		public decimal Discount { get; set; }
	}
}