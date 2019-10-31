// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Collections.Generic;
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

        public ProductContext(IConnectionSetting connectionSetting)
        {
            this.connectionSetting = connectionSetting;
        }

        public IEmberDataWrapper GetAllProducts()
        {
            var procGetProducts = new ProcGetAllProducts(CurrentSessionUserId)
                .Build();

            var dataSet = new SqlExecutor().ExecuteStoredProcedure(procGetProducts, connectionSetting);

            return new EmberDataWrapper { data = ProcessDataSetForEmber(dataSet) };
        }

        public List<EmberProductWithTypeId> ProcessDataSetForEmber(DataSet dataSet)
        {
            var emberProductsWithTypeId = new List<EmberProductWithTypeId>();
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
                        price = decimal.Parse(row["price"].ToString()),
                        image = row["imageurl"].ToString(),
                        description = row["description"].ToString(),
                    },
                });
            }

            return emberProductsWithTypeId;
        }

        public void AddNewProduct(string title, string color, string suppliername, double price, string imageName)
        {
            var procAddNewPerson = new ProcAddNewProduct(CurrentSessionUserId)
                .WithTitle(title)
                .WithColor(color)
                .WithSupplierName(suppliername)
                .WithImageURL(imageName)
                .Build();

            new SqlExecutor().ExecuteStoredProcedure(procAddNewPerson, connectionSetting);
        }

        public void AddNewProduct(IProduct emberProduct)
        {
            var procAddNewPerson = new ProcAddNewProduct(CurrentSessionUserId)
                .WithTitle(emberProduct.title)
                .WithColor(emberProduct.color)
                .WithSupplierName(emberProduct.supplier)
                .WithImageURL(emberProduct.image)
                .Build();

            new SqlExecutor().ExecuteStoredProcedure(procAddNewPerson, connectionSetting);
        }

        public void DeleteProduct(int productId)
        {
            var procAddNewPerson = new ProcDeleteProduct(CurrentSessionUserId)
                .WithProductId(productId)
                .Build();

            new SqlExecutor().ExecuteStoredProcedure(procAddNewPerson, connectionSetting);
        }
    }
}
