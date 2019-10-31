namespace ShreyCart.Abstractions
{
    public interface IProductContext
    {
        IEmberDataWrapper GetAllProducts();
        void AddNewProduct(string title, string color, string supplier, double price, string imageName);
        void AddNewProduct(IProduct product);
    }
}
