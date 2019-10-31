// Copyright © Shreyas Makde 2020. All Rights Reserved.

namespace ShreyCart.Abstractions
{
    public interface IEmberProductWithTypeId
    {
        string type { get; set; }

        string id { get; set; }

        IProduct attributes { get; set; }
    }
}
