using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;
using PetCare.DALFactory;


namespace PetCare.BLL
{
    public class User 
    {
        private static readonly IUser dal = PetCare.DALFactory.DataAccess.CreateUser();

        public List<CTUserInfo> GetAllUserList()
        {
            return dal.GetAllUserInfo();
        }
        public List<CTUserInfo> GetUserInfoByUserID(string userID)
        {
            return dal.GetUserInfoByUserID(userID);
        }
        public int InsertUserInfo(CTUserInfo userinfo)
        {
            return dal.InsertUser(userinfo);
        }
        public int DeleteUserInfo(string userID)
        {
            return dal.DeleteUserInfo(userID);
        }
        public int EditUserInfo(string UserID, CTUserInfo userInfo)
        {
            return dal.EditUserInfo(UserID,userInfo);
        }
    }
}
