// Copyright © Shreyas Makde 2020. All Rights Reserved.

using System.Collections.Generic;

namespace ShreyCart.Abstractions
{
    public interface IStoredProcedureNonQuery
    {
        string StoredProcedureName { get; set; }

        Dictionary<string, object> Parameters { get; set; }
    }
}
