// Copyright © Shreyas Makde 2020. All Rights Reserved.

using ShreyCart.Abstractions;

namespace ShreyCart.Domain
{
    public class Product : IProduct
    {
        public string title { get; set; }

        public string color { get; set; }

        public string supplier { get; set; }

        public string pricecategory { get; set; }

        public decimal price { get; set; }

        public string image { get; set; }

        public string description { get; set; }
    }
}