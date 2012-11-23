using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;

namespace PetCare.BLL
{
    public class UserFocus
    {
        private static readonly IUserFocus dal = PetCare.DALFactory.DataAccess.CreateUserFocus();

        //获取所有的用户信息
        public List<CUserFocusArticle> GetAllUserFocusInfoByUserID(string userID)
        {
            return dal.GetUserFocusInfoByUserID(userID);
        }
    }
}
