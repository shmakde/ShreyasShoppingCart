using ShreyCart.Abstractions;
using System.Collections.Generic;

namespace ShreyCart.DataAccess.StoredProcedures
{
    public class ProcAddNewProduct : IStoredProcedureNonQuery
    {
        public string storedProcedureName { get; set; }
        public Dictionary<string, object> parameters { get; set; }

        private string title;
        private string color;
        private string suppliername;
        private decimal price;
        private string imagename;
        private int userid;

        const string imageHost = @"http://shreyasmakde.com/carts/";
        const string jpgType = ".jpg";
        public ProcAddNewProduct WithTitle(string Title)
        {
            title = Title;
            return this;
        }

        public ProcAddNewProduct WithColor(string Color)
        {
            color = Color;
            return this;
        }

        public ProcAddNewProduct WithSupplierName(string SupplierName)
        {
            suppliername = SupplierName;
            return this;
        }

        public ProcAddNewProduct WithPrice(decimal Price)
        {
            price = Price;
            return this;
        }

        public ProcAddNewProduct WithImageURL(string ImageName)
        {
            imagename = ImageName;
            return this;
        }

        public ProcAddNewProduct Build()
        {
            var procParameters = new Dictionary<string, object>();

            procParameters.Add("@Title", title);
            procParameters.Add("@Color", color);
            procParameters.Add("@SupplierName", suppliername);
            procParameters.Add("@Price", price);
            procParameters.Add("@ImageURL", imageHost + imagename + jpgType);
            procParameters.Add("@UserId", userid);

            storedProcedureName = "dbo.AddNewProduct";

            parameters = procParameters;
            return this;
        }
        public ProcAddNewProduct(int UserId)
        {
            userid = UserId;
        }

        private ProcAddNewProduct() { }

    }
}