using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;

namespace PetCare.IDAL
{
    public interface IUserFocus
    {
        //得到所有的用户的信息
        List<CTUserFocus> GetAllUserFocusInfo();

        //根据用户的ID 获取用户的个人信息
        List<CTUserFocus> GetUserFocusInfoByUserID(string UserID);

        int InsertUserFocus(CTUserFocus userInfo);
    }
}
