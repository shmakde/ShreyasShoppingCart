using System.Collections.Generic;
using System.Web.Http;
using ShreyCart.Abstractions;
using ShreyCart.Domain;

namespace ShreyCart.Service.Controllers
{
    public class BasketController : ApiController
    {
        private readonly IBasketContext _basketContext;

        public BasketController(IBasketContext basketContext)
        {
            _basketContext = basketContext;
        }

        [Route("api/ShreyBasket/{cartname}")]
        [HttpGet]
        public IEnumerable<Product> Get(string cartName)
        {
            throw new System.NotImplementedException();
        }

        [Route("api/ShreyBasket/{cartname}/Checkout")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult CheckOut(string cartName)
        {
            throw new System.NotImplementedException();
        }

        [Route("api/ShreyBasket/{cartname}/Add/{productId}/{quantity}")]
        [HttpGet]
        [HttpPut]
        public IHttpActionResult AddProduct(string cartName, int productId, int quantity)
        {
            throw new System.NotImplementedException();
        }

        [Route("api/ShreyBasket/Sample/{cartname}/Add/{productId}/{quantity}/{yes}")]
        [HttpGet]
        [HttpPut]
        public IEnumerable<Product> AddProduct(string cartName, int productId, int quantity, int yes)
        {
            throw new System.NotImplementedException();
        }
    }
}