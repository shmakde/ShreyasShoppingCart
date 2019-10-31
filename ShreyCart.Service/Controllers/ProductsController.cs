using System.Web.Http;
using ShreyCart.Abstractions;
using ShreyCart.Domain;

namespace ShreyCart.Service.Controllers
{
    public class ProductsController : ApiController
    {
        private readonly IProductContext _productContext;

        public ProductsController(IProductContext productContext)
        {
            _productContext = productContext;
        }

        [Route("api/products")]
        [HttpGet]
        public EmberDataWrapper GetAllProducts()
        {
            return _productContext.GetAllProducts();
        }

        [Route("api/addproduct/{title}/{color}/{supplier}/{price}/{imageName}")]
        [HttpPost]
        public IHttpActionResult AddNewProduct(string title, string color, string supplier, double price, string imageName)
        {
            _productContext.AddNewProduct(title, color, supplier, price, imageName);
            return Ok("Product Added Successfully");
        }

        [Route("api/addproduct")]
        [HttpPost]
        public IHttpActionResult AddNewProduct(Product product)
        {
            _productContext.AddNewProduct(product);
            return Ok("Product Added Successfully");
        }
    }
}
