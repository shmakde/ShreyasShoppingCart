using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreyCart.Domain
{
    public class EmberProduct
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