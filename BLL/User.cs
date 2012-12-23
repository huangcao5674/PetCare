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

        //获取所有的用户信息
        public List<CTUserInfo> GetAllUserList()
        {
            return dal.GetAllUserInfo();
        }

        //根据ID获取用户信息
        public List<CTUserInfo> GetUserInfoByUserID(string userID)
        {
            return dal.GetUserInfoByUserID(userID);
        }

        //插入用户信息
        public int InsertUserInfo(CTUserInfo userinfo)
        {
            return dal.InsertUser(userinfo);
        }

        //删除用户信息
        public int DeleteUserInfo(string userID)
        {
            return dal.DeleteUserInfo(userID);
        }

        //编辑用户信息
        public int EditUserInfo(string UserID, CTUserInfo userInfo)
        {
            return dal.EditUserInfo(UserID,userInfo);
        }

        //用户登录验证
        public int ValidateUserLogin(string UserName, string UserPass)
        {
            return dal.UserVerify(UserName, UserPass);
        }
 
    }
}
