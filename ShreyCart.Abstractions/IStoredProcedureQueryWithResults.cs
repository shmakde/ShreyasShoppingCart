using System.Collections.Generic;
using System.Data;

namespace ShreyCart.Abstractions
{
    public interface IStoredProcedureQueryWithResults
    {
        string storedProcedureName { get; set; }
        Dictionary<string, object> parameters { get; set; }
        DataSet Results();
    }
}
