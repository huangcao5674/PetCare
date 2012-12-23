using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;
using PetCare.IDAL;

namespace PetCare.SQLServerDAL
{
    public class LoginLog:ILoginLog
    {
        public List<CTLoginLog> GetAllLoginLogList()
        {
            List<CTLoginLog> LoginLogList = new List<CTLoginLog>();
            return LoginLogList;
        }

        public int InsertLoginLog(CTLoginLog loginLog)
        {
            int InsertStatus = 0;
            return InsertStatus;
        }
    }
}
