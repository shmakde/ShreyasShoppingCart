// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Collections.Generic;
using System.Data;
using ShreyCart.Abstractions;
using ShreyCart.DataAccess;
using ShreyCart.DataAccess.StoredProcedures;
using ShreyCart.Domain;

namespace ShreyCart.Business
{
    public class ProductContextHelper : IProductContextHelper
    {
        public IStoredProcedureNonQuery Build_DeleteProduct_StoredProcedure(int currentSessionUserId, int productId)
        {
            return new ProcDeleteProduct(currentSessionUserId)
                .WithProductId(productId)
                .Build();
        }

        public IStoredProcedureNonQuery Build_AddNewProducts_StoredProcedure(int currentSessionUserId, string title, string color, string suppliername, double price, string imageName)
        {
            return new ProcAddNewProduct(currentSessionUserId)
                .WithTitle(title)
                .WithColor(color)
                .WithSupplierName(suppliername)
                .WithImageURL(imageName)
                .Build();
        }

        public IStoredProcedureQueryWithResults Build_GetAllProducts_StoredProcedure(int currentSessionUserId)
        {
            return new ProcGetAllProducts(currentSessionUserId)
                .Build();
        }

        public DataSet GetSqlDataSet(IStoredProcedureQueryWithResults storedProcedure, IConnectionSetting connectionSetting)
        {
            return new SqlExecutor().ExecuteStoredProcedure(storedProcedure, connectionSetting);
        }

        public void PostSqlNonQuery(IStoredProcedureNonQuery storedProcedure, IConnectionSetting connectionSetting)
        {
            new SqlExecutor().ExecuteStoredProcedure(storedProcedure, connectionSetting);
        }

        public List<IEmberProductWithTypeId> ProcessDataSetForEmber(DataSet dataSet)
        {
            var emberProductsWithTypeId = new List<IEmberProductWithTypeId>();
            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                emberProductsWithTypeId.Add(new EmberProductWithTypeId()
                {
                    id = row["title"].ToString().Replace(' ', '-'),
                    type = "product",
                    attributes = new Product()
                    {
                        title = row["title"].ToString(),
                        color = row["color"].ToString(),
                        supplier = row["suppliername"].ToString(),
                        pricecategory = row["pricecategory"].ToString(),
                        price = double.Parse(row["price"].ToString()),
                        image = row["imageurl"].ToString(),
                        description = row["description"].ToString(),
                    },
                });
            }

            return emberProductsWithTypeId;
        }
    }
}