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

        public List<CTKnowledgePetComment> GetAllCommentByKnowledge(string KnowledgeID)
        {
            return dal.GetKnowledgePetCommentListByKnowledge(KnowledgeID);
        }
        public int InsertComment(CTKnowledgePetComment knowledgeComment)
        {
           return dal.InsertKnowledgePetComment(knowledgeComment);
        }

    }
}
