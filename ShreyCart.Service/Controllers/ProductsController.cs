using System.Collections.Generic;
using System.Linq;
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

        // GET api/products
        public IEnumerable<Product> Get()
        {
            return _productContext.GetProducts();
        }

        // GET api/products/5
        public Product Get(int id)
        {
            return _productContext.GetProducts().FirstOrDefault(x => x.Identifier == id);
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
        public IHttpActionResult AddNewProduct(EmberProduct product)
        {
            _productContext.AddNewProduct(product);
            return Ok("Product Added Successfully");
        }
    }
}
