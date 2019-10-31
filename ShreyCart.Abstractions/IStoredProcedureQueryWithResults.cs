using System.Collections.Generic;

namespace ShreyCart.Abstractions
{
    public interface IStoredProcedureQueryWithResults
    {
        string storedProcedureName { get; set; }
        Dictionary<string, object> parameters { get; set; }
    }
}
