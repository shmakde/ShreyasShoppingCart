// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Collections.Generic;

namespace ShreyCart.Abstractions
{
    public interface IBasketContext
    {
        void AddProductToCart(string cartName, int productId, int quantity);

        void Checkout(string cartName);

        IEnumerable<IProduct> GetCart(string cartName);
    }
}
