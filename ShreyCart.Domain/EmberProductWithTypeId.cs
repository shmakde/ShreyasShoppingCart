namespace ShreyCart.Domain
{
    public class EmberProductWithTypeId
    {
        public string type { get; set; }
        public string id { get; set; }

        public Product attributes { get; set; }
    }
}