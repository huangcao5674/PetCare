using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;
using PetCare.DALFactory;

namespace PetCare.BLL
{
    public class PetCategory
    {
        private static readonly IPetCategory dal = PetCare.DALFactory.DataAccess.CreateCategory();

        public List<CTPetCategory> GetPetCategoryList()
        {
           return dal.GetAllPetCategoryInfo();
        }

        public int InsertPetCategory(CTPetCategory petcategory)
        {
            return dal.InsertPetCategory(petcategory);
        }
    }
}
