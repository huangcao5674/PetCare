using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;

namespace PetCare.IDAL
{
    public interface IKnowledgePetComment
    {
        //根据用户ID 查找其所有的评论
        List<CTKnowledgePetComment> GetKnowledgePetCommentListByUserID(string UserID);

        //根据宠物知识ID查找其所有的评论
        List<CTKnowledgePetComment> GetKnowledgePetCommentListByKnowledge(string KnowledgeID);

        //根据commentID超找一条comment信息
        CTKnowledgePetComment GetKnowledgePetCommentByCommentID(string commentID);

        //增减一条宠物知识评论
        int InsertKnowledgePetComment(CTKnowledgePetComment knowledgeComment);

        //删除宠物知识评论
        int DeleteKnowledgePetComment(string commentID);

        //编辑宠物知识评论
        int EditKnowledgePetComment(CTKnowledgePetComment knowledgePetComment);
    }
}
