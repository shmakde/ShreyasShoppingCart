using ShreyCart.DataAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Collections.Generic;

namespace ShreyCart.DataAccess.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ShouldExecuteAddPersons(int Id, string lastName, string firstName, string address, string city)
        {
            var MySQl = new SqlExecutor();
            var parameters = new Dictionary<string, object>
            {
                {"@PersonID", Id },
                {"@LastName", lastName},
                {"@FirstName", firstName},
                {"@Address", address},
                {"@City", city},
            };

            MySQl.ExecuteNonQuery(CommandType.StoredProcedure, "[dbo].[AddPerson]", parameters, new Dictionary<string, object>(), null);
            Assert.IsTrue(true);
        }
    }
}
