using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;

namespace PetCare.DALFactory
{
    public  interface IAdoptPet
    {
        //获取所有的领养宠物的文章信息
        List<CTAdoptPet> GetAllAdoptPetList();


        //根据用户ID得到用户的发布的领养宠物的信息
        List<CTAdoptPet> GetAdoptPetListByUser(int UserID);

    }
}
