using ShreyCart.Abstractions;

namespace ShreyCart.Domain
{
    public class EmberProductWithTypeId : IEmberProductWithTypeId
    {
        public string type { get; set; }
        public string id { get; set; }

        public IProduct attributes { get; set; }
    }
}