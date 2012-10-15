using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace PetCare.Model
{
    [Serializable]
    [Table(Name="DB_PetDetail")]
    public class CTPetDetail
    {
        public CTPetDetail()
        {

        }
        public CTPetDetail(string petID,string petCategory,string petName)
        {
            PetID = petID;
            PetCategory = petCategory;
            PetName = petName;
        }
        public string PetID
        {
            get;
            set;
        }
        public string PetCategory
        {
            get;
            set;
        }
        public string PetName
        {
            get;
            set;
        }
    }
}
