using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;
using PetCare.DALFactory;

namespace PetCare.BLL
{
    public class PetCategory
    {
        private static readonly IPetCategory dal = PetCare.DALFactory.DataAccess.CreateCategory();


        //得到所有宠物种类的信息
        public List<CTPetCategory> GetPetCategoryList()
        {
           return dal.GetAllPetCategoryInfo();
        }
        //插入新的宠物的种类信息
        public int InsertPetCategory(CTPetCategory petcategory)
        {
            return dal.InsertPetCategory(petcategory);
        }

        //删除宠物的种类信息
        public int DeletePetCategory(string petCagetoryID)
        {
            return dal.DeletePetCategoryInfo(petCagetoryID);
        }

        //编辑宠物的种类信息
        public int EditPetCategory(CTPetCategory petcategory)
        {
            return dal.EditPetCategoryInfo(petcategory);
        }
    }
}
