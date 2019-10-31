// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Collections.Generic;
using System.Data;

namespace ShreyCart.Abstractions
{
    public interface IProductContextHelper
    {
        IStoredProcedureQueryWithResults Build_GetAllProducts_StoredProcedure(int currentSessionUserId);

        IStoredProcedureNonQuery Build_AddNewProducts_StoredProcedure(int currentSessionUserId, string title, string color, string suppliername, double price, string imageName);

        IStoredProcedureNonQuery Build_DeleteProduct_StoredProcedure(int currentSessionUserId, int productId);

        DataSet GetSqlDataSet(IStoredProcedureQueryWithResults storedProcedure, IConnectionSetting connectionSetting);

        void PostSqlNonQuery(IStoredProcedureNonQuery storedProcedure, IConnectionSetting connectionSetting);

        List<IEmberProductWithTypeId> ProcessDataSetForEmber(DataSet dataSet);
    }
}