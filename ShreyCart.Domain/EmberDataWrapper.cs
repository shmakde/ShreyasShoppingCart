// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Collections.Generic;
using ShreyCart.Abstractions;

namespace ShreyCart.Domain
{
    public class EmberDataWrapper : IEmberDataWrapper
    {
        public IEnumerable<IEmberProductWithTypeId> data { get; set; }
    }
}