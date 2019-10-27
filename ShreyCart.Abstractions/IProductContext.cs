using ShreyCart.Domain;
using System.Collections.Generic;

namespace ShreyCart.Abstractions
{
    public interface IProductContext
    {
        IEnumerable<Product> GetProducts();
    }
}
