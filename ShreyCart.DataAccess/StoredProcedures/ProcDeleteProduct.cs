using ShreyCart.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreyCart.DataAccess.StoredProcedures
{
    public class ProcDeleteProduct : IStoredProcedureNonQuery
    {
        public string storedProcedureName { get; set; }
        public Dictionary<string, object> parameters { get; set; }
        private int productId;
        private int usersId;

        public ProcDeleteProduct(int UserId)
        {
            usersId = UserId;
        }

        public ProcDeleteProduct WithProductId(int ProductId)
        {
            productId = ProductId;
            return this;
        }

        public ProcDeleteProduct Build()
        {
            storedProcedureName = "dbo.DeleteProduct";
            return this;
        }
    }
}