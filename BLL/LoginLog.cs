using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;

namespace PetCare.BLL
{
    public class LoginLog
    {
        private static readonly ILoginLog dal = PetCare.DALFactory.DataAccess.CreateLoginLog();


        //检索出所有的登陆信息
        public List<CTLoginLog> GetAllLoginLog()
        {
            return dal.GetAllLoginLogList();
        }


        //插入一条登陆信息
        public int InsertLoginLog(CTLoginLog loginlog)
        {
            return dal.InsertLoginLog(loginlog);
        }

    }
}
