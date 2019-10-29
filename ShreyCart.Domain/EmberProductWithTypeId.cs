using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreyCart.Domain
{
    public class EmberProductWithTypeId
    {
        public string type { get; set; }
        public string id { get; set; }

        public EmberProduct attributes { get; set; }
    }
}