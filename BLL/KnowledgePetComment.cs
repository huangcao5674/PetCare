using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;

namespace PetCare.BLL
{
    public class KnowledgePetComment
    {
        private static readonly IKnowledgePetComment dal = PetCare.DALFactory.DataAccess.CreateKnowledgeComment();

        //根据KnowledgeID 获取相应的comment信息
        public List<CTKnowledgePetComment> GetAllCommentByKnowledge(string KnowledgeID)
        {
            return dal.GetKnowledgePetCommentListByKnowledge(KnowledgeID);
        }

        //插入Comment信息
        public int InsertComment(CTKnowledgePetComment knowledgeComment)
        {
           return dal.InsertKnowledgePetComment(knowledgeComment);
        }

        //删除comment的信息
        public int DeleteKnowledgeComment(string commentID)
        {
            return dal.DeleteKnowledgePetComment(commentID);
        }

        //编辑comment的信息
        public int EditKnowledgeComment(CTKnowledgePetComment knowledgeComment)
        {
            return dal.EditKnowledgePetComment(knowledgeComment);
        }

        //根据commentID获取comment的具体信息
        public CTKnowledgePetComment GetKnowledgePetCommentByCommentID(string commentID)
        {
            return dal.GetKnowledgePetCommentByCommentID(commentID);
        }

    }
}
