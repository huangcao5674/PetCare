using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;

namespace PetCare.IDAL
{
    public interface IPetCategory
    {
        //得到所有的宠物分类
        List<CTPetCategory> GetAllPetCategoryInfo();

        //增加宠物分类信息
        int InsertPetCategory(CTPetCategory petCategory);

        //删除宠物分类信息
        int DeletePetCategoryInfo(string petCategoryID);

        //编辑宠物分类信息
        int EditPetCategoryInfo(CTPetCategory petCategory);
    }
}
