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
    }
}
