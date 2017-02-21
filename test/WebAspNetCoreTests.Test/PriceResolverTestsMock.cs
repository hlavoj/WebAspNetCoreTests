using Moq;
using WebAspNetCoreTests.Models;
using WebAspNetCoreTests.Repositories;
using WebAspNetCoreTests.Services;
using Xunit;

namespace WebAspNetCoreTests.Test
{
    public class PriceResolverTestsMock
    {
        [Fact]
        public void BasicPrice()
        {
            // arrange
            var basicPriceRepository = new Mock<IBasicPriceRepository>();
            basicPriceRepository.Setup(r => r.GetBasicPriceForProduct(It.Is<Product>(product => product.ProductNumber == "neco"))).Returns(100);

            var resolver = new PriceResolver(basicPriceRepository.Object,
                new Mock<ICustomerProductGroupDiscountRepository>().Object,
                new Mock<ICustomerPriceRepository>().Object);

            // act
            var result = resolver.GetPrice(
                new Customer { Name = "nekdo" },
                new Product
                {
                    ProductNumber = "neco",
                    ProductGroup = new ProductGroup
                    {
                        Name = "anyGroup"
                    }
                });

            //assert
            Assert.Equal(100, result);

        }

        [Fact]
        public void CustomerPrice()
        {
            // arrange
            var basicPriceRepository = new Mock<IBasicPriceRepository>();
            basicPriceRepository.Setup(r => r.GetBasicPriceForProduct(It.Is<Product>(product => product.ProductNumber == "neco"))).Returns(100);

            var customerPriceRepository = new Mock<ICustomerPriceRepository>();
            customerPriceRepository.Setup(r => r.GetCustomerPrice(
                It.Is<Customer>(customer => customer.Name == "nekdo"),
                It.Is<Product>(product => product.ProductNumber == "neco"))).Returns(90);

            var resolver = new PriceResolver(basicPriceRepository.Object,
                new Mock<ICustomerProductGroupDiscountRepository>().Object,
                customerPriceRepository.Object);

            // act
            var result = resolver.GetPrice(
                new Customer { Name = "nekdo" },
                new Product
                {
                    ProductNumber = "neco",
                    ProductGroup = new ProductGroup
                    {
                        Name = "anyGroup"
                    }
                });

            //assert
            Assert.Equal(90, result);
        }


    }
}
