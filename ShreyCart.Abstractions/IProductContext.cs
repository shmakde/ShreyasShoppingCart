using ShreyCart.Domain;

namespace ShreyCart.Abstractions
{
    public interface IProductContext
    {
        EmberDataWrapper GetAllProducts();
        void AddNewProduct(string title, string color, string supplier, double price, string imageName);
        void AddNewProduct(Product product);
    }
}
