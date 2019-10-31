using ShreyCart.Abstractions;
using System.Collections.Generic;

namespace ShreyCart.Domain
{
    public class EmberDataWrapper : IEmberDataWrapper
    {
        public IEnumerable<IEmberProductWithTypeId> data { get; set; }
    }
}