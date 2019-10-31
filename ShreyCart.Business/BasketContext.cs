// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Collections.Generic;
using ShreyCart.Abstractions;
using ShreyCart.Domain;

namespace ShreyCart.Business
{
    public class BasketContext : IBasketContext
    {
        private static Dictionary<string, List<Product>> baskets;

        private readonly IProductContext productContext;

        public BasketContext(IProductContext productContext)
        {
            this.productContext = productContext;
        }

        private Dictionary<string, List<Product>> Baskets
            => baskets ?? (baskets = new Dictionary<string, List<Product>>());

        public IProductContext GetProductContext()
        {
            return productContext;
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
    }
}
