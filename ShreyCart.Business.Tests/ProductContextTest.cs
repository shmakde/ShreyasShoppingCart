// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Data;
using Moq;
using NUnit.Framework;
using ShreyCart.Abstractions;

namespace ShreyCart.Business.Tests
{
    [TestFixture]
    public class ProductContextTest
    {
        private ProductContext productContext;
        private Mock<IProductContextHelper> mockProductContextHelper;
        private Mock<IConnectionSetting> mockConnectionSetting;

        [OneTimeSetUp]
        public void SetupMocks()
        {
            mockConnectionSetting = new Mock<IConnectionSetting>();
            mockProductContextHelper = new Mock<IProductContextHelper>();
            productContext = new ProductContext(mockConnectionSetting.Object, mockProductContextHelper.Object);
        }

        [Test]
        public void ShouldProcessDataSetForEmber()
        {
            // Arrange
            mockProductContextHelper.Setup(x => x.BuildGetAllProductsStoredProcedure(It.IsAny<int>()));
            mockProductContextHelper.Setup(x => x.GetSqlDataSet(It.IsAny<IStoredProcedureQueryWithResults>(), It.IsAny<IConnectionSetting>()));

            // Act
            productContext.GetAllExistingProducts();

            // Assert
            mockProductContextHelper.Verify(x => x.ProcessDataSetForEmber(It.IsAny<DataSet>()), Times.Once);
        }
    }
}
