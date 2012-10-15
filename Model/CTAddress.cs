using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace PetCare.Model
{
    [Serializable]
    [Table(Name = "DB_Address")]
    class CTAddress
    {
        public CTAddress()
        {
        }
        public CTAddress(string addressID,string province,string city)
        {
            this.AddressID = addressID;
            this.City = city;
            this.Province = province;
        }
        public string AddressID
        {
            get;
            set;
        }
        public string Province
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
    }
}
