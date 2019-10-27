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
    }
}