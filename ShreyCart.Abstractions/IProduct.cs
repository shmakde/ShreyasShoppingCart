// Copyright © Shreyas Makde 2020. All Rights Reserved.

namespace ShreyCart.Abstractions
{
    public interface IProduct
    {
        string title { get; set; }

        string color { get; set; }

        string supplier { get; set; }

        string pricecategory { get; set; }

        decimal price { get; set; }

        string image { get; set; }

        string description { get; set; }
    }
}
