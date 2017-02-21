using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAspNetCoreTests.Models;
using WebAspNetCoreTests.Repositories;
using WebAspNetCoreTests.Services;
using Xunit;

namespace WebAspNetCoreTests.Test
{
    public class PriceResolverTestsFakes
    {
        [Fact]
        public void BasicPrice()
        {
            // arrange
            var resolver = new PriceResolver(
                new FakeBasicPriceRepository(),
                new FakeCustomerProductGroupDiscountRepository_NoDiscounts(),
                new FakeCustomerPriceRepository_NoPrices());

            // act
            var resultPrice = resolver.GetPrice(
                new Customer { Name = "FakeCustomer1" },
                new Product
                {
                    ProductNumber = "FakeProduct1",
                    ProductGroup = new ProductGroup
                    {
                        Name = "FakeGroup1"
                    }
                });

            // assert
            Assert.Equal(100, resultPrice);
        }

        [Fact]
        public void CustomerPrice()
        {
            // arrange
            var resolver = new PriceResolver(
                new FakeBasicPriceRepository(),
                new FakeCustomerProductGroupDiscountRepository_NoDiscounts(),
                new FakeCustomerPriceRepository());

            // act
            var resultPrice = resolver.GetPrice(
                new Customer { Name = "FakeCustomer2" },
                new Product
                {
                    ProductNumber = "FakeProduct2",
                    ProductGroup = new ProductGroup
                    {
                        Name = "FakeGroup1"
                    }
                });

            // assert
            Assert.Equal(90, resultPrice);
        }
    }

    // ******* fakes2 *******

    public class FakeCustomerPriceRepository : ICustomerPriceRepository
    {
        public decimal? GetCustomerPrice(Customer customer, Product product)
        {
            if (customer.Name== "FakeCustomer2" && product.ProductNumber== "FakeProduct2")
            {
                return 90;
            }
            return null;
        }
    }


    // ******* fakes1 *******

    public class FakeCustomerPriceRepository_NoPrices : ICustomerPriceRepository
    {
        public decimal? GetCustomerPrice(Customer customer, Product product)
        {
            return null;
        }
    }

    public class FakeCustomerProductGroupDiscountRepository_NoDiscounts : ICustomerProductGroupDiscountRepository
    {
        public decimal? GetDiscountForCustomerAndProductGroup(Customer customer, ProductGroup productGroup)
        {
            return null;
        }
    }

    public class FakeBasicPriceRepository : IBasicPriceRepository
    {
        public decimal? GetBasicPriceForProduct(Product product)
        {
            switch (product.ProductNumber)
            {
                case "FakeProduct1":
                    return 100;
                case "FakeProduct2":
                    return 200;
                default:
                    return null;
            }
        }
    }
}
