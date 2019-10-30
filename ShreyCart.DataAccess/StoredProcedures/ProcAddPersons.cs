using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShreyCart.DataAccess.StoredProcedures
{
    public class ProcAddPersons : IStoredProcedureNonQuery
    {
        public string storedProcedureName { get; set; }
        public Dictionary<string, object> parameters { get; set; }

        private string firstName;
        private string lastName;
        private string address;
        private string city;
        private int personId;

        public ProcAddPersons WithPersonId(int PersonId)
        {
            personId = PersonId;
            return this;
        }

        public ProcAddPersons WithFirstName(string FirstName)
        {
            firstName = FirstName;
            return this;
        }

        public ProcAddPersons WithLastName(string LastName)
        {
            lastName = LastName;
            return this;
        }

        public ProcAddPersons WithAddress(string Address)
        {
            address = Address;
            return this;
        }

        public ProcAddPersons WithCity(string City)
        {
            city = City;
            return this;
        }

        public ProcAddPersons Build()
        {
            var procParameters = new Dictionary<string, object>();

            procParameters.Add("@PersonID", personId);
            procParameters.Add("@LastName", lastName);
            procParameters.Add("@FirstName", firstName);
            procParameters.Add("@Address", address);
            procParameters.Add("@City", city);

            parameters = procParameters;
            return this;
        }
        public ProcAddPersons(string StoredProcedureName)
        {
            storedProcedureName = StoredProcedureName;
        }
        private ProcAddPersons() { }


    }
}