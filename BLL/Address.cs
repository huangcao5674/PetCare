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
    }
}
