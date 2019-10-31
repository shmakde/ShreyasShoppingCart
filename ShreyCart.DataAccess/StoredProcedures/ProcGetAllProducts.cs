using ShreyCart.Abstractions;
using System.Collections.Generic;

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