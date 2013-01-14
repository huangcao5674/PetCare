using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;

namespace PetCare.IDAL
{
    public interface IMissedPetInfoComment
    {

        //根据用户ID 查找其所有的评论
        List<CTMissedPetInfoComment> GetMissPetCommentListByUserID(string UserID);

        //根据宠物丢失ID查找其所有的评论
        List<CTMissedPetInfoComment> GetMissPetCommentListByMissID(string MissID);

        //根据commentID超找一条comment信息
        CTMissedPetInfoComment GetMissPetCommentByCommentID(string commentID);

        //增减一条宠物知识评论
        int InsertMissPetComment(CTMissedPetInfoComment missComment);

        //删除宠物丢失评论
        int DeleteMissPetComment(string commentID);

        //编辑宠物知识评论
        int EditMissPetComment(CTMissedPetInfoComment missPetComment);

    }
}
