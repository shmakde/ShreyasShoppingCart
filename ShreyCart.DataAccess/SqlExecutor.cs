using ShreyCart.Abstractions;
using System.Data;
using System.Data.SqlClient;

namespace ShreyCart.DataAccess
{
    public class SqlExecutor : ISqlExecutor
    {
        public void ExecuteNonQuery(string queryString, IConnectionSetting connectionSetting)
        {
            using (SqlConnection con = new SqlConnection(connectionSetting.GetDataSourcePath()))
            {
                SqlCommand command = new SqlCommand(queryString, con);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void ExecuteStoredProcedure(IStoredProcedureNonQuery procedure, IConnectionSetting connectionSetting)
        {
            using (SqlConnection connection = new SqlConnection(connectionSetting.GetDataSourcePath()))
            {
                using (SqlCommand command = new SqlCommand(procedure.storedProcedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    foreach(var parameter in procedure.parameters)
                    {
                        command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        public DataSet ExecuteStoredProcedure(IStoredProcedureQueryWithResults procedure, IConnectionSetting connectionSetting)
        {
            DataSet dataset = new DataSet();
            using (SqlConnection con = new SqlConnection(connectionSetting.GetDataSourcePath()))
            {
                SqlCommand command = new SqlCommand(procedure.storedProcedureName, con);
                foreach (var parameter in procedure.parameters)
                {
                    command.Parameters.AddWithValue(parameter.Key, parameter.Value);
                }
                command.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = command;

                da.Fill(dataset);
                return dataset;
            }
        }
    }
}