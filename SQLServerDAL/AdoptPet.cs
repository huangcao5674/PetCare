﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;
using PetCare.DBUtility;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace PetCare.SQLServerDAL
{
    public class AdoptPet : IAdoptPet
    {
        private const string SQL_SELECT_ADOPTPET = "SELECT   [AdoptID],[UserID],[AddressID],[PetCategoryID],[WeiBoID],[AdoptTitle],[AdoptTime],[LastEditTime]"
            + ",[AdoptInfo],[IP],[PriorityScore],[FocusNum],[IsVisible],[IsAdopt] FROM [PETCAREDB].[dbo].[DB_AdoptPet] WHERE [IsVisible]=1 AND [IsAdopt]=1";


        private const string SQL_SELECT_ADOPTPET_BY_ADIPTID = "SELECT   [AdoptID],[UserID],[AddressID],[PetCategoryID],[WeiBoID],[AdoptTitle],[AdoptTime],[LastEditTime]"
            + ",[AdoptInfo],[IP],[PriorityScore],[FocusNum],[IsVisible],[IsAdopt] FROM [PETCAREDB].[dbo].[DB_AdoptPet] WHERE  AdoptID=@AdoptID";



        private const string SQL_SELECT_ADOPTPET_BY_USERID = "SELECT   [AdoptID],[UserID],[AddressID],[PetCategoryID],[WeiBoID],[AdoptTitle],[AdoptTime],[LastEditTime]"
            + ",[AdoptInfo],[IP],[PriorityScore],[FocusNum],[IsVisible] FROM [PETCAREDB].[dbo].[DB_AdoptPet] WHERE UserID=@UserId";

        private const string SQL_SELECT_ADOPTPET_BY_ADDRESS = "SELECT   [AdoptID],[UserID],[AddressID],[PetCategoryID],[WeiBoID],[AdoptTitle],[AdoptTime],[LastEditTime]"
            + ",[AdoptInfo],[IP],[PriorityScore],[FocusNum],[IsVisible] FROM [PETCAREDB].[dbo].[DB_AdoptPet] WHERE AddressID=@AddressID";

        private const string SQL_SELECT_ADOPTPET_BY_PETCATEGORY = "SELECT   [AdoptID],[UserID],[AddressID],[PetCategoryID],[WeiBoID],[AdoptTitle],[AdoptTime],[LastEditTime]"
            + ",[AdoptInfo],[IP],[PriorityScore],[FocusNum],[IsVisible] FROM [PETCAREDB].[dbo].[DB_AdoptPet] WHERE PetCategoryID=@PetCategoryID";

        private const string SQL_SELECT_ADOPTPET_BY_PETCATEGORYADDRESS = "SELECT   [AdoptID],[UserID],[AddressID],[PetCategoryID],[WeiBoID],[AdoptTitle],[AdoptTime],[LastEditTime]"
            + ",[AdoptInfo],[IP],[PriorityScore],[FocusNum],[IsVisible] FROM [PETCAREDB].[dbo].[DB_AdoptPet] WHERE PetCategoryID=@PetCategoryID AND AddressID=@AddressID";

        private const string SQL_INSERT_ADOPTPET = "INSERT INTO [PETCAREDB].[dbo].[DB_AdoptPet]([AdoptID],[UserID],[AddressID],[PetCategoryID]"
          + ",[WeiBoID],[AdoptTitle],[AdoptTime],[LastEditTime],[AdoptInfo],[IP],[PriorityScore],[FocusNum],[IsVisible],[IsAdopt])VALUES"
          + "(@AdoptID,@UserID ,@AddressID ,@PetCategoryID ,@WeiBoID ,@AdoptTitle ,@AdoptTime ,@LastEditTime ,@AdoptInfo ,@IP ,@PriorityScore ,@FocusNum ,@IsVisible,@IsAdopt)";

        private const string SQL_DELETE_ADOPTPET = "UPDATE [PETCAREDB].[dbo].[DB_AdoptPet] SET [IsVisible] = false WHERE AdoptID=@AdoptID,[LastEditTime]=@LastEditTime,"
            + "[AdoptInfo]=@AdoptInfo,[IP]=@IP WHERE [AdoptID]=@AdoptID";

        private const string SQL_UPDATE_ADOPTPET = "UPDATE [PETCAREDB].[dbo].[DB_AdoptPet] SET LastEditTime=@LastEditTime, PetCategoryID=@PetCategoryID, [AdoptTitle]=@AdoptTitle,[AdoptInfo]=@AdoptInfo,AddressID=@AddressID,IP=@IP WHERE [AdoptID]=@AdoptID";

        private const string PARM_USER_ID = "@UserId";

        private const string PARM_ADOPT_ID = "@AdoptID";

        private const string PARM_ADDRESS_ID = "@AddressID";

        private const string PARM_PETCATEGORU_ID = "@PetCategoryID";

        //获取所有的petlist
        public List<CTAdoptPet> GetAllAdoptPetList()
        {
            List<CTAdoptPet> AdoptPetList = new List<CTAdoptPet>();
            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_ADOPTPET, null))
                {
                    while (reader.Read())
                    {
                        CTAdoptPet adoptPet = new CTAdoptPet();
                        adoptPet.AdoptID = reader["AdoptID"].ToString();
                        adoptPet.UserID = reader["UserID"].ToString();
                        adoptPet.AddressID = reader["AddressID"].ToString();
                        adoptPet.AdoptInfo = reader["AdoptInfo"].ToString();
                        adoptPet.AdoptTitle = reader["AdoptTitle"].ToString();
                        adoptPet.PetCategoryID = reader["PetCategoryID"].ToString();
                        adoptPet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                        adoptPet.WeiBoID = reader["WeiBoID"].ToString();
                        bool tempIsAdopt = true;
                        adoptPet.IsAdopt = bool.TryParse(reader["IsAdopt"].ToString(), out tempIsAdopt) ? tempIsAdopt : true;

                        DateTime tempLastEditTime = DateTime.Now;
                        tempLastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(), out tempLastEditTime) ? tempLastEditTime : DateTime.Now;
                        adoptPet.LastEditTime = tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");

                        DateTime tempAdoptTime = DateTime.Now;
                        tempAdoptTime = DateTime.TryParse(reader["AdoptTime"].ToString(), out tempAdoptTime) ? tempAdoptTime : DateTime.Now;
                        adoptPet.AdoptTime = tempAdoptTime.ToString("yyyy/MM/dd hh:mm:ss");

                        adoptPet.IsVisible = bool.Parse(reader["IsVisible"].ToString());
                        adoptPet.IP = reader["IP"].ToString();
                        int tempFocusNum = 0;
                        adoptPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                        AdoptPetList.Add(adoptPet);
                    }
                }
            }
            catch (Exception ex)
            {
            }

            return AdoptPetList;
        }

        //根据adoptID 获取对应的信息
        public CTAdoptPet GetAdoptInfoByAdoptID(string adoptID)
        {
            CTAdoptPet adoptInfo = new CTAdoptPet();
            SqlParameter parm = new SqlParameter();
            parm.ParameterName = PARM_ADOPT_ID;
            parm.Value = adoptID;
            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_ADOPTPET_BY_ADIPTID, parm))
                {
                    while (reader.Read())
                    {
                        CTAdoptPet adoptPet = new CTAdoptPet();
                        adoptPet.AdoptID = reader["AdoptID"].ToString();
                        adoptPet.UserID = reader["UserID"].ToString();
                        adoptPet.AddressID = reader["AddressID"].ToString();
                        adoptPet.AdoptInfo = reader["AdoptInfo"].ToString();
                        adoptPet.AdoptTitle = reader["AdoptTitle"].ToString();
                        adoptPet.PetCategoryID = reader["PetCategoryID"].ToString();
                        adoptPet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                        adoptPet.WeiBoID = reader["WeiBoID"].ToString();
                        bool tempIsAdopt = true;
                        adoptPet.IsAdopt = bool.TryParse(reader["IsAdopt"].ToString(), out tempIsAdopt) ? tempIsAdopt : true;

                        DateTime tempLastEditTime = DateTime.Now;
                        tempLastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(), out tempLastEditTime) ? tempLastEditTime : DateTime.Now;
                        adoptPet.LastEditTime = tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");

                        DateTime tempAdoptTime = DateTime.Now;
                        tempAdoptTime = DateTime.TryParse(reader["AdoptTime"].ToString(), out tempAdoptTime) ? tempAdoptTime : DateTime.Now;
                        adoptPet.AdoptTime = tempAdoptTime.ToString("yyyy/MM/dd hh:mm:ss");

                        adoptPet.IsVisible = bool.Parse(reader["IsVisible"].ToString());
                        adoptPet.IP = reader["IP"].ToString();
                        int tempFocusNum = 0;
                        adoptPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                        adoptInfo=adoptPet;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return adoptInfo;
        }
            


        //获取所有的领养宠物的文章列表，返回信息列表，分页的方式
        public List<CVAdoptPet> GetAllAdoptPetListPerPage(int pageNumber, int NumberPerPage, out int howmanyPages)
        {
             SqlParameter[] adoptPetParams = null;
             adoptPetParams = new SqlParameter[5];
             adoptPetParams[0] = new SqlParameter("@IsAdopt", SqlDbType.Bit);
             adoptPetParams[1] = new SqlParameter("@DescriptionLength", SqlDbType.Int);
             adoptPetParams[2] = new SqlParameter("@PageNumber", SqlDbType.Int);
             adoptPetParams[3] = new SqlParameter("@AdoptInfoPerPage", SqlDbType.Int);
             
            adoptPetParams[0].Value = true;
            adoptPetParams[1].Value = CPetCareConfiguration.ArticleBreviaryNum;
            adoptPetParams[2].Value = pageNumber;
            adoptPetParams[3].Value = NumberPerPage;

            SqlParameter parameter = new SqlParameter();
            parameter.DbType = DbType.Int16;
            parameter.Direction = ParameterDirection.Output;
            parameter.ParameterName = "@HowManyAdoptInfo";
            adoptPetParams[4] = parameter;
             

            List<CVAdoptPet> AdoptPetList = new List<CVAdoptPet>();
            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "proGetAdoptInfo", adoptPetParams))
                {
                    while (reader.Read())
                    {
                        CVAdoptPet adoptPet = new CVAdoptPet();
                        adoptPet.AdoptID = reader["AdoptID"].ToString();
                        adoptPet.City = reader["City"].ToString();
                        adoptPet.Province = reader["Province"].ToString();
                        adoptPet.AdoptInfo = reader["AdoptInfo"].ToString();
                        adoptPet.AdoptTitle = reader["AdoptTitle"].ToString();
                        adoptPet.PetCategoryName = reader["PetCategoryName"].ToString();
                        adoptPet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                        adoptPet.UserName = reader["UserName"].ToString();
                        adoptPet.PicLocation = reader["PicLocation"].ToString();
                        adoptPet.Portrait = reader["Portrait"].ToString();
                        adoptPet.LinkUrl = reader["LinkUrl"].ToString();
                        adoptPet.UserWeiBo = reader["UserWeiBo"].ToString();
                        adoptPet.Status = reader["Status"].ToString();
                        bool tempIsAdopt = true;
                        adoptPet.IsAdopt = bool.TryParse(reader["IsAdopt"].ToString(), out tempIsAdopt) ? tempIsAdopt : true;
                        bool tempIsRecommand = true;
                        adoptPet.IsRecommand = bool.TryParse(reader["IsRecommand"].ToString(), out tempIsRecommand) ? tempIsRecommand : true;
                        bool tempIsEssence = true;
                        adoptPet.IsEssence = bool.TryParse(reader["IsEssence"].ToString(), out tempIsEssence) ? tempIsEssence : true;

                        DateTime tempLastEditTime = DateTime.Now;
                        tempLastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(), out tempLastEditTime) ? tempLastEditTime : DateTime.Now;
                        adoptPet.LastEditTime = tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");

                        DateTime tempAdoptTime = DateTime.Now;
                        tempAdoptTime = DateTime.TryParse(reader["AdoptTime"].ToString(), out tempAdoptTime) ? tempAdoptTime : DateTime.Now;
                        adoptPet.AdoptTime = tempAdoptTime.ToString("yyyy/MM/dd hh:mm:ss");

                        adoptPet.IP = reader["IP"].ToString();
                        int tempFocusNum = 0;
                        adoptPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                        int tempCommentCount = 0;
                        adoptPet.CommentCount = int.TryParse(reader["CommentCount"].ToString(), out tempCommentCount) ? tempCommentCount : 0;
                        AdoptPetList.Add(adoptPet);
                    }
                    reader.Close();
                    reader.Dispose();
                    int tempHowmanyPages = 0;
                    howmanyPages = int.TryParse(adoptPetParams[4].Value.ToString(), out tempHowmanyPages) ? tempHowmanyPages : 0;
                }
            }
            catch(Exception ex)
            {
                throw;
            }
            
            
 
          
            return AdoptPetList;
        }


        //获取一篇文章的所有的信息，返回信息列表（包含文章的所有内容，对应用户，所有评论），分页的方式
        public List<CVAdoptPetComment> GetAllAdoptCommentListPerPage(string adoptID, int pageNumber, int NumberPerPage, out int howmanyPages)
        {
            List<CVAdoptPetComment> commendList = new List<CVAdoptPetComment>();
            SqlParameter[] adoptPetCommentParams = null;
            adoptPetCommentParams = new SqlParameter[]
                            {
                                new SqlParameter("@AdoptID",SqlDbType.NVarChar,32),
                                new SqlParameter("@DescriptionLength",SqlDbType.Int),
                                new SqlParameter("@PageNumber",SqlDbType.Int),
                                new SqlParameter("@InfoPerPage",SqlDbType.Int),
                                new SqlParameter("@HowManyInfo",SqlDbType.Int,65535,ParameterDirection.Output,true,0,0,"",DataRowVersion.Default,0),
                            };
            adoptPetCommentParams[0].Value = adoptID;
            adoptPetCommentParams[1].Value = CPetCareConfiguration.AriticleAllNum;
            adoptPetCommentParams[2].Value = pageNumber;
            adoptPetCommentParams[3].Value = NumberPerPage;
            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "proGetAdoptCommentInfo", adoptPetCommentParams))
                {
                    while (reader.Read())
                    {
                        CVAdoptPetComment adoptPet = new CVAdoptPetComment();
                        adoptPet.AdoptID = reader["AdoptID"].ToString();
                        adoptPet.City = reader["City"].ToString();
                        adoptPet.Province = reader["Province"].ToString();
                        adoptPet.AdoptInfo = reader["AdoptInfo"].ToString();
                        adoptPet.AdoptTitle = reader["AdoptTitle"].ToString();
                        adoptPet.PetCategoryName = reader["PetCategoryName"].ToString();
                        adoptPet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                        adoptPet.UserName = reader["UserName"].ToString();
                        adoptPet.PicLocation = reader["PicLocation"].ToString();
                        adoptPet.Portrait = reader["Portrait"].ToString();
                        adoptPet.LinkUrl = reader["LinkUrl"].ToString();
                        adoptPet.UserWeiBo = reader["UserWeiBo"].ToString();
                        adoptPet.Status = reader["Status"].ToString();
                        bool tempIsAdopt = true;
                        adoptPet.IsAdopt = bool.TryParse(reader["IsAdopt"].ToString(), out tempIsAdopt) ? tempIsAdopt : true;
                        bool tempIsRecommand = true;
                        adoptPet.IsRecommand = bool.TryParse(reader["IsRecommand"].ToString(), out tempIsRecommand) ? tempIsRecommand : true;
                        bool tempIsEssence = true;
                        adoptPet.IsEssence = bool.TryParse(reader["IsEssence"].ToString(), out tempIsEssence) ? tempIsEssence : true;

                        DateTime tempLastEditTime = DateTime.Now;
                        tempLastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(), out tempLastEditTime) ? tempLastEditTime : DateTime.Now;
                        adoptPet.LastEditTime =tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");

                         DateTime tempAdoptTime = DateTime.Now;
                         tempAdoptTime = DateTime.TryParse(reader["AdoptTime"].ToString(), out tempAdoptTime) ? tempAdoptTime : DateTime.Now;
                         adoptPet.AdoptTime = tempAdoptTime.ToString("yyyy/MM/dd hh:mm:ss");

                        adoptPet.IP = reader["IP"].ToString();
                        int tempFocusNum = 0;
                        adoptPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;

                        adoptPet.CommentIP = reader["CommentIP"].ToString();
                        adoptPet.CommentContent = reader["CommentContent"].ToString();
                        adoptPet.CommentUserName = reader["CommentUserName"].ToString();
                        adoptPet.CommentUserLevel = reader["CommentUserLevel"].ToString();
                        adoptPet.CommentID = reader["CommentID"].ToString();

                        commendList.Add(adoptPet);
                    }
                    reader.Close();
                    reader.Dispose();
                    int tempHowmanyPages = 0;
                    howmanyPages = int.TryParse(adoptPetCommentParams[4].Value.ToString(),out tempHowmanyPages) ? tempHowmanyPages : 0;

                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return commendList;
        }


        //根据userID获取其发布petlist
        public  List<CTAdoptPet> GetAdoptPetListByUser(string UserID) 
        {
            List<CTAdoptPet> AdoptPetList = new List<CTAdoptPet>();
            SqlParameter parm = new SqlParameter(PARM_USER_ID, SqlDbType.NVarChar);
            parm.Value = UserID;
            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_ADOPTPET_BY_USERID, parm))
                {
                    while (reader.Read())
                    {
                        CTAdoptPet adoptPet = new CTAdoptPet();
                        adoptPet.AdoptID = reader["AdoptID"].ToString();
                        adoptPet.UserID = reader["UserID"].ToString();
                        adoptPet.AddressID = reader["AddressID"].ToString();
                        adoptPet.AdoptInfo = reader["AdoptInfo"].ToString();
                        adoptPet.AdoptTitle = reader["AdoptTitle"].ToString();
                        adoptPet.PetCategoryID = reader["PetCategoryID"].ToString();
                        adoptPet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                        adoptPet.WeiBoID = reader["WeiBoID"].ToString();

                        DateTime tempLastEditTime = DateTime.Now;
                        tempLastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(), out tempLastEditTime) ? tempLastEditTime : DateTime.Now;
                        adoptPet.LastEditTime = tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");

                        DateTime tempKnowledgeTime = DateTime.Now;
                        tempKnowledgeTime = DateTime.TryParse(reader["AdoptTime"].ToString(), out tempKnowledgeTime) ? tempKnowledgeTime : DateTime.Now;
                        adoptPet.AdoptTime = tempKnowledgeTime.ToString("yyyy/MM/dd hh:mm:ss");

                        adoptPet.IsVisible = bool.Parse(reader["IsVisible"].ToString());
                        adoptPet.IP = reader["IP"].ToString();
                        adoptPet.IsAdopt = bool.Parse(reader["IsAdopt"].ToString());
                        int tempFocusNum = 0;
                        adoptPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                        AdoptPetList.Add(adoptPet);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return AdoptPetList;
        }

        //根据地区种类得到领养宠物的信息
        public List<CVAdoptPet> GetAdoptPetListByAddressCategory(bool IsAdopt,string AddressID, string PetCategoryID, int pageNumber, int NumberPerPage, out int howmanyPages)
        {
            List<CVAdoptPet> AdoptPetList = new List<CVAdoptPet>();
            SqlParameter[] adoptPetParams = null;
            adoptPetParams = new SqlParameter[]
                            {
                                new SqlParameter("@IsAdopt",SqlDbType.Bit),
                                new SqlParameter("@AddressID",SqlDbType.NVarChar,20),
                                new SqlParameter("@PetCategoryID",SqlDbType.NVarChar,36),
                                new SqlParameter("@DescriptionLength",SqlDbType.Int),
                                new SqlParameter("@PageNumber",SqlDbType.Int),
                                new SqlParameter("@AdoptInfoPerPage",SqlDbType.Int),
                                new SqlParameter("@HowManyAdoptInfo",SqlDbType.Int,65535,ParameterDirection.Output,true,0,0,"",DataRowVersion.Default,0),
                            };
            adoptPetParams[0].Value = IsAdopt;
            adoptPetParams[1].Value = AddressID;
            adoptPetParams[2].Value = PetCategoryID;
            adoptPetParams[3].Value = CPetCareConfiguration.ArticleBreviaryNum;
            adoptPetParams[4].Value = pageNumber;
            adoptPetParams[5].Value = NumberPerPage;

            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "proSearchAllAdoptInfo", adoptPetParams))
                {
                    while (reader.Read())
                    {
                        CVAdoptPet adoptPet = new CVAdoptPet();
                        adoptPet.AdoptID = reader["AdoptID"].ToString();
                        adoptPet.City = reader["City"].ToString();
                        adoptPet.Province = reader["Province"].ToString();
                        adoptPet.AdoptInfo = reader["AdoptInfo"].ToString();
                        adoptPet.AdoptTitle = reader["AdoptTitle"].ToString();
                        adoptPet.PetCategoryName = reader["PetCategoryName"].ToString();
                        adoptPet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                        adoptPet.UserName = reader["UserName"].ToString();
                        adoptPet.PicLocation = reader["PicLocation"].ToString();
                        adoptPet.Portrait = reader["Portrait"].ToString();
                        adoptPet.LinkUrl = reader["LinkUrl"].ToString();
                        adoptPet.UserWeiBo = reader["UserWeiBo"].ToString();
                        adoptPet.Status = reader["Status"].ToString();
                        bool tempIsAdopt = true;
                        adoptPet.IsAdopt = bool.TryParse(reader["IsAdopt"].ToString(), out tempIsAdopt) ? tempIsAdopt : true;
                        bool tempIsRecommand = true;
                        adoptPet.IsRecommand = bool.TryParse(reader["IsRecommand"].ToString(), out tempIsRecommand) ? tempIsRecommand : true;
                        bool tempIsEssence = true;
                        adoptPet.IsEssence = bool.TryParse(reader["IsEssence"].ToString(), out tempIsEssence) ? tempIsEssence : true;

                        DateTime tempLastEditTime = DateTime.Now;
                        tempLastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(), out tempLastEditTime) ? tempLastEditTime : DateTime.Now;
                        adoptPet.LastEditTime = tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");

                        DateTime tempAdoptTime = DateTime.Now;
                        tempAdoptTime = DateTime.TryParse(reader["AdoptTime"].ToString(), out tempAdoptTime) ? tempAdoptTime : DateTime.Now;
                        adoptPet.AdoptTime = tempAdoptTime.ToString("yyyy/MM/dd hh:mm:ss");


                        adoptPet.IP = reader["IP"].ToString();
                        int tempFocusNum = 0;
                        adoptPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                        int tempCommentCount = 0;
                        adoptPet.CommentCount = int.TryParse(reader["CommentCount"].ToString(), out tempCommentCount) ? tempCommentCount : 0;

                        AdoptPetList.Add(adoptPet);
                    }
                }
            }
            catch (Exception ex)
            {

            }
            howmanyPages = 1;
            return AdoptPetList;
        }


        //添加新记录
        public int InsertAdoptPet(CTAdoptPet AdoptPetInfo)
        {
            int insertStatus = 0;
            //得到所有的参数数组
            SqlParameter[] adoptPetParams = null;
            adoptPetParams = new SqlParameter[]
                            {
                                new SqlParameter("@AdoptID",SqlDbType.NVarChar,32),
                                new SqlParameter("@UserID",SqlDbType.NVarChar,20),
                                new SqlParameter("@AddressID",SqlDbType.NVarChar,20),
                                new SqlParameter("@PetCategoryID",SqlDbType.NVarChar,20),
                                new SqlParameter("@WeiBoID",SqlDbType.NVarChar,20),
                                new SqlParameter("@AdoptTitle",SqlDbType.NVarChar,20),
                                new SqlParameter("@AdoptTime",SqlDbType.DateTime ),
                                new SqlParameter("@LastEditTime",SqlDbType.DateTime ),
                                new SqlParameter("@AdoptInfo",SqlDbType.NVarChar),
                                new SqlParameter("@IP",SqlDbType.NVarChar,20),
                                new SqlParameter("@PriorityScore",SqlDbType.Int),
                                new SqlParameter("@FocusNum",SqlDbType.Int),
                                new SqlParameter("@IsVisible",SqlDbType.Bit),
                                new SqlParameter("@IsAdopt",SqlDbType.Bit),
                            };
            adoptPetParams[0].Value = AdoptPetInfo.AdoptID;
            adoptPetParams[1].Value = AdoptPetInfo.UserID;
            adoptPetParams[2].Value = AdoptPetInfo.AddressID;
            adoptPetParams[3].Value = AdoptPetInfo.PetCategoryID;
            adoptPetParams[4].Value = AdoptPetInfo.WeiBoID;
            adoptPetParams[5].Value = AdoptPetInfo.AdoptTitle;
            adoptPetParams[6].Value = Convert.ToDateTime(AdoptPetInfo.AdoptTime);
            adoptPetParams[7].Value = Convert.ToDateTime(AdoptPetInfo.LastEditTime);
            adoptPetParams[8].Value = AdoptPetInfo.AdoptInfo;
            adoptPetParams[9].Value = AdoptPetInfo.IP;
            adoptPetParams[10].Value = AdoptPetInfo.PriorityScore;
            adoptPetParams[11].Value = AdoptPetInfo.FocusNum;
            adoptPetParams[12].Value = AdoptPetInfo.IsVisible;
            adoptPetParams[13].Value = AdoptPetInfo.IsAdopt;

            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
                {
                    insertStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_ADOPTPET, adoptPetParams);
                }
            }
            catch (Exception ex)
            {

            }

            return insertStatus;

        }

        //删除记录
        public int DeleteAdoptPet(string AdoptPetID)
        {
            int deleteStatus = 0;
            SqlParameter parm = new SqlParameter(PARM_ADOPT_ID, SqlDbType.NVarChar);
            parm.Value = AdoptPetID;
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
                {
                    deleteStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_ADOPTPET, parm);
                }
            }
            catch (Exception ex)
            {

            }
            return deleteStatus;
        }

        //更新记录
        public int UpdateAdoptPet(CTAdoptPet AdoptPetInfo)
        {
            int updateStatus = 0;

            //得到所有的参数数组
            SqlParameter[] adoptPetParams = null;
            adoptPetParams = new SqlParameter[]
                            {
                                new SqlParameter("@AdoptID",SqlDbType.NVarChar,32),
                                new SqlParameter("@AddressID",SqlDbType.NVarChar,20),
                                new SqlParameter("@PetCategoryID",SqlDbType.NVarChar,20),
                                new SqlParameter("@AdoptTitle",SqlDbType.NVarChar,20),
                                new SqlParameter("@LastEditTime",SqlDbType.DateTime ),
                                new SqlParameter("@AdoptInfo",SqlDbType.NVarChar),
                                new SqlParameter("@IP",SqlDbType.NVarChar,20),
                            };
            adoptPetParams[0].Value = AdoptPetInfo.AdoptID;
            adoptPetParams[1].Value = AdoptPetInfo.AddressID;
            adoptPetParams[2].Value = AdoptPetInfo.PetCategoryID;
            adoptPetParams[3].Value = AdoptPetInfo.AdoptTitle;
            adoptPetParams[4].Value = Convert.ToDateTime(AdoptPetInfo.LastEditTime);
            adoptPetParams[5].Value = AdoptPetInfo.AdoptInfo;
            adoptPetParams[6].Value = AdoptPetInfo.IP;


            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
                {
                    updateStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UPDATE_ADOPTPET, adoptPetParams);
                }
            }
            catch (Exception ex)
            {

            }
            return updateStatus;
        }
            
    }
}
