using ShreyCart.Abstractions;
using ShreyCart.DataAccess;
using ShreyCart.DataAccess.StoredProcedures;
using ShreyCart.Domain;
using System.Collections.Generic;
using System.Data;

namespace ShreyCart.Business
{
    public class ProductContext : IProductContext
    {
        private static IEnumerable<Product> _products;

        private IEnumerable<Product> Products
            => _products ?? (_products = _dataSource.LoadProducts(_config.GetDataSourcePath()));

        private readonly IDataSource _dataSource;

        private readonly IConfig _config;
        const int CurrentSessionUserId = 1;
        public ProductContext(IDataSource dataSource, IConfig config)
        {
            _dataSource = dataSource;
            _config = config;
        }

        public EmberDataWrapper GetAllProducts()
        {
            var ProcGetProducts = new ProcGetAllProducts(CurrentSessionUserId)
                .Build();

            var dataSet = new SqlExecutor().ExecuteStoredProcedure(ProcGetProducts, new ConnectionSetting());

            return new EmberDataWrapper { data = ProcessDataSetForEmber(dataSet) };
        }

        public List<EmberProductWithTypeId> ProcessDataSetForEmber(DataSet dataSet)
        {
            var emberProductsWithTypeId = new List<EmberProductWithTypeId>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
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
            return emberProductsWithTypeId;
        }
        public IEnumerable<Product> GetProducts()
        {
            throw new System.NotImplementedException();
        }

        public void AddNewProduct(string title, string color, string suppliername, double price, string imageName)
        {
            var ProcAddNewPerson = new ProcAddNewProduct(CurrentSessionUserId)
                .WithTitle(title)
                .WithColor(color)
                .WithSupplierName(suppliername)
                .WithImageURL(imageName)
                .Build();

            new SqlExecutor().ExecuteStoredProcedure(ProcAddNewPerson, new ConnectionSetting());
        }

        public void AddNewProduct(EmberProduct emberProduct)
        {
            var ProcAddNewPerson = new ProcAddNewProduct(CurrentSessionUserId)
                .WithTitle(emberProduct.title)
                .WithColor(emberProduct.color)
                .WithSupplierName(emberProduct.supplier)
                .WithImageURL(emberProduct.image)
                .Build();

            new SqlExecutor().ExecuteStoredProcedure(ProcAddNewPerson, new ConnectionSetting());
        }

        public void DeleteProduct(int ProductId)
        {
            var ProcAddNewPerson = new ProcDeleteProduct(CurrentSessionUserId)
                .WithProductId(ProductId)
                .Build();

            new SqlExecutor().ExecuteStoredProcedure(ProcAddNewPerson, new ConnectionSetting());
        }
    }
}
