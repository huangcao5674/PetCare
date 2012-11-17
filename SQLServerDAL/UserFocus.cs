using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;

namespace PetCare.SQLServerDAL
{
    public class UserFocus:IUserFocus
    {
        //得到所有的用户的信息
       public  List<CTUserFocus> GetAllUserFocusInfo()
        {
            List<CTUserFocus> list = new List<CTUserFocus>();
            return list;
        }

        //根据用户的ID 获取用户的个人信息
       public  List<CTUserFocus> GetUserFocusInfoByUserID(string UserID)
        {
            List<CTUserFocus> list = new List<CTUserFocus>();
            return list;
        }

       public  int InsertUserFocus(CTUserFocus userInfo)
        {
            int insertStatus = 0;
            return insertStatus;
        }
    }
}
