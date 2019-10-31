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
    public class ProductsControllerTests
    {
        private ProductsController _productsController;

        private Mock<IProductContext> _mockProductContext;

        [OneTimeSetUp]
        public void SetupMocks()
        {
            _mockProductContext = new Mock<IProductContext>();
            _productsController = new ProductsController(_mockProductContext.Object);
        }

        [Test]
        public void Get_CanReturn_Products()
        {
            
        }
    }
}
