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

        //根据用户ID 得到用户发布的丢失宠物的文章的信息
        List<CTMissedPetInfo> GetMissedPetInfoListByUser(int UserID);

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
