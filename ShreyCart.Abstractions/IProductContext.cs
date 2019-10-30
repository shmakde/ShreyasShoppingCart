using ShreyCart.Domain;
using System.Collections.Generic;

namespace ShreyCart.Abstractions
{
    public interface IProductContext
    {
        IEnumerable<Product> GetProducts();
        EmberDataWrapper GetAllProducts();
        void AddNewProduct(string title, string color, string supplier, double price, string imageName);
        void AddNewProduct(EmberProduct product);
    }
}
