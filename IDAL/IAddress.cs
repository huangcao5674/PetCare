using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;

namespace PetCare.IDAL
{
    public interface IAddress
    {
        //得到所有的地址的信息
        List<CTAddress> GetAllAddressInfo();

        //根据信息
        List<CTAddress> GetUserInfoByProvince(string provinceName);

        //增加地址信息
        int InsertAddress(CTAddress addressInfo);

        //删除地址信息
        int DeleteAddress(string addressInfo);
    }
}
