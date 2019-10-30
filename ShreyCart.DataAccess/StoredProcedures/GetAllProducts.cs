using ShreyCart.DataAccess.Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ShreyCart.DataAccess.StoredProcedures
{
    public class GetAllProducts : IStoredProcedureQueryWithResults
    {
        public string storedProcedureName { get; set; }
        public Dictionary<string, object> parameters { get; set; }

        public DataSet Results()
        {
            return new SqlExecutor().ExecuteStoredProcedure(this, new ConnectionSetting());
        }
    }
}