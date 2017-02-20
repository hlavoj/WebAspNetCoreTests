using Microsoft.AspNetCore.Mvc;
using WebApplicationTemplate.ViewModels.Pricing;
using WebAspNetCoreTests.Repositories;
using WebAspNetCoreTests.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAspNetCoreTests.Controllers
{
    public class PriceController : Controller
    {
        private readonly IPriceResolver priceResolver;
        private readonly ICustomerRepository customerRepository;
        private readonly IProductRepository productRepository;

        public PriceController(IPriceResolver priceResolver, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            this.priceResolver = priceResolver;
            this.customerRepository = customerRepository;
            this.productRepository = productRepository;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(GetPriceViewModel getPriceViewModel)
        {
            if (ModelState.IsValid)
            {
                var product = productRepository.GetObject(getPriceViewModel.ProductId);
                var customer = customerRepository.GetObject(getPriceViewModel.CustomerId);

                getPriceViewModel.Price = priceResolver.GetPrice(customer, product);

                return View(getPriceViewModel);
            }
            return View();
        }
    }
}
