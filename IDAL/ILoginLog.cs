using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;

namespace PetCare.IDAL
{
    public interface ILoginLog
    {
        List<CTLoginLog> GetAllLoginLogList();

        int InsertLoginLog(CTLoginLog loginLog);
    }
}
