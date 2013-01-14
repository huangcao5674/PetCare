using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;

namespace PetCare.IDAL
{
    public  interface IAdoptPet
    {
        //获取所有的领养宠物的文章信息
        List<CTAdoptPet> GetAllAdoptPetList();

        //根据adoptID获取其信息
        CTAdoptPet GetAdoptInfoByAdoptID(string adoptID);

        //获取所有的领养宠物的文章列表，返回信息列表，分页的方式
        List<CVAdoptPet> GetAllAdoptPetListPerPage(int pageNumber, int NumberPerPage, out int howmanyPages);

        //获取一篇文章的所有的信息，返回信息列表（包含文章的所有内容，对应用户，所有评论），分页的方式
        List<CVAdoptPetComment> GetAllAdoptCommentListPerPage(string adoptID, int pageNumber, int NumberPerPage, out int howmanyPages);

        //根据用户ID得到用户的发布的领养宠物的信息
        List<CTAdoptPet> GetAdoptPetListByUser(string UserID);

        //根据宠物类型地区得到领养宠物的信息
        List<CVAdoptPet> GetAdoptPetListByAddressCategory(bool IsAdopt, string AddressID, string PetCategoryID, int pageNumber, int NumberPerPage, out int howmanyPages);

        //增加用户领养宠物的信息
        int InsertAdoptPet(CTAdoptPet AdoptPetInfo);

        //删除用户领养宠物信息
        int DeleteAdoptPet(string AdoptPetID);

        //更新领养的信息
        int UpdateAdoptPet(CTAdoptPet AdoptPetInfo);






    }
}
