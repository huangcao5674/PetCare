using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
 

namespace WcfPetService
{
    [DataContract]
    public class CUserInfo
    {
        //写出所有的userinfo属性
        [DataMember]
        public string UserName
        { 
            get; 
            set; 
        }
        [DataMember]
        public string UserPass
        {
            get;
            set;
        }
        [DataMember]
        public string UserRealName
        {
            get;
            set;
        }
        [DataMember]
        public int UserAge
        {
            get;
            set;
        }
        [DataMember]
        public string UserSex
        {
            get;
            set;
        }
        [DataMember]
        public string UserAddress
        {
            get;
            set;
        }
        [DataMember]
        public string UserEmail
        {
            get;
            set;
        }
        [DataMember]
        public string UserPhoneNumber
        {
            get;
            set;
        }
        [DataMember]
        public string UserQQNum
        {
            get;
            set;
        }
        [DataMember]
        public string UserInfo
        {
            get;
            set;
        }
        [DataMember]
        public int ComplainNum
        {
            get;
            set;
        }
    }


}