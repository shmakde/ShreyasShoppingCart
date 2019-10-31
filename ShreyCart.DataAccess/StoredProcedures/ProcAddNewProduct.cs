// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Collections.Generic;
using ShreyCart.Abstractions;

namespace ShreyCart.DataAccess.StoredProcedures
{
    public class ProcAddNewProduct : IStoredProcedureNonQuery
    {
        private const string ImageHost = @"http://shreyasmakde.com/carts/";
        private const string JpgType = ".jpg";
        private string title;
        private string color;
        private string suppliername;
        private decimal price;
        private string imagename;
        private int userid;

        public ProcAddNewProduct(int userid)
        {
            this.userid = userid;
        }

        private ProcAddNewProduct()
        {
        }

        public string StoredProcedureName { get; set; }

        public Dictionary<string, object> Parameters { get; set; }

        public ProcAddNewProduct WithTitle(string title)
        {
            this.title = title;
            return this;
        }

        public ProcAddNewProduct WithColor(string color)
        {
            this.color = color;
            return this;
        }

        public ProcAddNewProduct WithSupplierName(string suppliername)
        {
            this.suppliername = suppliername;
            return this;
        }

        public ProcAddNewProduct WithPrice(decimal price)
        {
            this.price = price;
            return this;
        }

        public ProcAddNewProduct WithImageURL(string imagename)
        {
            this.imagename = imagename;
            return this;
        }

        public ProcAddNewProduct Build()
        {
            var procParameters = new Dictionary<string, object>();

            procParameters.Add("@Title", title);
            procParameters.Add("@Color", color);
            procParameters.Add("@SupplierName", suppliername);
            procParameters.Add("@Price", price);
            procParameters.Add("@ImageURL", ImageHost + imagename + JpgType);
            procParameters.Add("@UserId", userid);

            StoredProcedureName = "dbo.AddNewProduct";

            Parameters = procParameters;
            return this;
        }
    }
}