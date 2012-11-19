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


       //查询所有的宠物知识信息
       public List<CTKnowledgePet> GetKnowledgePetList()
       {
           return dal.GetAllKnowledgePetList();
       }

       //增加宠物知识信息
       public int InsertKnowledgePet(CTKnowledgePet knowledgePet)
       {
           return dal.InsertKnowledgePet(knowledgePet);
       }
    }
}
