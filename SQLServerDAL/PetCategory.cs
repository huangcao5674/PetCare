using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;

namespace PetCare.SQLServerDAL
{
    public class PetCategory:IPetCategory
    {

        private const string SQL_SELECT_PetCategory = @"SELECT [PetCategoryID],[PetCategoryName],[PetCategoryInfo],[IsVisible] FROM [PETCAREDB].[dbo].[DB_PetCategory]";

        private const string SQL_INSERT_PetCategory = @"";

        private const string SQL_DELETE_PetCategory = @"DELETE FROM [PETCAREDB].[dbo].[DB_PetCategory] WHERE PetCategoryID=@PetCategoryId";

        private const string SQL_EDIT_PetCategory = @"";

        private const string PARM_PetCategory_ID = "@PetCategoryId";



        //得到所有的宠物分类
        public List<CTPetCategory> GetAllPetCategoryInfo()
        {
            List<CTPetCategory> list = new List<CTPetCategory>();

            return list;
        }

   
        //增加宠物分类信息
        public int InsertPetCategory(CTPetCategory petCategory)
        {
            int insertStatus = 0;
            return insertStatus;
        }

        //删除宠物分类信息
        public int DeletePetCategoryInfo(string petCategoryID)
        {
            int deleteStatus = 0;
            return deleteStatus;
        }

        //编辑宠物分类信息
        public int EditPetCategoryInfo(string petCategoryID, CTPetCategory petCategory)
        {
            int editStatus = 0;
            return editStatus;
        }

    }
}
