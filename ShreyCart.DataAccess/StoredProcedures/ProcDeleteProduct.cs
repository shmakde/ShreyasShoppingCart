// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Collections.Generic;
using ShreyCart.Abstractions;

namespace ShreyCart.DataAccess.StoredProcedures
{
    public class ProcDeleteProduct : IStoredProcedureNonQuery
    {
        private int productId;
        private int usersId;

        public ProcDeleteProduct(int userId)
        {
            usersId = userId;
        }

        private ProcDeleteProduct()
        {
        }

        public string StoredProcedureName { get; set; }

        public Dictionary<string, object> Parameters { get; set; }

        public ProcDeleteProduct WithProductId(int productId)
        {
            this.productId = productId;
            return this;
        }

        public ProcDeleteProduct Build()
        {
            var procParameters = new Dictionary<string, object>();

            procParameters.Add("@ProductId", productId);
            procParameters.Add("@UserId", usersId);

            StoredProcedureName = "dbo.DeleteProduct";
            Parameters = procParameters;

            return this;
        }
    }
}