using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;
using PetCare.IDAL;
using PetCare.DALFactory;

namespace PetCare.BLL
{
    public class AdoptPet
    {
        private static readonly IAdoptPet dal = PetCare.DALFactory.DataAccess.CreateAdoptPet();

        public List<CTAdoptPet> GetPetAdoptPetList()
        {
            return dal.GetAllAdoptPetList();
        }

        public List<CTAdoptPet> GetPetAdoptPetListByUserID(string UserID)
        {
            return dal.GetAdoptPetListByUser(UserID);
        }

        public List<CTAdoptPet> GetPetAdoptPetListByAddressID(string AddressID)
        {
            return dal.GetAdoptPetListByAddress(AddressID);
        }

        public List<CTAdoptPet> GetPetAdoptPetListByPetCategoryID(string PetCategoryID)
        {
            return dal.GetAdoptPetListByPetCategory(PetCategoryID);
        }

        public int InsertAdoptPet(CTAdoptPet adoptPet)
        {
            return dal.InsertAdoptPet(adoptPet);
        }

        public int DeleteAdoptPet(string adoptID)
        {
            return dal.DeleteAdoptPet(adoptID);
        }

    }
}
