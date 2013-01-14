using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.DALFactory;
using PetCare.Model;

namespace PetCare.BLL
{
    public class MissedPetComment
    {
        private static readonly IMissedPetInfoComment dal = PetCare.DALFactory.DataAccess.CreateMissedComment();

        public List<CTMissedPetInfoComment> GetAllCommentByMissID(string MissID)
        {
            return dal.GetMissPetCommentListByMissID(MissID);
        }

        //插入Comment信息
        public int InsertComment(CTMissedPetInfoComment missComment)
        {
            return dal.InsertMissPetComment(missComment);
        }

        //删除comment的信息
        public int DeleteKnowledgeComment(string commentID)
        {
            return dal.DeleteMissPetComment(commentID);
        }

        //编辑comment的信息
        public int EditKnowledgeComment(CTMissedPetInfoComment missComment)
        {
            return dal.EditMissPetComment(missComment);
        }

        //根据commentID获取comment的具体信息
        public CTMissedPetInfoComment GetMissPetCommentByCommentID(string commentID)
        {
            return dal.GetMissPetCommentByCommentID(commentID);
        }


    }
}
