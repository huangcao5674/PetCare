using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.DALFactory;
using PetCare.Model;
using PetCare.IDAL;

namespace PetCare.BLL
{
    public class Address
    {
        private static readonly IAddress  dal = PetCare.DALFactory.DataAccess.CreateAddress();

        //获取所有的地理信息
        public List<CTAddress> GetAllUserList()
        {
            return dal.GetAllAddressInfo();
        }

        //根据省名称获取所有的地理信息
        public List<CTAddress> GetAllAddressByID(string provinceName)
        {
            return dal.GetUserInfoByProvince(provinceName);
        }

        //插入新的地理信息
        public int InsertAddressInfo(CTAddress address)
        {
            return dal.InsertAddress(address);
        }

        //更新地理信息
        public int UpdateAddressInfo(CTAddress address)
        {
            return dal.UpdateAddress(address);
        }

        //删除地理信息
        public int DeleteAddressInfo(string addressID)
        {
            return dal.DeleteAddress(addressID);
        }
    }
}
