using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfPetService.Model;
using WcfPetService.DAL;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace WcfPetService
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    public class PetCareService : IPetCareService
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
        public List<CUserInfo> GetUsersInfoList()
        {
            string QuerySql = @"select *　from dbo.DB_UserInfo";
            DbCommand comm = CGenerateDataAccess.CreateCommand(CommandType.Text, QuerySql);
            DataTable UserInfoDataList = CGenerateDataAccess.ExecuteSelectCommand(comm);


            List<CUserInfo> UserInfoList = new List<CUserInfo>();
            

            return UserInfoList;
        }
    }
}
