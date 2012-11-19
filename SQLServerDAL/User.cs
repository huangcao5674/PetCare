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
        private const string SQL_SELECT_USERS_BY_USERID = @"SELECT  [UserID],[UserName],[UserPass],[UserRealName],[UserAge],[UserSex],[UserAddress],[UserEmail],[UserPhoneNumber],[UserQQNum],[UserInfo] ,[ComplaintNum] FROM [PETCAREDB].[dbo].[DB_UserInfo] where UserID=@UserID";

        private const string SQL_SELECT_USERS = @"SELECT  [UserID],[UserName],[UserPass],[UserRealName],[UserAge],[UserSex],[UserAddress],[UserEmail],[UserPhoneNumber],[UserQQNum],[UserInfo] ,[ComplaintNum] FROM [PETCAREDB].[dbo].[DB_UserInfo]";

        private const string SQL_INSERT_USER = @"INSERT INTO [PETCAREDB].[dbo].[DB_UserInfo]([UserName],[UserPass],[UserRealName],[UserAge],[UserSex],[UserAddress],[UserEmail],[UserPhoneNumber],[UserQQNum],[UserInfo],[ComplaintNum]) VALUES"
            + "(@UserName,@UserPass,@UserRealName,@UserAge,@UserSex,@UserAddress,@UserEmail,@UserPhoneNumber,@UserQQNum,@UserInfo,@ComplaintNum)";

        private const string SQL_DELETE_USER = @"DELETE FROM [PETCAREDB].[dbo].[DB_UserInfo] WHERE UserID=@UserId";

        private const string SQL_EDIT_USER = @"UPDATE [PETCAREDB].[dbo].[DB_UserInfo] SET [UserName] = @UserName,[UserPass] = @UserPass,[UserRealName]= @UserRealName,[UserAge] =@UserAge "
            + ",[UserSex] @UserSex,[UserAddress]=@UserAddress,[UserEmail]=@UserEmail,[UserPhoneNumber]=@UserPhoneNumber"
            + " ,[UserQQNum]=@UserQQNum,[UserInfo]= @UserInfo,[ComplaintNum]=@ComplaintNum WHERE UserID=@UserID";

        private const string SQL_SELECT_KNOWLEDGE_BY_USERID = @"SELECT [KnowledgeID],[UserID],[AddressID],[PetCategoryID],[WeiBoID],[KnowledgeTitle]"
            + " ,[KnowledgeTime],[LastEditTime],[KnowledgeInfo],[PriorityScore],[IP],[FocusNum],[IsVisible]"
            + "FROM [PETCAREDB].[dbo].[DB_KnowledgePet] where UserID=@UserId";

        private const string SQL_SELECT_ADOPT_BY_USERID = @"";

        private const string SQL_SELECT_MISSED_BY_USERID = @"";

        private const string PARM_USER_ID = "@UserId";

        //得到所有的用户的信息
        public List<CTUserInfo> GetAllUserInfo()
        {
            List<CTUserInfo> userInfoList = new List<CTUserInfo>();
            //execute the query
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_USERS, null))
            {
                while (rdr.Read())
                {
                    CTUserInfo user = new CTUserInfo();
                    user.UserID = rdr["UserID"].ToString();
                    user.UserName = rdr["UserName"].ToString();
                    user.UserPass = rdr["UserPass"].ToString();
                    user.UserEmail = rdr["UserEmail"].ToString();
                    user.UserPhoneNumber = rdr["UserPhoneNumber"].ToString();
                    user.UserQQNum = rdr["UserQQNum"].ToString();
                    user.UserRealName = rdr["UserRealName"].ToString();
                    int tempAge = 0;
                    user.UserAge = int.TryParse(rdr["UserAge"].ToString(),out tempAge)?tempAge:0;
                    user.UserInfo = rdr["UserInfo"].ToString();
                    user.UserSex = rdr["UserSex"].ToString();
                    int tempComplain=0;
                    user.ComplainNum = int.TryParse(rdr["ComplaintNum"].ToString(),out tempComplain)?tempComplain:0;
                    userInfoList.Add(user);
                }
            }
            return userInfoList;
        }


        //根据用户的ID得到用户的信息
        public List<CTUserInfo> GetUserInfoByUserID(string UserID)
        {
            List<CTUserInfo> userInfoList = new List<CTUserInfo>();
            SqlParameter parm = new SqlParameter(PARM_USER_ID, SqlDbType.NVarChar);
            parm.Value = UserID;

            //execute the query
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_USERS_BY_USERID, parm))
            {
                while (rdr.Read())
                {
                    CTUserInfo user = new CTUserInfo();
                    user.UserID = rdr["UserID"].ToString();
                    user.UserName = rdr["UserName"].ToString();
                    user.UserPass = rdr["UserPass"].ToString();
                    user.UserEmail = rdr["UserEmail"].ToString();
                    user.UserPhoneNumber = rdr["UserPhoneNumber"].ToString();
                    user.UserQQNum = rdr["UserQQNum"].ToString();
                    user.UserRealName = rdr["UserRealName"].ToString();
                    int tempAge = 0;
                    user.UserAge = int.TryParse(rdr["UserAge"].ToString(), out tempAge) ? tempAge : 0;
                    user.UserInfo = rdr["UserInfo"].ToString();
                    user.UserSex = rdr["UserSex"].ToString();
                    int tempComplain = 0;
                    user.ComplainNum = int.TryParse(rdr["ComplaintNum"].ToString(), out tempComplain) ? tempComplain : 0;
                    userInfoList.Add(user);
                }
            }

            return userInfoList;
        }


        //增加用户信息
        public int InsertUser(CTUserInfo userInfo)
        {
            int insertStatus = 0;
            SqlParameter[] parms = null;
            parms = new SqlParameter[]
                            {
                                new SqlParameter("@UserName",SqlDbType.NVarChar,50),
                                new SqlParameter("@UserPass",SqlDbType.NVarChar,50),
                                new SqlParameter("@UserRealName",SqlDbType.NVarChar,50),
                                new SqlParameter("@UserAge",SqlDbType.Int),
                                new SqlParameter("@UserSex",SqlDbType.Char,2),
                                new SqlParameter("@UserAddress",SqlDbType.NVarChar,50),
                                new SqlParameter("@UserEmail",SqlDbType.NVarChar,50),
                                new SqlParameter("@UserPhoneNumber",SqlDbType.NVarChar,11),
                                new SqlParameter("@UserQQNum",SqlDbType.NVarChar,10),
                                new SqlParameter("@UserInfo",SqlDbType.NVarChar,100),
                                new SqlParameter("@ComplaintNum",SqlDbType.Int),
                            };

            parms[0].Value = userInfo.UserName;
            parms[1].Value = userInfo.UserPass;
            parms[2].Value = userInfo.UserRealName;
            parms[3].Value = userInfo.UserAge;
            parms[4].Value = userInfo.UserSex;
            parms[5].Value = userInfo.UserAddress;
            parms[6].Value = userInfo.UserEmail;
            parms[7].Value = userInfo.UserPhoneNumber;
            parms[8].Value = userInfo.UserQQNum;
            parms[9].Value = userInfo.UserInfo;
            parms[10].Value = userInfo.ComplainNum;

            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
            {
                insertStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_USER, parms);
            }
            return insertStatus;
        }


        //删除用户信息
       public int DeleteUserInfo(string UserID)
        {
            int deleteStatus = 0;
            SqlParameter parm = new SqlParameter(PARM_USER_ID, SqlDbType.NVarChar);
            parm.Value = UserID;
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
                {
                    deleteStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_USER, parm);
                }
                return deleteStatus;

            }
            catch (Exception ex)
            {
                return 0;
            }
        }


        //编辑用户信息
       public int EditUserInfo(string UserID,CTUserInfo userInfo)
       {
           int EditStatus = 0;
           SqlParameter[] parms = null;
           parms = new SqlParameter[]
                            {
                                new SqlParameter("@UserName",SqlDbType.NVarChar,50),
                                new SqlParameter("@UserPass",SqlDbType.NVarChar,50),
                                new SqlParameter("@UserRealName",SqlDbType.NVarChar,50),
                                new SqlParameter("@UserAge",SqlDbType.Int),
                                new SqlParameter("@UserSex",SqlDbType.Char,2),
                                new SqlParameter("@UserAddress",SqlDbType.NVarChar,50),
                                new SqlParameter("@UserEmail",SqlDbType.NVarChar,50),
                                new SqlParameter("@UserPhoneNumber",SqlDbType.NVarChar,11),
                                new SqlParameter("@UserQQNum",SqlDbType.NVarChar,10),
                                new SqlParameter("@UserInfo",SqlDbType.NVarChar,100),
                                new SqlParameter("@ComplaintNum",SqlDbType.Int),
                                new SqlParameter("@UserID",SqlDbType.NVarChar,20),
                            };

           parms[0].Value = userInfo.UserName;
           parms[1].Value = userInfo.UserPass;
           parms[2].Value = userInfo.UserRealName;
           parms[3].Value = userInfo.UserAge;
           parms[4].Value = userInfo.UserSex;
           parms[5].Value = userInfo.UserAddress;
           parms[6].Value = userInfo.UserEmail;
           parms[7].Value = userInfo.UserPhoneNumber;
           parms[8].Value = userInfo.UserQQNum;
           parms[9].Value = userInfo.UserInfo;
           parms[10].Value = userInfo.ComplainNum;
           parms[11].Value = UserID;

           using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
           {
               EditStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_EDIT_USER, parms);
           }

           return EditStatus;
       }


       //得到用户的领养宠物信息
       public List<CTAdoptPet> GetUserAdoptPetInfo(string UserID)
       {
           List<CTAdoptPet> adoptList = new List<CTAdoptPet>();
           return adoptList;
       }


       //得到用户的宠物知识的信息
       public List<CTKnowledgePet> GetUserKnowledgePetInfo(string UserID)
       {
           List<CTKnowledgePet> knowledgeList = new List<CTKnowledgePet>();

           SqlParameter parm = new SqlParameter(PARM_USER_ID, SqlDbType.NVarChar);
           parm.Value = UserID;
           //execute the query
           using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_KNOWLEDGE_BY_USERID, parm))
           {
               while (rdr.Read())
               {
                   CTKnowledgePet knowledgePet = new CTKnowledgePet();
                   knowledgePet.UserID = rdr["UserID"].ToString();
                   knowledgePet.KnowledgeID = rdr["KnowledgeID"].ToString();
                   knowledgePet.AddressID = rdr["AddressID"].ToString();
                   knowledgePet.PetCaretegoryID = rdr["PetCategoryID"].ToString();
                   knowledgePet.WeiBoID = rdr["WeiBoID"].ToString();
                   knowledgePet.KnowledgeTitle = rdr["KnowledgeTitle"].ToString();
                   knowledgePet.KnowledgeInfo = rdr["KnowledgeInfo"].ToString();
                   int tempPriorityScore = 0;
                   knowledgePet.PriorityScore = int.TryParse(rdr["PriorityScore"].ToString(), out tempPriorityScore) ? tempPriorityScore : 0;
                   knowledgePet.IP = rdr["IP"].ToString();
                   int tempFocusNum = 0;
                   knowledgePet.FocusNum = int.TryParse(rdr["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                   bool tempisVisible = true;
                   knowledgePet.IsVisible = bool.TryParse(rdr["IsVisible"].ToString(), out tempisVisible) ? tempisVisible : true;
                   DateTime tempDate=DateTime.Now;
                   knowledgePet.KnowledgeTime =DateTime.TryParse(rdr["KnowledgeTime"].ToString(),out tempDate)?tempDate:DateTime.Now;
                   DateTime tempEditTime = DateTime.Now;
                   knowledgePet.LastEditTime = DateTime.TryParse(rdr["LastEditTime"].ToString(), out tempEditTime) ? tempEditTime : DateTime.Now;
                   knowledgeList.Add(knowledgePet);
               }
           }
           return knowledgeList;
       }


       //得到用户的丢失宠物的信息
       public List<CTMissedPetInfo> GetUserMissedPetInfo(string UserID)
       {
           List<CTMissedPetInfo> missedList = new List<CTMissedPetInfo>();
           return missedList;
       }
       
    }
}
