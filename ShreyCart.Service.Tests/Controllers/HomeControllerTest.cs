// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ShreyCart.Service;
using ShreyCart.Service.Controllers;

namespace ShreyCart.Service.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
