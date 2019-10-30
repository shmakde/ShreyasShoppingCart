using System.Data;

namespace ShreyCart.Abstractions
{
    public interface ISqlExecutor
    {
        void ExecuteNonQuery(string queryString, IConnectionSetting connection);
        void ExecuteStoredProcedure(IStoredProcedureNonQuery procedure, IConnectionSetting connection);
        DataSet ExecuteStoredProcedure(IStoredProcedureQueryWithResults procedure, IConnectionSetting connection);
    }
}
