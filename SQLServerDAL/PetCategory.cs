using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;

namespace PetCare.SQLServerDAL
{
    public class PetCategory:IPetCategory
    {
        List<CTPetCategory> GetAllPetCategoryInfoList()
        {
            List<CTPetCategory> list = new List<CTPetCategory>();
            return list;
        }

    }
}
