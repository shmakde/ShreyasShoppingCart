using System.Collections.Generic;
using System.Data;
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
        public EmberDataWrapper GetProducts()
        {
            var ProcGetProducts = new GetAllProducts()
            { parameters = new Dictionary<string, object>(), storedProcedureName = "dbo.GetAllProducts" };

            var rows = new SqlExecutor().ExecuteStoredProcedure(ProcGetProducts, new ConnectionSetting()).Tables[0].Rows;

            var emberProductsWithTypeId = new List<EmberProductWithTypeId>();

            foreach (DataRow row in rows)
            {
                emberProductsWithTypeId.Add(new EmberProductWithTypeId()
                {
                    id = row["title"].ToString().Replace(' ', '-'),
                    type = "product",
                    attributes = new EmberProduct()
                    {
                        title = row["title"].ToString(),
                        color = row["color"].ToString(),
                        supplier = row["suppliername"].ToString(),
                        pricecategory = row["pricecategory"].ToString(),
                        price = decimal.Parse(row["price"].ToString()),
                        image = row["imageurl"].ToString(),
                        description = row["description"].ToString()
                    }
                });
            }

            return new EmberDataWrapper { data = emberProductsWithTypeId };
        }
    }
}