// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Web.Http;
using ShreyCart.Abstractions;
using ShreyCart.Domain;

namespace ShreyCart.Service.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductContext productContext;

        public ProductsController(IProductContext productContext)
        {
            this.productContext = productContext;
        }

        [Route("api/products")]
        [HttpGet]
        public EmberDataWrapper GetAllProducts()
        {
            var existingProducts = productContext.GetAllExistingProducts();
            return (EmberDataWrapper)existingProducts;
        }

        [Route("api/addproduct/{title}/{color}/{supplier}/{price}/{imageName}")]
        [HttpPost]
        public IHttpActionResult AddNewProduct(string title, string color, string supplier, double price, string imageName)
        {
            productContext.AddNewProduct(title, color, supplier, price, imageName);
            return Ok("Product Added Successfully");
        }

        [Route("api/addproduct")]
        [HttpPost]
        public IHttpActionResult AddNewProduct(Product product)
        {
            productContext.AddNewProduct(product);
            return Ok("Product Added Successfully");
        }
    }
}
