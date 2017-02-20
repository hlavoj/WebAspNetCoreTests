using System.Collections.Generic;
using WebAspNetCoreTests.Models;

namespace WebAspNetCoreTests.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetObject(int productId);
    }
}