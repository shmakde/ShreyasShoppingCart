using ShreyCart.Abstractions;
using ShreyCart.Domain;
using System.Collections.Generic;

namespace ShreyCart.Business
{
    public class BasketContext : IBasketContext
    {
        private static Dictionary<string, List<Product>> _baskets;
        private Dictionary<string, List<Product>> Baskets
            => _baskets ?? (_baskets = new Dictionary<string, List<Product>>());

        private readonly IProductContext _productContext;
        public BasketContext(IProductContext productContext)
        {
            _productContext = productContext;
        }

        public void AddProductToCart(string cartName, int productId, int quantity)
        {
            throw new System.NotImplementedException();
        }

        public void Checkout(string cartName)
        {
            throw new System.NotImplementedException();
        }


        private bool CanCheckout(List<Product> shoppingBasket)
        {
            throw new System.NotImplementedException();
        }

        private void UpdateQuantities(List<Product> shoppingBasket)
        {
            throw new System.NotImplementedException();
        }

        private void ClearShoppingCart(string cartName)
        {
            this.Baskets.Remove(cartName);
        }

        private Product CreateCartProduct(Product product, int quantity)
        {
            throw new System.NotImplementedException();
        }

        public List<Product> GetCart(string cartName)
        {
            throw new System.NotImplementedException();
        }

        IEnumerable<IProduct> IBasketContext.GetCart(string cartName)
        {
            throw new System.NotImplementedException();
        }
    }
}
