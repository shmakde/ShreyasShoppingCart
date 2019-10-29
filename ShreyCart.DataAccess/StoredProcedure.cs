using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreyCart.DataAccess
{
    public class StoredProcedure
    {
        public Dictionary<string, object> parameters { get; set; }
        public string storedProcedureName { get; set; }

    }
}