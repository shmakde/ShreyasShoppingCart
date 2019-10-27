using System.Collections.Generic;
using System.IO;
using System.Linq;
using CsvHelper;
using ShreyCart.Abstractions;
using ShreyCart.Domain;

namespace ShreyCart.Common
{
    public class CsvDataSource : IDataSource
    {
        public IEnumerable<Product> LoadProducts(string path)
        {
            var csv = new CsvReader(File.OpenText(path));
            var products = new List<Product>();
            var p = new Product() { Description = "Description", Identifier = 1, Name = "Shreyas", Price = 1.00M, Stock = 1 };

            products.Add(p);
            return products.ToList();
        }
    }
}
