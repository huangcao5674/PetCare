using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;
using PetCare.IDAL;

namespace PetCare.BLL
{
    public class AdoptPetComment
    {
        private static readonly IAdoptPetComment dal = PetCare.DALFactory.DataAccess.CreateAdoptPetComment();

 
        //增加一条adopt文章的评论
        public int InsertComment(CTAdoptPetComment adoptComment)
        {
            return dal.InsertAdoptPetComment(adoptComment);
        }

        //真正从数据库中删除此评论
        public int DeleteAdoptComment(string commendID)
        {
            return dal.DeleteAdoptPetComment(commendID);
        }

        //编辑adopt的评论
        public int EditAdoptComment(CTAdoptPetComment adoptPetComment)
        {
            return dal.EditAdoptPetComment(adoptPetComment);
        }

        //根据CommentID获取comment内容
        public CTAdoptPetComment GetAdoptCommentByCommentID(string commentID)
        {
            return dal.GetAdoptPetCommentByCommentID(commentID);
        }
    }
}
