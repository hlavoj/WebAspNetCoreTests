using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationTemplate.ViewModels.Pricing
{
	public class GetPriceViewModel
	{
		[Required]
		[Display(Name = "Customer")]
		public int CustomerId { get; set; }

		[Required]
		[Display(Name = "Product")]
		public int ProductId { get; set; }

		public decimal? Price { get; set; }
	}
}