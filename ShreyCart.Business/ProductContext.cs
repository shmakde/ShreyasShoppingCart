using ShreyCart.Abstractions;
using ShreyCart.Domain;
using System.Collections.Generic;

namespace ShreyCart.Business
{
    public class ProductContext : IProductContext
    {
        private static IEnumerable<Product> _products;

        private IEnumerable<Product> Products
            => _products ?? (_products = _dataSource.LoadProducts(_config.GetDataSourcePath()));

        private readonly IDataSource _dataSource;

        private readonly IConfig _config;

        public ProductContext(IDataSource dataSource, IConfig config)
        {
            _dataSource = dataSource;
            _config = config;
        }

        public IEnumerable<Product> GetProducts()
        {
            return this.Products;
        }
    }
}
