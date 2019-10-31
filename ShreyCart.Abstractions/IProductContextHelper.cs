// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Collections.Generic;
using System.Data;

namespace ShreyCart.Abstractions
{
    public interface IProductContextHelper
    {
        IStoredProcedureQueryWithResults BuildGetAllProductsStoredProcedure(int currentSessionUserId);

        IStoredProcedureNonQuery BuildGetAddNewProducts(int currentSessionUserId, string title, string color, string suppliername, double price, string imageName);

        IStoredProcedureNonQuery BuildDeleteProduct(int currentSessionUserId, int productId);

        DataSet GetSqlDataSet(IStoredProcedureQueryWithResults storedProcedure, IConnectionSetting connectionSetting);

        void PostSqlNonQuery(IStoredProcedureNonQuery storedProcedure, IConnectionSetting connectionSetting);

        List<IEmberProductWithTypeId> ProcessDataSetForEmber(DataSet dataSet);
    }
}