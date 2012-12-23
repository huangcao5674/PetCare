using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;
using PetCare.IDAL;
using PetCare.DALFactory;

namespace PetCare.BLL
{
    public class AdoptPet
    {
        private static readonly IAdoptPet dal = PetCare.DALFactory.DataAccess.CreateAdoptPet();


        //返回所有的领养信息（这个一般不会用到）
        public List<CTAdoptPet> GetPetAdoptPetList()
        {
            return dal.GetAllAdoptPetList();
        }

        //获取所有的领养宠物的文章列表，返回信息列表，分页的方式
        public List<CVAdoptPet> GetPetAdoptPerPageList(int pageNumber,int perPage,out int howmanyPages)
        {
            return dal.GetAllAdoptPetListPerPage(pageNumber, perPage, out howmanyPages);
        }

        //获取一篇文章的所有的信息，返回信息列表（包含文章的所有内容，对应用户，所有评论），分页的方式
        public List<CVAdoptPetComment> GetPetAdoptCommentPerPageList(string adoptID,int pageNumber, int perPage, out int howmanyPages)
        {
            return dal.GetAllAdoptCommentListPerPage(adoptID, pageNumber, perPage, out howmanyPages);
        }

        //根据用户的ID，查找用户发布的领养的信息，返回领养信息列表
        public List<CTAdoptPet> GetPetAdoptPetListByUserID(string UserID)
        {
            return dal.GetAdoptPetListByUser(UserID);
        }

        //根据宠物地区 ，宠物类型，查找领养的信息，返回领养信息的列表，分页的方式返回
        public List<CVAdoptPet> GetPetAdoptPetListByAddressID(bool IsAdopt, string AddressID, string PetCategoryID, int pageNumber, int NumberPerPage, out int howmanyPages)
        {
            return dal.GetAdoptPetListByAddressCategory(IsAdopt, AddressID, PetCategoryID, pageNumber, NumberPerPage, out howmanyPages);
        }

        //增加一条领养的信息
        public int InsertAdoptPet(CTAdoptPet adoptPet)
        {
            return dal.InsertAdoptPet(adoptPet);
        }

        //删除一篇领养的文章
        public int DeleteAdoptPet(string adoptID)
        {
            return dal.DeleteAdoptPet(adoptID);
        }

    }
}
