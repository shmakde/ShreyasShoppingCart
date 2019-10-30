using ShreyCart.DataAccess.Connection;
using ShreyCart.DataAccess.StoredProcedures;
using System.Data;

namespace ShreyCart.DataAccess
{
    public interface ISqlExecutor
    {
        void ExecuteNonQuery(string queryString, IConnectionSetting connection);
        void ExecuteStoredProcedure(IStoredProcedureNonQuery procedure, IConnectionSetting connection);
        DataSet ExecuteStoredProcedure(IStoredProcedureQueryWithResults procedure, IConnectionSetting connection);
    }

}
