using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;

namespace PetCare.SQLServerDAL
{
    public class AdoptPet : IAdoptPet
    {
        private const string SQL_SELECT_KNOWLEDGEPET_BY_USERID = "";

        private const string SQL_SELECT_ADOPTPET = "";

        private const string SQL_INSERT_ADOPTPET = "";

        private const string SQL_DELETE_ADOPTPET = "";

        private const string PARM_USER_ID = "@UserId";

        public List<CTAdoptPet> GetAllAdoptPetList()
        {
            List<CTAdoptPet> KnowledgePetList = new List<CTAdoptPet>();
            return KnowledgePetList;
        }

        public  List<CTAdoptPet> GetAdoptPetListByUser(int UserID) 
        {
            List<CTAdoptPet> KnowledgePetList = new List<CTAdoptPet>();
            return KnowledgePetList;
        }

        public void InsertAdoptPet(CTAdoptPet AdoptPetInfo)
        {
           
        }
            
    }
}
