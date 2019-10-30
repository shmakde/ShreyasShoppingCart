using ShreyCart.Abstractions;
using System.Configuration;

namespace ShreyCart.DataAccess
{
    public class ConnectionSetting : IConnectionSetting
    {
        public string GetDataSourcePath()
        {
            return ConfigurationManager.ConnectionStrings["ShreyDb"].ConnectionString;
        }
    }
}