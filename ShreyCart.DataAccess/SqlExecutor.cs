﻿using ShreyCart.DataAccess.Connection;
using ShreyCart.DataAccess.StoredProcedures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ShreyCart.DataAccess
{
    public class SqlExecutor : ISqlExecutor
    {
        public SqlExecutor()
        {

        }
        public void ExecuteNonQuery(string queryString, IConnectionSetting connection)
        {
            using (SqlConnection con = new SqlConnection(connection.GetDataSourcePath()))
            {
                SqlCommand command = new SqlCommand(queryString, con);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }
        public void ExecuteStoredProcedure(IStoredProcedureNonQuery procedure, IConnectionSetting connection)
        {
            using (SqlConnection con = new SqlConnection(connection.GetDataSourcePath()))
            {
                using (SqlCommand cmd = new SqlCommand(procedure.storedProcedureName, con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    foreach(var parameter in procedure.parameters)
                    {
                        cmd.Parameters.AddWithValue(parameter.Key, parameter.Value);
                    }
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataSet ExecuteStoredProcedure(IStoredProcedureQueryWithResults procedure, IConnectionSetting connection)
        {
            using (SqlConnection con = new SqlConnection(connection.GetDataSourcePath()))
            {
                SqlDataAdapter adapter = new SqlDataAdapter();
                using (SqlCommand cmd = new SqlCommand(procedure.storedProcedureName, con))
                {
                    var dataset = new DataSet();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(dataset);
                    return dataset;
                }
            }
        }
    }
}