// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Data;
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
        private ProductsController productsController;

        private Mock<IProductContext> mockProductContext;

        [OneTimeSetUp]
        public void SetupMocks()
        {
            mockProductContext = new Mock<IProductContext>();
            productsController = new ProductsController(mockProductContext.Object);
        }

        [Test]
        public void ShouldMakeABusinessContextCallTo_GetAllProduct()
        {
            // Arrange
            mockProductContext.Setup(x => x.GetAllExistingProducts());

            // Act
            productsController.GetAllProducts();

            // Assert
            mockProductContext.Verify(x => x.GetAllExistingProducts(), Times.Once);
        }

        [Test]
        public void ShouldMakeABusinessContextCallTo_AddNewProduct()
        {
            // Arrange
            mockProductContext.Setup(
                x => x.AddNewProduct(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<double>(),
                    It.IsAny<string>()));

            mockProductContext.Setup(x => x.AddNewProduct(It.IsAny<IProduct>()));

            // Act
            productsController.AddNewProduct(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<double>(),
                It.IsAny<string>());

            productsController.AddNewProduct(It.IsAny<Product>());

            // Assert
            mockProductContext.Verify(
                x => x.AddNewProduct(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<double>(),
                    It.IsAny<string>()),
                Times.Once);

            mockProductContext.Verify(x => x.AddNewProduct(It.IsAny<IProduct>()));
        }
    }
}
