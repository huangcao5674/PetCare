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

       //根据knowledgeID 获取所有对应的knowledge信息
       public CTKnowledgePet GetKnowledgePetByKnowledgeID(string knowledgeID)
       {
           return dal.GetKnowledgePetInfoByKnowledgeID(knowledgeID);
       }


       //获取宠物知识的列表信息
       public List<CVKnowledgePet> GetPetKnowledgePerPageList(int pageNumber, int perPage, out int howmanyPages)
       {
           return dal.GetAllKnowledgePetPageList(pageNumber, perPage, out howmanyPages);
       }


       //获取一篇文章的所有的信息（包括所有的文章信息，评论，用户信息）
       public List<CVKnowledgePetComment> GetPetKnowledgeCommentPerPageList(string KnowledgeID,int pageNumber, int perPage, out int howmanyPages)
       {
           return dal.GetKnowledgePetCommentPageList(KnowledgeID, pageNumber, perPage, out howmanyPages);
       }

       //更新一篇knowledge的信息
       public int EditKnowledgePet(CTKnowledgePet knowledgePet)
       {
           return dal.EditKnowledgePet(knowledgePet);
       }

       //删除knowledge信息，根据knowledgeID
       public int DeleteKnowledgePet(string knowledgeID)
       {
           return dal.DeleteKnowledgePet(knowledgeID);
       }

    }
}
