// Copyright © Shreyas Makde 2020. All Rights Reserved.

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
        private ProductsController productsController;

        private Mock<IProductContext> mockProductContext;

        [OneTimeSetUp]
        public void SetupMocks()
        {
            mockProductContext = new Mock<IProductContext>();
            productsController = new ProductsController(mockProductContext.Object);
        }

        [Test]
        public void Get_CanReturn_Products()
        {
        }
    }
}
