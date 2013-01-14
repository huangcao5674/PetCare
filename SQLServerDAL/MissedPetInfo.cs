using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.DBUtility;
using PetCare.Model;
using PetCare.IDAL;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;


namespace PetCare.SQLServerDAL
{
    public class MissedPetInfo:IMissedPetInfo
    {
        private const string SQL_SELECT_MISSEDPETINFO = "SELECT [MissID],[UserID],[AddressID],[PetCategoryID],[WeiBoID],[MissTitle],[MissTime]"
                + " ,[LastEditTime],[MissInfo],[PriorityScore],[IP],[FocusNum],[IsVisible]"
                + " ,[IsRecommand],[IsEssence],[LinkUrl],[Status],[PicLocation] FROM [PETCAREDB].[dbo].[DB_MissedPet]";


        private const string SQL_SELECT_MISSEDPETINFO_BY_MISSEDID = "SELECT  [MissID], [UserID],[AddressID],[PetCategoryID],[WeiBoID],[MissTitle],[MissTime]"
                +" ,[LastEditTime],[MissInfo],[PriorityScore],[IP],[FocusNum],[IsVisible]"
                + " ,[IsRecommand],[IsEssence],[LinkUrl],[Status],[PicLocation] FROM [PETCAREDB].[dbo].[DB_MissedPet] WHERE [MissID]=@MissID";

        private const string SQL_SELECT_MISSEDPETINFO_BY_USERID = "SELECT [MissID],[AddressID],[PetCategoryID],[WeiBoID],[MissTitle],[MissTime]"
                + " ,[LastEditTime],[MissInfo],[PriorityScore],[IP],[FocusNum],[IsVisible]"
                + " ,[IsRecommand],[IsEssence],[LinkUrl],[Status],[PicLocation] FROM [PETCAREDB].[dbo].[DB_MissedPet] WHERE [UserID]=@UserID";

        private const string SQL_INSERT_MISSEDPETINFO = "INSERT INTO [PETCAREDB].[dbo].[DB_MissedPet]([MissID],[UserID],[AddressID],[PetCategoryID],"
            +"[WeiBoID],[MissTitle] ,[MissTime],[LastEditTime],[MissInfo],[PriorityScore],[IP],[FocusNum]"
        + ",[IsVisible],[IsRecommand],[IsEssence],[LinkUrl],[Status],[PicLocation]) VALUES(@MissID,@UserID,@AddressID,@PetCategoryID,@WeiBoID,@MissTitle"
            +" ,@MissTime,@LastEditTime,@MissInfo,@PriorityScore,@IP,@FocusNum"
            +",@IsVisible,@IsRecommand,@IsEssence,@LinkUrl,@Status,@PicLocation)";

        private const string SQL_DELETE_MISSEDPETINFO = "DELETE FROM [PETCAREDB].[dbo].[DB_MissedPet] WHERE MissID=@MissID";


        private const string SQL_UPDATE_MISSPET = @"UPDATE [PETCAREDB].[dbo].[DB_MissedPet] SET LastEditTime=@LastEditTime, PetCategoryID=@PetCategoryID, [MissTitle]=@MissTitle,[MissInfo]=@MissInfo,AddressID=@AddressID,IP=@IP WHERE [MissID]=@MissID";


        private const string PARM_USER_ID = "@UserId";

        private const string PARM_MISS_ID = "@MissID";


