﻿using ShreyCart.DataAccess.Connection;

namespace ShreyCart.DataAccess
{
    public interface ISqlExecutor
    {
        void ExecuteNonQuery(string queryString, IConnectionSetting connection);
        //Task ExecuteNonQueryAsync(CommandType commandType, string commandText, IDictionary<string, object> parameters,
        //    IDictionary<string, object> outParameters,
        //    int? timeout = null);

        //Task<DataTable> ExecuteDataTableAsync(CommandType commandType, string commandText,
        //    IDictionary<string, object> parameters,
        //    IDictionary<string, object> outParameters, int? timeout = null);

        //Task<TResult[]> ExecuteAsync<TResult>(CommandType commandType, string commandText,
        //    IDictionary<string, object> parameters,
        //    IDictionary<string, object> outParameters, int? timeout = null)
        //    where TResult : class;

        //void ExecuteNonQuery(CommandType commandType, string commandText, IDictionary<string, object> parameters,
        //    IDictionary<string, object> outParameters,
        //    int? timeout = null);

        //DataTable ExecuteDataTable(CommandType commandType, string commandText, IDictionary<string, object> parameters,
        //    IDictionary<string, object> outParameters, int? timeout = null);

        //TResult[] Execute<TResult>(CommandType commandType, string commandText, IDictionary<string, object> parameters,
        //    IDictionary<string, object> outParameters, int? timeout = null)
        //    where TResult : class;
    }

}
