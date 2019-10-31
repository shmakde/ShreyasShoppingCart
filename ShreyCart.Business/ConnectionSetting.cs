// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Configuration;
using ShreyCart.Abstractions;

namespace ShreyCart.Business
{
    public class ConnectionSetting : IConnectionSetting
    {
        public string GetDataSourcePath()
        {
            return ConfigurationManager.ConnectionStrings["ShreyDb"].ConnectionString;
        }
    }
}