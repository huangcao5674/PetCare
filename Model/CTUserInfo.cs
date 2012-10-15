using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq.Mapping;

namespace PetCare.Model
{
    [Serializable]
    [Table(Name = "DB_UserInfo")]
    public class CTUserInfo
    {
        public CTUserInfo()
        {
        }
        public CTUserInfo(string userName, string userPass, string userRealName, int userAge, string userSex,
            string userAddress, string userEmail, string userPhoneNumber, string userQQNum, string userInfo,
            int complainNum)
        {
            this.UserName = userName;
            this.UserPass = userPass;
            this.UserRealName = userRealName;
            this.UserAge = userAge;
            this.UserSex = userSex;
            this.UserAddress = userAddress;
            this.UserEmail = userEmail;
            this.UserPhoneNumber = userPhoneNumber;
            this.UserQQNum = userQQNum;
            this.UserInfo = userInfo;
            this.ComplainNum = complainNum;
        }

        //写出所有的userinfo属性
        public string UserName
        { 
            get; 
            set; 
        }

        public string UserPass
        {
            get;
            set;
        }
        public string UserRealName
        {
            get;
            set;
        }
        public int UserAge
        {
            get;
            set;
        }
        public string UserSex
        {
            get;
            set;
        }
        public string UserAddress
        {
            get;
            set;
        }
        public string UserEmail
        {
            get;
            set;
        }
        public string UserPhoneNumber
        {
            get;
            set;
        }
        public string UserQQNum
        {
            get;
            set;
        }
        public string UserInfo
        {
            get;
            set;
        }
        public int ComplainNum
        {
            get;
            set;
        }
    }


}