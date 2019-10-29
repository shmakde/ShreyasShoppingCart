using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShreyCart.DataAccess.StoredProcedures
{
    public interface IStoredProcedure
    {
        string storedProcedureName { get; set; }
        Dictionary<string, object> parameters { get; set; }
    }
}
