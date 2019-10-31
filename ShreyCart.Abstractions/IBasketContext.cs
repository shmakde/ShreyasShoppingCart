using ShreyCart.Domain;
using System.Collections.Generic;

namespace ShreyCart.Abstractions
{
    public interface IBasketContext
    {
        void AddProductToCart(string cartName, int productId, int quantity);
        void Checkout(string cartName);
        List<Product> GetCart(string cartName);
    }
}
