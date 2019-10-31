// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Collections.Generic;
using ShreyCart.Abstractions;

namespace ShreyCart.DataAccess.StoredProcedures
{
    public class ProcGetAllProducts : IStoredProcedureQueryWithResults
    {
        private int userid;

        public ProcGetAllProducts(int userid)
        {
            userid = this.userid;
        }

        private ProcGetAllProducts()
        {
        }

        public string StoredProcedureName { get; set; }

        public Dictionary<string, object> Parameters { get; set; }

        public ProcGetAllProducts Build()
        {
            var procParameters = new Dictionary<string, object>();
            procParameters.Add("@UserId", userid);
            Parameters = procParameters;

            StoredProcedureName = "dbo.GetAllProducts";
            return this;
        }
    }
}