using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShreyCart.DataAccess
{
    public class SqlExecutor
    {
        public SqlExecutor()
        {

        }
        public TResult[] Execute<TResult>(CommandType commandType, string commandText, IDictionary<string, object> parameters, IDictionary<string, object> outParameters, int? timeout = null) where TResult : class
        {
            throw new NotImplementedException();
        }

        public DataTable ExecuteDataTable(CommandType commandType, string commandText, IDictionary<string, object> parameters, IDictionary<string, object> outParameters, int? timeout = null)
        {
            throw new NotImplementedException();
        }


        public void ExecuteNonQuery(CommandType commandType, string commandText, IDictionary<string, object> parameters, IDictionary<string, object> outParameters, int? timeout = null)
        {
            using (SqlConnection connection = new SqlConnection(""))
            {
                
            }
        }
        public DataSet SelectRows(DataSet dataset,string connectionString, string queryString)
        {
            using (SqlConnection connection =
                new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(
                    queryString, connection);
                adapter.Fill(dataset);
                return dataset;
            }
        }

        public void CreateCommand(string queryString, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(
                       connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
    }
}