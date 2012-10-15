using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;

namespace PetCare.SQLServerDAL
{
    public class KnowledgePet:IKnowledgePet
    {
        private const string SQL_SELECT_KNOWLEDGEPET_BY_USERID = "";

        private const string SQL_SELECT_KNOWLEDGEPET = "";

        private const string PARM_USER_ID = "@UserId";

       public List<IKnowledgePet> GetAllKnowledgePetList()
       {
           List<IKnowledgePet> KnowledgePetList = new List<IKnowledgePet>();
           return KnowledgePetList;
       }

       public List<IKnowledgePet> GetKnowledgePetListByUser(int UserID)
        {
            List<IKnowledgePet> KnowledgePetList = new List<IKnowledgePet>();
            return KnowledgePetList;
        }
    }
}
