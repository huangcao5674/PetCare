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

        List<CVAdoptPet> GetAllAdoptPetListNew(int pageNumber, int NumberPerPage, out int howmanyPages);

        //根据用户ID得到用户的发布的领养宠物的信息
        List<CTAdoptPet> GetAdoptPetListByUser(string UserID);

        //根据地区得到领养宠物的信息
        List<CTAdoptPet> GetAdoptPetListByAddress(string AddressID);

        //根据宠物类型得到领养宠物的信息
        List<CTAdoptPet> GetAdoptPetListByPetCategory(string PetCategoryID);

        //根据宠物类型和地址信息得到领养宠物的信息
        List<CTAdoptPet> GetAdoptPetListByPetCategoryAddress(string PetCategoryID, string AddressID);

        //增加用户领养宠物的信息
        int InsertAdoptPet(CTAdoptPet AdoptPetInfo);

        //删除用户领养宠物信息
        int DeleteAdoptPet(string AdoptPetID);

        //更新领养的信息
        int UpdateAdoptPet(CTAdoptPet AdoptPetInfo);



    }
}
