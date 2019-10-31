using ShreyCart.Abstractions;
using System.Collections.Generic;
using System.Data;

namespace ShreyCart.DataAccess.StoredProcedures
{
    public class ProcGetAllProducts : IStoredProcedureQueryWithResults
    {
        public string storedProcedureName { get; set; }
        private int userId { get; set; }
        public ProcGetAllProducts(int UserId)
        {
            userId = UserId;
        }
        public Dictionary<string, object> parameters { get; set; }

        public DataSet Results()
        {
            return new SqlExecutor().ExecuteStoredProcedure(this, new ConnectionSetting());
        }

        public ProcGetAllProducts Build()
        {
            var procParameters = new Dictionary<string, object>();
            procParameters.Add("@UserId", userId);
            parameters = procParameters;


            storedProcedureName = "dbo.GetAllProducts";
            return this;
        }
        private ProcGetAllProducts() { }
    }
}