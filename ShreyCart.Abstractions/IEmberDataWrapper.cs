using System.Collections.Generic;

namespace ShreyCart.Abstractions
{
    public interface IEmberDataWrapper
    {
        IEnumerable<IEmberProductWithTypeId> data { get; set; }
    }
}
