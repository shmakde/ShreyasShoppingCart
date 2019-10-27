using System.Linq;
using FizzWare.NBuilder;
using FluentAssertions;
using Moq;
using NUnit.Framework;
using ShreyCart.Abstractions;
using ShreyCart.Domain;
using ShreyCart.Service.Controllers;

namespace ShreyCart.Service.Test.Controllers
{
    [TestFixture]
    public class BasketControllerTests
    {
        private BasketController _ShreyBasketController;

        private Mock<IBasketContext> _mockShreyBasketContext;

        [OneTimeSetUp]
        public void SetupMocks()
        {
            _mockShreyBasketContext = new Mock<IBasketContext>();
            _ShreyBasketController = new BasketController(_mockShreyBasketContext.Object);
        }

        [Test]
        public void Get_CanReturn_ShreyCart()
        {
            //Arrange
            var products = Builder<Product>.CreateListOfSize(10).Build().ToList();
            _mockShreyBasketContext.Setup(x => x.GetCart(It.IsAny<string>()))
                .Returns(products);

            //Act
            var response = _ShreyBasketController.Get("testCart");

            //Assert
            _mockShreyBasketContext.Verify(x => x.GetCart(It.IsAny<string>()), Times.Once);
            response.Should().NotBeNull();
            response.Count().Should().Be(10);
        }

        [Test]
        public void CheckOut_CheckoutInContext_IsCalled()
        {
            //Arrange
            _mockShreyBasketContext.Setup(x => x.Checkout(It.IsAny<string>()));

            //Act
            var response = _ShreyBasketController.CheckOut("testCart");

            //Assert
            _mockShreyBasketContext.Verify(x => x.Checkout(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void AddProduct_AddProductInContext_IsCalled()
        {
            //Arrange
            _mockShreyBasketContext.Setup(x => x.AddProduct(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()));

            //Act
            var response = _ShreyBasketController.AddProduct("testCart", 1, 1);

            //Assert
            _mockShreyBasketContext.Verify(x => x.AddProduct(It.IsAny<string>(), It.IsAny<int>(), It.IsAny<int>()),
                Times.Once);
        }
    }
}

