using System.Collections.Generic;
using System.Web;
using System.Web.Http;
using ShreyCart.Abstractions;
using ShreyCart.DataAccess;
using ShreyCart.DataAccess.Connection;
using ShreyCart.DataAccess.StoredProcedures;
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
            var basket = _basketContext.GetCart(cartName);
            return basket;
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

        [Route("api/ShreyBasket/Sample/{cartname}/Add/{productId}/{quantity}/{yes}")]
        [HttpGet]
        [HttpPut]
        public IEnumerable<Product> AddProduct(string cartName, int productId, int quantity, int yes)
        {
            var products = new List<Product>();
            var p = new Product() { Description = "Description", Identifier = 1, Name = "Shreyas", Price = 1.00M, Stock = 1 };

            products.Add(p);

            string command = @"exec dbo.AddPerson 2, 'lnu', 'fnu', 'anu', 'cnu'";
            var mysql = new SqlExecutor();

            mysql.ExecuteNonQuery(command, new ConnectionSetting());
            return products;
        }

        [Route("api/AddPerson/{PersonId}/{LastName}/{FirstName}/{Address}/{City}")]
        [HttpGet]
        [HttpPut]
        public IHttpActionResult AddPerson(int PersonId, string LastName, string FirstName, string Address, string City)
        {
            var ProcAddPerson = new ProcAddPersons("dbo.AddPerson")
                .WithFirstName("Shreyas")
                .WithLastName("Makde")
                .WithPersonId(101)
                .WithAddress("Braeswood")
                .WithCity("Houston")
                .Build();

            new SqlExecutor().ExecuteStoredProcedure(ProcAddPerson, new ConnectionSetting());

            return Ok();
        }

        [Route("api/products")]
        [HttpGet]
        [HttpPut]
        public IEnumerable<EmberProductWithTypeId> GetProducts()
        {
            var emberProducts = new List<EmberProduct>()
            {
                new EmberProduct()
                {
                    title = "Steel Shopping Cart",
                    color = "Silver",
                    supplier = "Walmart",
                    pricecategory = "High",
                    price = 1500.5M,
                    image = "https://upload.wikimedia.org/wikipedia/commons/c/cb/Crane_estate_(5).jpg",
                    description = "This is a steel shopping cart used for multipurpose stores, with an extended 2-year manufacturer warantee."
                },
                new EmberProduct()
                {
                    title = "Steel Shopping Cart",
                    color = "Silver",
                    supplier = "Walmart",
                    pricecategory = "High",
                    price = 1500.5M,
                    image = "https://upload.wikimedia.org/wikipedia/commons/c/cb/Crane_estate_(5).jpg",
                    description = "This is a steel shopping cart used for multipurpose stores, with an extended 2-year manufacturer warantee."
                },
                new EmberProduct()
                {
                    title = "Steel Shopping Cart",
                    color = "Silver",
                    supplier = "Walmart",
                    pricecategory = "High",
                    price = 1500.5M,
                    image = "https://upload.wikimedia.org/wikipedia/commons/c/cb/Crane_estate_(5).jpg",
                    description = "This is a steel shopping cart used for multipurpose stores, with an extended 2-year manufacturer warantee."
                }
            };

            var emberProductsWithTypeId = new List<EmberProductWithTypeId>();

            emberProductsWithTypeId.Add(new EmberProductWithTypeId() { id = "steel-shopping-cart", type = "products", attributes = emberProducts[0] });
            emberProductsWithTypeId.Add(new EmberProductWithTypeId() { id = "woodden-shopping-cart", type = "products", attributes = emberProducts[1] });
            emberProductsWithTypeId.Add(new EmberProductWithTypeId() { id = "plastic-shopping-cart", type = "products", attributes = emberProducts[2] });

            //HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            //HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, PATCH, PUT, DELETE, OPTIONS");
            //HttpContext.Current.Response.Headers.Add("Access-Control-Allow-Headers", "Origin, Content-Type, X-Auth-Token");
            //HttpContext.Current.Response.Headers.Add("Origin", "http://localhost:4200");


            return emberProductsWithTypeId;
        }
    }
}