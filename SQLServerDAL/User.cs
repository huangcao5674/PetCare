using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.BLL;
using PetCare.Model;
using PetCare.DBUtility;
using System.Data;
using System.Data.SqlClient;


namespace PetCare.SQLServerDAL
{
    public class User:IUser
    {
        private const string SQL_SELECT_USERS_BY_USERID= "";

        private const string SQL_SELECT_USERS = "";

        private const string PARM_USER_ID = "@UserId";

        public List<CTUserInfo> GetAllUserInfo()
        {
            List<CTUserInfo> userInfoList = new List<CTUserInfo>();
            return userInfoList;
        }

        public List<CTUserInfo> GetUserInfoByUserID(int UserID)
        {
            List<CTUserInfo> userInfoList = new List<CTUserInfo>();
            SqlParameter parm = new SqlParameter(PARM_USER_ID, SqlDbType.Int);
            parm.Value = UserID;

            //execute the query
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_USERS_BY_USERID, parm))
            {
                while (rdr.Read())
                {
                    CTUserInfo userInfo = new CTUserInfo(rdr.GetString(0), rdr.GetString(1), rdr.GetString(2),
                        rdr.GetInt32(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6),
                        rdr.GetString(7), rdr.GetString(8), rdr.GetString(9), rdr.GetInt32(10));
                    userInfoList.Add(userInfo);
                }
            }

            return userInfoList;
        }
    }
}
