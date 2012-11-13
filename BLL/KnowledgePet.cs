using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;

namespace PetCare.BLL
{
   public class KnowledgePet
    {
       private static readonly IKnowledgePet dal = PetCare.DALFactory.DataAccess.CreateKnowledgePet();

       public List<CTKnowledgePet> GetKnowledgePetList()
       {
           return dal.GetAllKnowledgePetList();
       }
    }
}
