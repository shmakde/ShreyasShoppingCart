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
            var shoppingBasket = _basketContext.GetCart(cartName);
            return shoppingBasket;
        }

        [Route("api/ShreyBasket/{cartname}/Checkout")]
        [HttpGet]
        [HttpPost]
        public IHttpActionResult CheckOut(string cartName)
        {
            _basketContext.Checkout(cartName);
            return Ok();
        }

        [Route("api/ShreyBasket/{cartname}/Add/{productId}/{quantity}")]
        [HttpGet]
        [HttpPut]
        public IHttpActionResult AddProduct(string cartName, int productId, int quantity)
        {
            _basketContext.AddProduct(cartName, productId, quantity);
            return Ok();
        }
    }
}