using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;

namespace PetCare.IDAL
{
    public interface IMissedPetInfo
    {
        //得到所有的丢失宠物文章的信息
        List<CTMissedPetInfo> GetAllMissedPetInfoList();

 

        //获取所有的丢失宠物的文章列表，返回信息列表，分页的方式
        List<CVMissedPetInfo> GetAllMissedPetListPerPage(int pageNumber, int NumberPerPage, out int howmanyPages);

        //获取一篇文章的所有的信息，返回信息列表（包含文章的所有内容，对应用户，所有评论），分页的方式
        List<CVMissedPetComment> GetMissPetCommentPageList(string missPetID, int pageNumber, int NumberPerPage, out int howmanyPages);

        //根据用户ID 得到用户发布的丢失宠物的文章的信息
        List<CTMissedPetInfo> GetMissedPetInfoListByUser(string UserID);

        //根据丢失ID找到对应的宠物发布丢失文章的信息
        CTMissedPetInfo GetMissedPetByMissedID(string MissedID);

        //增加丢失宠物的信息
        int InsertMissedPet(CTMissedPetInfo MissedPetInfo);

        //删除宠物的丢失的信息
        int DeleteMissedPet(string MissedID);

        //编辑宠物的丢失信息
        int EditMissedPet(CTMissedPetInfo MissedPetInfo);
    }
}
