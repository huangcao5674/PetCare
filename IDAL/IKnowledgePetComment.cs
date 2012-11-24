using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;

namespace PetCare.IDAL
{
    public interface IKnowledgePetComment
    {
        List<CTKnowledgePetComment> GetKnowledgePetCommentListByUserID(string UserID);

        List<CTKnowledgePetComment> GetKnowledgePetCommentListByKnowledge(string KnowledgeID);

        int InsertKnowledgePetComment(CTKnowledgePetComment knowledgeComment);
    }
}
