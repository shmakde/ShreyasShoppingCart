using ShreyCart.Abstractions;
using System.Collections.Generic;
using System.Data;

namespace ShreyCart.DataAccess.StoredProcedures
{
    public class ProcGetAllProducts : IStoredProcedureQueryWithResults
    {
        public string storedProcedureName { get; set; }
        public ProcGetAllProducts()
        {
            storedProcedureName = "dbo.GetAllProducts";
            parameters = new Dictionary<string, object>();
        }
        public Dictionary<string, object> parameters { get; set; }

        public DataSet Results()
        {
            return new SqlExecutor().ExecuteStoredProcedure(this, new ConnectionSetting());
        }
    }
}