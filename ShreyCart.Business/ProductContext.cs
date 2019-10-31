// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Data;
using ShreyCart.Abstractions;
using ShreyCart.DataAccess;
using ShreyCart.DataAccess.StoredProcedures;
using ShreyCart.Domain;

namespace ShreyCart.Business
{
    public class ProductContext : IProductContext
    {
        private const int CurrentSessionUserId = 1;
        private readonly IConnectionSetting connectionSetting;
        private readonly IProductContextHelper productContextHelper;

        public ProductContext(IConnectionSetting connectionSetting, IProductContextHelper productContextHelper)
        {
            this.connectionSetting = connectionSetting;
            this.productContextHelper = productContextHelper;
        }

        public IEmberDataWrapper GetAllExistingProducts()
        {
            var procGetProducts = productContextHelper.Build_GetAllProducts_StoredProcedure(CurrentSessionUserId);
            var dataSet = productContextHelper.GetSqlDataSet(procGetProducts, connectionSetting);
            var processedData = productContextHelper.ProcessDataSetForEmber(dataSet);

            return new EmberDataWrapper { data = processedData };
        }

        public void AddNewProduct(string title, string color, string suppliername, double price, string imageName)
        {
            var procAddNewProduct = productContextHelper.Build_AddNewProducts_StoredProcedure(
                CurrentSessionUserId,
                title,
                color,
                suppliername,
                price,
                imageName);
            productContextHelper.PostSqlNonQuery(procAddNewProduct, connectionSetting);
        }

        public void AddNewProduct(IProduct product)
        {
            var procAddNewProduct = productContextHelper.Build_AddNewProducts_StoredProcedure(
                CurrentSessionUserId,
                product.title,
                product.color,
                product.supplier,
                product.price,
                product.image);
            productContextHelper.PostSqlNonQuery(procAddNewProduct, connectionSetting);
        }

        public void DeleteProduct(int productId)
        {
            var procDeleteProduct = productContextHelper.Build_DeleteProduct_StoredProcedure(
                CurrentSessionUserId,
                productId);
            productContextHelper.PostSqlNonQuery(procDeleteProduct, connectionSetting);
        }
    }
}
