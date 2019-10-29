using System.Configuration;

namespace ShreyCart.DataAccess.Connection
{
    public class ConnectionSetting : IConnectionSetting
    {
        public string GetDataSourcePath()
        {
            return ConfigurationManager.ConnectionStrings["ShreyDb"].ConnectionString;
        }
    }
}