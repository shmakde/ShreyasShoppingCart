// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Collections.Generic;
using System.Data;

namespace ShreyCart.Abstractions
{
    public interface IProductContext
    {
        IEmberDataWrapper GetAllExistingProducts();

        void AddNewProduct(string title, string color, string supplier, double price, string imageName);

        void AddNewProduct(IProduct product);
    }
}
