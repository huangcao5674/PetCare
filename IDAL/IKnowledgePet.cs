using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;

namespace PetCare.IDAL
{
    public interface IKnowledgePet
    {
        //得到宠物的知识的所有的信息
        List<CTKnowledgePet> GetAllKnowledgePetList();

        //根据用户ID得到用户发布的宠物知识的信息
        List<CTKnowledgePet> GetKnowledgePetListByUser(int UserID);

        //增加宠物知识的所有信息
        int InsertKnowledgePet(CTKnowledgePet KnowledgePetInfo);

        //获取宠物知识的列表信息
        List<CVKnowledgePet> GetAllKnowledgePetPageList(int pageNumber, int NumberPerPage, out int howmanyPages);

        //获取一篇文章的所有的信息（包括所有的文章信息，评论，用户信息）
        List<CVKnowledgePetComment> GetKnowledgePetCommentPageList(string  knowledgePetID,int pageNumber, int NumberPerPage, out int howmanyPages);
        
    }
}
