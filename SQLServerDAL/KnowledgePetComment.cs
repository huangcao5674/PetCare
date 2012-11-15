using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;

namespace PetCare.SQLServerDAL
{
    public class KnowledgePetComment:IKnowledgePetComment
    {
        List<CTKnowledgePetComment> GetKnowledgePetCommentListByID(int UserID)
        {
            List<CTKnowledgePetComment> list = new List<CTKnowledgePetComment>();
            return list;
        }
    }
}
