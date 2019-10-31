// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Collections.Generic;

namespace ShreyCart.Abstractions
{
    public interface IEmberDataWrapper
    {
        IEnumerable<IEmberProductWithTypeId> data { get; set; }
    }
}
