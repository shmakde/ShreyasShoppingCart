using System.Collections.Generic;
namespace ShreyCart.Abstractions
{
    public interface IStoredProcedureNonQuery
    {
        string storedProcedureName { get; set; }
        Dictionary<string, object> parameters { get; set; }
    }
}