        //实现接口定义的函数：获得所有的丢失信息
        public List<CTMissedPetInfo> GetAllMissedPetInfoList()
        {
            List<CTMissedPetInfo> MissedPetInfoList = new List<CTMissedPetInfo>();
            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_MISSEDPETINFO, null))
                {
                    while (reader.Read())
                    {
                        CTMissedPetInfo missedPet = new CTMissedPetInfo();
                        missedPet.MissId = reader["MissID"].ToString();
                        missedPet.AddressID = reader["AddressID"].ToString();
                        missedPet.MissInfo = reader["MissInfo"].ToString();
                        missedPet.MissTitle = reader["MissTitle"].ToString();
                        missedPet.PetCategoryID = reader["PetCategoryID"].ToString();
                        missedPet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                        missedPet.PicLocation = reader["PicLocation"].ToString();
                        missedPet.LinkUrl = reader["LinkUrl"].ToString();
                        missedPet.Status = reader["Status"].ToString();
                        bool tempIsRecommand = true;
                        missedPet.IsRecommand = bool.TryParse(reader["IsRecommand"].ToString(), out tempIsRecommand) ? tempIsRecommand : true;
                        bool tempIsEssence = true;
                        missedPet.IsEssence = bool.TryParse(reader["IsEssence"].ToString(), out tempIsEssence) ? tempIsEssence : true;

                        DateTime tempLastEditTime = DateTime.Now;
                        tempLastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(), out tempLastEditTime) ? tempLastEditTime : DateTime.Now;
                        missedPet.LastEditTime = tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");

                        DateTime tempMissTime = DateTime.Now;
                        tempMissTime = DateTime.TryParse(reader["MissTime"].ToString(), out tempMissTime) ? tempMissTime : DateTime.Now;
                        missedPet.MissTime = tempMissTime.ToString("yyyy/MM/dd hh:mm:ss");

                        missedPet.IP = reader["IP"].ToString();
                        int tempFocusNum = 0;
                        missedPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                        MissedPetInfoList.Add(missedPet);
                    }
                    reader.Close();
                    reader.Dispose();
                }
                return MissedPetInfoList;
            }
            catch (Exception ex)
            {
                throw;
            }

            
        }


 

        //获取所有的丢失宠物的文章列表，返回信息列表，分页的方式
        public  List<CVMissedPetInfo> GetAllMissedPetListPerPage(int pageNumber, int NumberPerPage, out int howmanyPages)
        {
            List<CVMissedPetInfo> MissedPetList = new List<CVMissedPetInfo>();

            SqlParameter[] adoptPetParams = null;
            adoptPetParams = new SqlParameter[4];
            adoptPetParams[0] = new SqlParameter("@DescriptionLength", SqlDbType.Int);
            adoptPetParams[1] = new SqlParameter("@PageNumber", SqlDbType.Int);
            adoptPetParams[2] = new SqlParameter("@InfoPerPage", SqlDbType.Int);

            adoptPetParams[0].Value = CPetCareConfiguration.ArticleBreviaryNum;
            adoptPetParams[1].Value = pageNumber;
            adoptPetParams[2].Value = NumberPerPage;

            SqlParameter parameter = new SqlParameter();
            parameter.DbType = DbType.Int16;
            parameter.Direction = ParameterDirection.Output;
            parameter.ParameterName = "@HowManyInfo";
            adoptPetParams[3] = parameter;

            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "proGetMissedInfo", adoptPetParams))
                {
                    while (reader.Read())
                    {
                        CVMissedPetInfo  missedPet = new CVMissedPetInfo();
                        missedPet.MissID = reader["MissID"].ToString();
                        missedPet.City = reader["City"].ToString();
                        missedPet.Province = reader["Province"].ToString();
                        missedPet.MissInfo = reader["MissInfo"].ToString();
                        missedPet.MissTitle = reader["MissTitle"].ToString();
                        missedPet.PetCategoryName = reader["PetCategoryName"].ToString();
                        missedPet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                        missedPet.UserName = reader["UserName"].ToString();
                        missedPet.PicLocation = reader["PicLocation"].ToString();
                        missedPet.Portrait = reader["Portrait"].ToString();
                        missedPet.LinkUrl = reader["LinkUrl"].ToString();
                        missedPet.UserWeiBo = reader["UserWeiBo"].ToString();
                        missedPet.Status = reader["Status"].ToString();
                         bool tempIsRecommand = true;
                         missedPet.IsRecommand = bool.TryParse(reader["IsRecommand"].ToString(), out tempIsRecommand) ? tempIsRecommand : true;
                        bool tempIsEssence = true;
                        missedPet.IsEssence = bool.TryParse(reader["IsEssence"].ToString(), out tempIsEssence) ? tempIsEssence : true;

                        DateTime tempLastEditTime = DateTime.Now;
                        tempLastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(), out tempLastEditTime) ? tempLastEditTime : DateTime.Now;
                        missedPet.LastEditTime = tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");

                        DateTime tempMissTime = DateTime.Now;
                        tempMissTime = DateTime.TryParse(reader["MissTime"].ToString(), out tempMissTime) ? tempMissTime : DateTime.Now;
                        missedPet.MissTime = tempMissTime.ToString("yyyy/MM/dd hh:mm:ss");

                        missedPet.IP = reader["IP"].ToString();
                        int tempFocusNum = 0;
                        missedPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                        int tempCommentCount = 0;
                        missedPet.CommentCount = int.TryParse(reader["CommentCount"].ToString(), out tempCommentCount) ? tempCommentCount : 0;
                        MissedPetList.Add(missedPet);
                    }
                    reader.Close();
                    reader.Dispose();
                    int tempHowmanyPages = 0;
                    howmanyPages = int.TryParse(adoptPetParams[3].Value.ToString(), out tempHowmanyPages) ? tempHowmanyPages : 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return MissedPetList;
        }



        //获取一篇文章的所有的信息（包括所有的文章信息，评论，用户信息）
        public List<CVMissedPetComment> GetMissPetCommentPageList(string missPetID, int pageNumber, int NumberPerPage, out int howmanyPages)
        {
            List<CVMissedPetComment> commentList = new List<CVMissedPetComment>();
            howmanyPages = 6;
            SqlParameter[] missPetParams = null;
            missPetParams = new SqlParameter[]
                            {
                                new SqlParameter("@MissID",SqlDbType.NVarChar,32),
                                new SqlParameter("@DescriptionLength",SqlDbType.Int),
                                new SqlParameter("@PageNumber",SqlDbType.Int),
                                new SqlParameter("@InfoPerPage",SqlDbType.Int),
                                new SqlParameter("@HowManyInfo",SqlDbType.Int,65535,ParameterDirection.Output,true,0,0,"",DataRowVersion.Default,0),
                            };
            missPetParams[0].Value = missPetID;
            missPetParams[1].Value = CPetCareConfiguration.AriticleAllNum;
            missPetParams[2].Value = pageNumber;
            missPetParams[3].Value = NumberPerPage;
            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "proGetMissCommentInfo", missPetParams))
                {
                    while (reader.Read())
                    {
                        CVMissedPetComment missPet = new CVMissedPetComment();
                        missPet.MissID = reader["MissID"].ToString();
                        missPet.City = reader["City"].ToString();
                        missPet.Province = reader["Province"].ToString();
                        missPet.MissInfo = reader["MissInfo"].ToString();
                        missPet.MissTitle = reader["MissTitle"].ToString();
                        missPet.PetCategoryName = reader["PetCategoryName"].ToString();
                        missPet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                        missPet.UserName = reader["UserName"].ToString();
                        missPet.PicLocation = reader["PicLocation"].ToString();
                        missPet.Portrait = reader["Portrait"].ToString();
                        missPet.LinkUrl = reader["LinkUrl"].ToString();
                        missPet.UserWeiBo = reader["UserWeiBo"].ToString();
                        missPet.Status = reader["Status"].ToString();
                        bool tempIsRecommand = true;
                        missPet.IsRecommand = bool.TryParse(reader["IsRecommand"].ToString(), out tempIsRecommand) ? tempIsRecommand : true;
                        bool tempIsEssence = true;
                        missPet.IsEssence = bool.TryParse(reader["IsEssence"].ToString(), out tempIsEssence) ? tempIsEssence : true;

                        DateTime tempLastEditTime = DateTime.Now;
                        tempLastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(), out tempLastEditTime) ? tempLastEditTime : DateTime.Now;
                        missPet.LastEditTime = tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");

                        DateTime tempMissTime = DateTime.Now;
                        tempMissTime = DateTime.TryParse(reader["MissTime"].ToString(), out tempMissTime) ? tempMissTime : DateTime.Now;
                        missPet.MissTime = tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");

                        missPet.IP = reader["IP"].ToString();
                        int tempFocusNum = 0;
                        missPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                        missPet.CommentContent = reader["CommentContent"].ToString();
                        missPet.CommentIP = reader["CommentIP"].ToString();
                        missPet.CommentUserName = reader["CommentUserName"].ToString();
                        missPet.CommentUserProtrait = reader["CommentUserProtrait"].ToString();
                        missPet.CommentUserLevel = reader["CommentUserLevel"].ToString();
                        missPet.CommentID = reader["CommentID"].ToString();
                        commentList.Add(missPet);
                    }
                    reader.Close();
                    reader.Dispose();
                    int tempHowmanyPages = 0;
                    howmanyPages = int.TryParse(missPetParams[4].Value.ToString(), out tempHowmanyPages) ? tempHowmanyPages : 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return commentList;
        }



        //实现接口定义的函数：根据用户ID获取丢失宠物信息
        public List<CTMissedPetInfo> GetMissedPetInfoListByUser(string UserID)
        {
            List<CTMissedPetInfo> MissedPetInfoList = new List<CTMissedPetInfo>();
            SqlParameter parm = new SqlParameter();
            parm.Value = UserID;
            parm.ParameterName = PARM_USER_ID;
            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_MISSEDPETINFO_BY_USERID, parm))
                {
                    while (reader.Read())
                    {
                        CTMissedPetInfo missedPet = new CTMissedPetInfo();
                        missedPet.MissId = reader["MissID"].ToString();
                        missedPet.AddressID = reader["AddressID"].ToString();
                        missedPet.MissInfo = reader["MissInfo"].ToString();
                        missedPet.MissTitle = reader["MissTitle"].ToString();
                        missedPet.PetCategoryID = reader["PetCategoryID"].ToString();
                        missedPet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                        missedPet.PicLocation = reader["PicLocation"].ToString();
                        missedPet.LinkUrl = reader["LinkUrl"].ToString();
                        missedPet.Status = reader["Status"].ToString();
                        bool tempIsRecommand = true;
                        missedPet.IsRecommand = bool.TryParse(reader["IsRecommand"].ToString(), out tempIsRecommand) ? tempIsRecommand : true;
                        bool tempIsEssence = true;
                        missedPet.IsEssence = bool.TryParse(reader["IsEssence"].ToString(), out tempIsEssence) ? tempIsEssence : true;

                        DateTime tempLastEditTime = DateTime.Now;
                        tempLastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(), out tempLastEditTime) ? tempLastEditTime : DateTime.Now;
                        missedPet.LastEditTime = tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");

                        DateTime tempMissTime = DateTime.Now;
                        tempMissTime = DateTime.TryParse(reader["MissTime"].ToString(), out tempMissTime) ? tempMissTime : DateTime.Now;
                        missedPet.MissTime = tempMissTime.ToString("yyyy/MM/dd hh:mm:ss");

                        missedPet.IP = reader["IP"].ToString();
                        int tempFocusNum = 0;
                        missedPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                        MissedPetInfoList.Add(missedPet);
                    }
                    reader.Close();
                    reader.Dispose();
                }
                return MissedPetInfoList;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        //实现接口定义的函数，增加一条信息
        public int InsertMissedPet(CTMissedPetInfo MissedPetInfo)
        {
            int InsertStatus = 0;

            SqlParameter[] missPetParams = null;
            missPetParams = new SqlParameter[]
            {                   new SqlParameter("@MissID",SqlDbType.NVarChar,32),
                                new SqlParameter("@UserID",SqlDbType.NVarChar,20),
                                new SqlParameter("@AddressID",SqlDbType.NVarChar,20),
                                new SqlParameter("@PetCategoryID",SqlDbType.NVarChar,20),
                                new SqlParameter("@WeiBoID",SqlDbType.NVarChar,20),
                                new SqlParameter("@MissTitle",SqlDbType.NVarChar,20),
                                new SqlParameter("@MissTime",SqlDbType.DateTime ),
                                new SqlParameter("@LastEditTime",SqlDbType.DateTime ),
                                new SqlParameter("@MissInfo",SqlDbType.NVarChar),
                                new SqlParameter("@IP",SqlDbType.NVarChar,20),
                                new SqlParameter("@PriorityScore",SqlDbType.Int),
                                new SqlParameter("@FocusNum",SqlDbType.Int),
                                new SqlParameter("@IsVisible",SqlDbType.Bit),
                                new SqlParameter("@IsRecommand",SqlDbType.Bit),
                                new SqlParameter("@IsEssence",SqlDbType.Bit),
                                new SqlParameter("@LinkUrl",SqlDbType.NVarChar),
                                new SqlParameter("@Status",SqlDbType.NVarChar),
                                new SqlParameter("@PicLocation",SqlDbType.NVarChar),

            };
            missPetParams[0].Value = MissedPetInfo.MissId;
            missPetParams[1].Value = MissedPetInfo.UserID;
            missPetParams[2].Value = MissedPetInfo.AddressID;
            missPetParams[3].Value = MissedPetInfo.PetCategoryID;
            missPetParams[4].Value = MissedPetInfo.WeiBoID;
            missPetParams[5].Value = MissedPetInfo.MissTitle;
            missPetParams[6].Value = MissedPetInfo.MissTime;
            missPetParams[7].Value = MissedPetInfo.LastEditTime;
            missPetParams[8].Value = MissedPetInfo.MissInfo;
            missPetParams[9].Value = MissedPetInfo.IP;
            missPetParams[10].Value = MissedPetInfo.PriorityScore;
            missPetParams[11].Value = MissedPetInfo.FocusNum;
            missPetParams[12].Value = MissedPetInfo.IsVisible;
            missPetParams[13].Value = MissedPetInfo.IsRecommand;
            missPetParams[14].Value = MissedPetInfo.IsEssence;
            missPetParams[15].Value = MissedPetInfo.LinkUrl;
            missPetParams[16].Value = MissedPetInfo.Status;
            missPetParams[17].Value = MissedPetInfo.PicLocation;
 
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringInventoryDistributedTransaction))
                {
                    InsertStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_MISSEDPETINFO, missPetParams);
                }
            }
            catch (Exception ex)
            {
            }

            return InsertStatus;
        }

        public int DeleteMissedPet(string MissedID)
        {
  
            int deleteStatus = 0;
            SqlParameter parm = new SqlParameter(PARM_MISS_ID, SqlDbType.NVarChar);
            parm.ParameterName = PARM_MISS_ID;
            parm.Value = MissedID;
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
                {
                    deleteStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_MISSEDPETINFO, parm);
                }
            }
            catch (Exception ex)
            {

            }
            return deleteStatus;
        }

        public int EditMissedPet(CTMissedPetInfo MissedPetInfo)
        {
            int updateStatus = 0;

            //得到所有的参数数组
            SqlParameter[] adoptPetParams = null;
            adoptPetParams = new SqlParameter[]
                            {
                                new SqlParameter("@MissId",SqlDbType.NVarChar,32),
                                new SqlParameter("@AddressID",SqlDbType.NVarChar,20),
                                new SqlParameter("@PetCategoryID",SqlDbType.NVarChar,20),
                                new SqlParameter("@MissTitle",SqlDbType.NVarChar,20),
                                new SqlParameter("@LastEditTime",SqlDbType.DateTime ),
                                new SqlParameter("@MissInfo",SqlDbType.NVarChar),
                                new SqlParameter("@IP",SqlDbType.NVarChar,20),
                            };
            adoptPetParams[0].Value = MissedPetInfo.MissId;
            adoptPetParams[1].Value = MissedPetInfo.AddressID;
            adoptPetParams[2].Value = MissedPetInfo.PetCategoryID;
            adoptPetParams[3].Value = MissedPetInfo.MissTitle;
            adoptPetParams[4].Value = Convert.ToDateTime(MissedPetInfo.LastEditTime);
            adoptPetParams[5].Value = MissedPetInfo.MissInfo;
            adoptPetParams[6].Value = MissedPetInfo.IP;


            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
                {
                    updateStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UPDATE_MISSPET, adoptPetParams);
                }
            }
            catch (Exception ex)
            {

            }
            return updateStatus;

 
        }

        //根据MissedID查找miss文章信息
        public CTMissedPetInfo GetMissedPetByMissedID(string MissedID)
        {
            CTMissedPetInfo MissedPetInfo = new CTMissedPetInfo();
            SqlParameter parm = new SqlParameter();
            parm.Value = MissedID;
            parm.ParameterName = PARM_MISS_ID;
            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_MISSEDPETINFO_BY_MISSEDID, parm))
                {
                    while (reader.Read())
                    {
                        CTMissedPetInfo missedPet = new CTMissedPetInfo();
                        missedPet.MissId = reader["MissID"].ToString();
                        missedPet.AddressID = reader["AddressID"].ToString();
                        missedPet.MissInfo = reader["MissInfo"].ToString();
                        missedPet.MissTitle = reader["MissTitle"].ToString();
                        missedPet.PetCategoryID = reader["PetCategoryID"].ToString();
                        missedPet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                        missedPet.PicLocation = reader["PicLocation"].ToString();
                        missedPet.LinkUrl = reader["LinkUrl"].ToString();
                        missedPet.Status = reader["Status"].ToString();
                        missedPet.UserID = reader["UserID"].ToString();
                        missedPet.WeiBoID = reader["WeiBoID"].ToString();
                        bool tempIsRecommand = true;
                        missedPet.IsRecommand = bool.TryParse(reader["IsRecommand"].ToString(), out tempIsRecommand) ? tempIsRecommand : true;
                        bool tempIsEssence = true;
                        missedPet.IsEssence = bool.TryParse(reader["IsEssence"].ToString(), out tempIsEssence) ? tempIsEssence : true;

                        DateTime tempLastEditTime = DateTime.Now;
                        tempLastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(), out tempLastEditTime) ? tempLastEditTime : DateTime.Now;
                        missedPet.LastEditTime = tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");

                        DateTime tempMissTime = DateTime.Now;
                        tempMissTime = DateTime.TryParse(reader["MissTime"].ToString(), out tempMissTime) ? tempMissTime : DateTime.Now;
                        missedPet.MissTime = tempMissTime.ToString("yyyy/MM/dd hh:mm:ss");

                        missedPet.IP = reader["IP"].ToString();
                        int tempFocusNum = 0;
                        missedPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                        MissedPetInfo=missedPet;
                    }
                    reader.Close();
                    reader.Dispose();
                }
                return MissedPetInfo;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
