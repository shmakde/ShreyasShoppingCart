using System.Collections.Generic;
using ShreyCart.Domain;

namespace ShreyCart.Abstractions
{
    public interface IDataSource
    {
        IEnumerable<Product> LoadProducts(string path);
    }
}
