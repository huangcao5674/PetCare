using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using PetCare.DBUtility;

namespace PetCare.SQLServerDAL
{
    public class UserFocus:IUserFocus
    {
        //得到所有的用户的信息
        public List<CUserFocusArticle> GetAllUserFocusInfo()
        {
            List<CUserFocusArticle> list = new List<CUserFocusArticle>();
            return list;
        }

        //根据用户的ID 获取用户的个人信息
       public List<CUserFocusArticle> GetUserFocusInfoByUserID(string UserID)
        {
            List<CUserFocusArticle> focusList = new List<CUserFocusArticle>();
            SqlParameter parm = new SqlParameter("@UserId", SqlDbType.NVarChar);
            parm.Value = UserID;

            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "GetUserFocus", parm))
            {
                while (rdr.Read())
                {
                    CUserFocusArticle userfocus = new CUserFocusArticle();
                    userfocus.userID = rdr["UserID"].ToString();
                    userfocus.userName = rdr["UserName"].ToString();
                    userfocus.articleTitle = rdr["ArticleTitle"].ToString();
                    userfocus.articleType = rdr["ArticleType"].ToString();
                    userfocus.deployTime = rdr["DeployTime"].ToString();
                    userfocus.aritcleInfo = rdr["ArticleInfo"].ToString();
                    userfocus.focusNum =int.Parse( rdr["FocusNum"].ToString());
                    focusList.Add(userfocus);
                }
            }
            return focusList;
        }

       public  int InsertUserFocus(CTUserFocus userInfo)
        {
            int insertStatus = 0;
            return insertStatus;
        }
    }
}
