using System.Configuration;
using ShreyCart.Abstractions;

namespace ShreyCart.Common
{
    public class CartConfig : IConfig
    {
        public string GetDataSourcePath()
        {
            return ConfigurationManager.AppSettings["Cart.CsvFilePath"];
        }
    }
}
