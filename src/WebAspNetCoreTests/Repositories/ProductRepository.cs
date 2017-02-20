using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using WebAspNetCoreTests.Models;

namespace WebAspNetCoreTests.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public ProductRepository(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public IEnumerable<Product> GetAll()
        {
            return _applicationDbContext.Products.ToList();
        }

        public Product GetObject(int productId)
        {
            return _applicationDbContext.Products
                .Include(p => p.ProductGroup)
                .SingleOrDefault(p => p.ProductId == productId);
        }
    }
}
