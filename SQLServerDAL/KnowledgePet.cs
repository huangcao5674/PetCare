﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;
using System.Data.SqlClient;
using System.Data;
using PetCare.DBUtility;
using System.Data.Common;

namespace PetCare.SQLServerDAL
{
    public class KnowledgePet:IKnowledgePet
    {

        private const string SQL_SELECT_KNOWLEDGEPET = @"SELECT KnowledgeID,UserID,AddressID,PetCategoryID,WeiBoID,KnowledgeTitle,KnowledgeTime,KnowledgeInfo,PriorityScore,IP,FocusNum,IsVisible from [PETCAREDB].[dbo].[DB_KnowledgePet]";

        private const string SQL_INSERT_KNOWLEDGEPET = @"INSERT INTO [PETCAREDB].[dbo].[DB_KnowledgePet]([KnowledgeID],[UserID],[AddressID],[PetCategoryID] "
            + " ,[WeiBoID],[KnowledgeTitle],[KnowledgeTime],[LastEditTime],[KnowledgeInfo],[PriorityScore],[IP],[FocusNum],[IsVisible])VALUES"
            + "(@KnowledgeID,@UserID,@AddressID,@PetCategoryID,@WeiBoID,@KnowledgeTitle,@KnowledgeTime,@LastEditTime,@KnowledgeInfo,@PriorityScore,@IP,@FocusNum,@IsVisible)";

        private const string SQL_DELETE_KNOWLEDGEPET = "DELETE FROM [PETCAREDB].[dbo].[DB_KnowledgePet] WHERE [KnowledgeID]=@KnowledgeID";

        private const string SQL_EDIT_KNOWLEDGEPET = "UPDATE [PETCAREDB].[dbo].[DB_KnowledgePet] SET [UserID]=@UserID,[AddressID]=@AddressID,[PetCategoryID]=@PetCategoryID "
            + " ,[WeiBoID]=@WeiBoID,[KnowledgeTitle]=@KnowledgeTitle,[KnowledgeTime]=@KnowledgeTime,[LastEditTime]=@LastEditTime,[KnowledgeInfo]=@KnowledgeInfo,[PriorityScore]=@PriorityScore,[IP]=@IP,[FocusNum]=@FocusNum,[IsVisible]=@IsVisible WHERE [KnowledgeID]=@KnowledgeID";

        private const string PARM_KNOWLEDGE_ID = "@KnowledgeID";

        private const string PARM_USER_ID = "@UserId";


        //得到所有的宠物知识信息
        public List<CTKnowledgePet> GetAllKnowledgePetList()
       {
           List<CTKnowledgePet> KnowledgePetList = new List<CTKnowledgePet>();
           using(SqlDataReader reader=SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_KNOWLEDGEPET, null))
           {
               while(reader.Read())
               {
                   CTKnowledgePet knowledgepet=new CTKnowledgePet();
                   knowledgepet.KnowledgeID = reader["KnowledgeID"].ToString();
                   knowledgepet.UserID = reader["UserID"].ToString();
                   knowledgepet.AddressID = reader["AddressID"].ToString();
                   knowledgepet.KnowledgeInfo = reader["KnowledgeInfo"].ToString();
                   knowledgepet.KnowledgeTitle = reader["KnowledgeTitle"].ToString();
                   knowledgepet.PetCategoryID = reader["PetCategoryID"].ToString();
                   knowledgepet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                   knowledgepet.WeiBoID = reader["WeiBoID"].ToString();

                   DateTime tempLastEditTime = DateTime.Now;
                  // knowledgepet.LastEditTime =  string .TryParse(reader["LastEditTime"].ToString(),out tempLastEditTime)?tempLastEditTime: string .Now;
                   DateTime tempKnowledgeTime = DateTime.Now;
                  // knowledgepet.KnowledgeTime =  string .TryParse(reader["KnowledgeTime"].ToString(),out tempKnowledgeTime)?tempKnowledgeTime: string .Now;
                   knowledgepet.IsVisible = bool.Parse(reader["IsVisible"].ToString());
                   knowledgepet.IP = reader["IP"].ToString();
                   int tempFocusNum = 0;
                   knowledgepet.FocusNum = int.TryParse(reader["FocusNum"].ToString(),out tempFocusNum)?tempFocusNum:0;
                   KnowledgePetList.Add(knowledgepet);
               }
           }
           return KnowledgePetList;
       }


        //根据knowledgeID 获取knowledge信息
        public CTKnowledgePet GetKnowledgePetInfoByKnowledgeID(string knowledgeID)
        {
            CTKnowledgePet KnowledgePet = new CTKnowledgePet();
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_KNOWLEDGEPET, null))
            {
                while (reader.Read())
                {
                    CTKnowledgePet knowledgepet = new CTKnowledgePet();
                    knowledgepet.KnowledgeID = reader["KnowledgeID"].ToString();
                    knowledgepet.UserID = reader["UserID"].ToString();
                    knowledgepet.AddressID = reader["AddressID"].ToString();
                    knowledgepet.KnowledgeInfo = reader["KnowledgeInfo"].ToString();
                    knowledgepet.KnowledgeTitle = reader["KnowledgeTitle"].ToString();
                    knowledgepet.PetCategoryID = reader["PetCategoryID"].ToString();
                    knowledgepet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                    knowledgepet.WeiBoID = reader["WeiBoID"].ToString();

                    DateTime tempLastEditTime = DateTime.Now;
                   // knowledgepet.LastEditTime =  reader["LastEditTime"].ToString();
                    DateTime tempKnowledgeTime = DateTime.Now;
                    knowledgepet.KnowledgeTime =  reader["KnowledgeTime"].ToString();
                    knowledgepet.IsVisible = bool.Parse(reader["IsVisible"].ToString());
                    knowledgepet.IP = reader["IP"].ToString();
                    int tempFocusNum = 0;
                    knowledgepet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                    KnowledgePet=knowledgepet;
                }
            }
            return KnowledgePet;

        }


        public List<CTKnowledgePet> GetKnowledgePetListByUser(int UserID)
        {
            List<CTKnowledgePet> KnowledgePetList = new List<CTKnowledgePet>();
            return KnowledgePetList;
        }


        //获取所有的petlist
        public List<CVKnowledgePet> GetAllKnowledgePetPageList(int pageNumber, int NumberPerPage, out int howmanyPages)
        {
            SqlParameter[] adoptPetParams = null;
            adoptPetParams = new SqlParameter[]
                            {
                                new SqlParameter("@DescriptionLength",SqlDbType.Int),
                                new SqlParameter("@PageNumber",SqlDbType.Int),
                                new SqlParameter("@InfoPerPage",SqlDbType.Int),
                                new SqlParameter("@HowManyInfo",SqlDbType.Int,65535,ParameterDirection.Output,true,0,0,"",DataRowVersion.Default,0),
                            };
            adoptPetParams[0].Value = CPetCareConfiguration.ArticleBreviaryNum;
            adoptPetParams[1].Value = pageNumber;
            adoptPetParams[2].Value = NumberPerPage;

            List<CVKnowledgePet> AdoptPetList = new List<CVKnowledgePet>();
            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "proGetKnowledgeInfo", adoptPetParams))
                {
                    while (reader.Read())
                    {
                        CVKnowledgePet knowledgePet = new CVKnowledgePet();
                        knowledgePet.KnowledgeID = reader["KnowledgeID"].ToString();
                        knowledgePet.City = reader["City"].ToString();
                        knowledgePet.Province = reader["Province"].ToString();
                        knowledgePet.KnowledgeInfo = reader["KnowledgeInfo"].ToString();
                        knowledgePet.KnowledgeTitle = reader["KnowledgeTitle"].ToString();
                        knowledgePet.PetCategoryName = reader["PetCategoryName"].ToString();
                        knowledgePet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                        knowledgePet.UserName = reader["UserName"].ToString();
                        knowledgePet.PicLocation = reader["PicLocation"].ToString();
                        knowledgePet.Portrait = reader["Portrait"].ToString();
                        knowledgePet.LinkUrl = reader["LinkUrl"].ToString();
                        knowledgePet.UserWeiBo = reader["UserWeiBo"].ToString();
                        knowledgePet.Status = reader["Status"].ToString();
                        bool tempIsRecommand = true;
                        knowledgePet.IsRecommand = bool.TryParse(reader["IsRecommand"].ToString(), out tempIsRecommand) ? tempIsRecommand : true;
                        bool tempIsEssence = true;
                        knowledgePet.IsEssence = bool.TryParse(reader["IsEssence"].ToString(), out tempIsEssence) ? tempIsEssence : true;

                        DateTime tempLastEditTime = DateTime.Now;
                        tempLastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(), out tempLastEditTime) ? tempLastEditTime : DateTime.Now;
                        knowledgePet.LastEditTime = tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");
                        
                        DateTime tempKnowledgeTime = DateTime.Now;
                        tempKnowledgeTime = DateTime.TryParse(reader["KnowledgeTime"].ToString(), out tempKnowledgeTime) ? tempKnowledgeTime : DateTime.Now;
                        knowledgePet.KnowledgeTime = tempKnowledgeTime.ToString("yyyy/MM/dd hh:mm:ss");

                        knowledgePet.IP = reader["IP"].ToString();
                        int tempFocusNum = 0;
                        knowledgePet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                        int tempCommentCount = 0;
                        knowledgePet.CommentCount = int.TryParse(reader["CommentCount"].ToString(), out tempCommentCount) ? tempCommentCount : 0;

                        AdoptPetList.Add(knowledgePet);
                    }
                    reader.Close();
                    reader.Dispose();
                    int tempHowmanyPages=0;
                    howmanyPages = int.TryParse(adoptPetParams[3].Value.ToString(), out tempHowmanyPages) ? tempHowmanyPages : 0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return AdoptPetList;
        }


        //实现接口的函数
        public int InsertKnowledgePet(CTKnowledgePet KnowledgePetInfo)
        {
            int insertStatus = 0;
            //得到所有的参数数组
            SqlParameter[] knowledgeParams = null;
            knowledgeParams = new SqlParameter[]
                            {
                                new SqlParameter("@AddressID",SqlDbType.NVarChar,20),
                                new SqlParameter("@KnowledgeID",SqlDbType.NVarChar,20),
                                new SqlParameter("@KnowledgeInfo",SqlDbType.NVarChar),
                                new SqlParameter("@KnowledgeTime",SqlDbType.DateTime ),
                                new SqlParameter("@KnowledgeTitle",SqlDbType.NVarChar,50),
                                new SqlParameter("@PetCategoryID",SqlDbType.NVarChar,20),
                                new SqlParameter("@PriorityScore",SqlDbType.Int),
                                new SqlParameter("@UserID",SqlDbType.NVarChar,20),
                                new SqlParameter("@WeiBoID",SqlDbType.NVarChar,20),
                                new SqlParameter("@FocusNum",SqlDbType.Int),
                                new SqlParameter("@ComplaintNum",SqlDbType.Int),
                                new SqlParameter("@IP",SqlDbType.NVarChar,20),
                                new SqlParameter("@LastEditTime",SqlDbType.DateTime ),
                                new SqlParameter("@IsVisible",SqlDbType.Bit),
                            };

            knowledgeParams[0].Value = KnowledgePetInfo.AddressID;
            knowledgeParams[1].Value = KnowledgePetInfo.KnowledgeID;
            knowledgeParams[2].Value = KnowledgePetInfo.KnowledgeInfo;
            knowledgeParams[3].Value = Convert.ToDateTime(KnowledgePetInfo.KnowledgeTime);
            knowledgeParams[4].Value = KnowledgePetInfo.KnowledgeTitle;
            knowledgeParams[5].Value = KnowledgePetInfo.PetCategoryID;
            knowledgeParams[6].Value = KnowledgePetInfo.PriorityScore;
            knowledgeParams[7].Value = KnowledgePetInfo.UserID;
            knowledgeParams[8].Value = KnowledgePetInfo.WeiBoID;
            knowledgeParams[9].Value = KnowledgePetInfo.FocusNum;
            knowledgeParams[10].Value = KnowledgePetInfo.ComplaintNum;
            knowledgeParams[11].Value = KnowledgePetInfo.IP;
            knowledgeParams[12].Value = Convert.ToDateTime(KnowledgePetInfo.LastEditTime);
            knowledgeParams[13].Value = KnowledgePetInfo.IsVisible;
 

            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
            {
                insertStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_KNOWLEDGEPET, knowledgeParams);
            }

            return insertStatus;

            
        }


        //删除函数
        public int DeleteKnowledgePet(string knowledgeID)
        {
            int deleteStatus = 0;

            SqlParameter parm = new SqlParameter();
            parm.Value = knowledgeID;
            parm.ParameterName = PARM_KNOWLEDGE_ID;

            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
            {
                deleteStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_KNOWLEDGEPET, parm);
            }
            return deleteStatus;
        }

        //编辑信息函数
        public int EditKnowledgePet(CTKnowledgePet KnowledgePetInfo)
        {
            int editStatus = 0;

            //得到所有的参数数组
            SqlParameter[] knowledgeParams = null;
            knowledgeParams = new SqlParameter[]
                            {
                                new SqlParameter("@AddressID",SqlDbType.NVarChar,20),
                                new SqlParameter("@KnowledgeID",SqlDbType.NVarChar,20),
                                new SqlParameter("@KnowledgeInfo",SqlDbType.NVarChar),
                                new SqlParameter("@KnowledgeTime",SqlDbType.DateTime ),
                                new SqlParameter("@KnowledgeTitle",SqlDbType.NVarChar,50),
                                new SqlParameter("@PetCategoryID",SqlDbType.NVarChar,20),
                                new SqlParameter("@PriorityScore",SqlDbType.Int),
                                new SqlParameter("@UserID",SqlDbType.NVarChar,20),
                                new SqlParameter("@WeiBoID",SqlDbType.NVarChar,20),
                                new SqlParameter("@FocusNum",SqlDbType.Int),
                                new SqlParameter("@ComplaintNum",SqlDbType.Int),
                                new SqlParameter("@IP",SqlDbType.NVarChar,20),
                                new SqlParameter("@LastEditTime",SqlDbType.DateTime ),
                                new SqlParameter("@IsVisible",SqlDbType.Bit),
                            };

            knowledgeParams[0].Value = KnowledgePetInfo.AddressID;
            knowledgeParams[1].Value = KnowledgePetInfo.KnowledgeID;
            knowledgeParams[2].Value = KnowledgePetInfo.KnowledgeInfo;
            knowledgeParams[3].Value = Convert.ToDateTime(KnowledgePetInfo.KnowledgeTime);
            knowledgeParams[4].Value = KnowledgePetInfo.KnowledgeTitle;
            knowledgeParams[5].Value = KnowledgePetInfo.PetCategoryID;
            knowledgeParams[6].Value = KnowledgePetInfo.PriorityScore;
            knowledgeParams[7].Value = KnowledgePetInfo.UserID;
            knowledgeParams[8].Value = KnowledgePetInfo.WeiBoID;
            knowledgeParams[9].Value = KnowledgePetInfo.FocusNum;
            knowledgeParams[10].Value = KnowledgePetInfo.ComplaintNum;
            knowledgeParams[11].Value = KnowledgePetInfo.IP;
            knowledgeParams[12].Value = Convert.ToDateTime(KnowledgePetInfo.LastEditTime);
            knowledgeParams[13].Value = KnowledgePetInfo.IsVisible;


            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
            {
                editStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_EDIT_KNOWLEDGEPET, knowledgeParams);
            }
            return editStatus;
        }

        //获取一篇文章的所有的信息（包括所有的文章信息，评论，用户信息）
        public List<CVKnowledgePetComment> GetKnowledgePetCommentPageList(string knowledgePetID, int pageNumber, int NumberPerPage, out int howmanyPages)
        {
            List<CVKnowledgePetComment> commentList = new List<CVKnowledgePetComment>();
            howmanyPages = 6;
            SqlParameter[] knowledgePetParams = null;
            knowledgePetParams = new SqlParameter[]
                            {
                                new SqlParameter("@KnowledgeID",SqlDbType.NVarChar,32),
                                new SqlParameter("@DescriptionLength",SqlDbType.Int),
                                new SqlParameter("@PageNumber",SqlDbType.Int),
                                new SqlParameter("@InfoPerPage",SqlDbType.Int),
                                new SqlParameter("@HowManyInfo",SqlDbType.Int,65535,ParameterDirection.Output,true,0,0,"",DataRowVersion.Default,0),
                            };
            knowledgePetParams[0].Value = knowledgePetID;
            knowledgePetParams[1].Value = CPetCareConfiguration.AriticleAllNum;
            knowledgePetParams[2].Value = pageNumber;
            knowledgePetParams[3].Value = NumberPerPage;
            try
            {
                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.StoredProcedure, "proGetKnowledgeCommentInfo", knowledgePetParams))
                {
                    while (reader.Read())
                    {
                        CVKnowledgePetComment knowledgePet = new CVKnowledgePetComment();
                        knowledgePet.KnowledgeID = reader["KnowledgeID"].ToString();
                        knowledgePet.City = reader["City"].ToString();
                        knowledgePet.Province = reader["Province"].ToString();
                        knowledgePet.KnowledgeInfo = reader["KnowledgeInfo"].ToString();
                        knowledgePet.KnowledgeTitle = reader["KnowledgeTitle"].ToString();
                        knowledgePet.PetCategoryName = reader["PetCategoryName"].ToString();
                        knowledgePet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                        knowledgePet.UserName = reader["UserName"].ToString();
                        knowledgePet.PicLocation = reader["PicLocation"].ToString();
                        knowledgePet.Portrait = reader["Portrait"].ToString();
                        knowledgePet.LinkUrl = reader["LinkUrl"].ToString();
                        knowledgePet.UserWeiBo = reader["UserWeiBo"].ToString();
                        knowledgePet.Status = reader["Status"].ToString();
                        bool tempIsRecommand = true;
                        knowledgePet.IsRecommand = bool.TryParse(reader["IsRecommand"].ToString(), out tempIsRecommand) ? tempIsRecommand : true;
                        bool tempIsEssence = true;
                        knowledgePet.IsEssence = bool.TryParse(reader["IsEssence"].ToString(), out tempIsEssence) ? tempIsEssence : true;

                        DateTime tempLastEditTime = DateTime.Now;
                        tempLastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(), out tempLastEditTime) ? tempLastEditTime : DateTime.Now;
                        knowledgePet.LastEditTime = tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");

                        DateTime tempKnowledgeTime = DateTime.Now;
                        tempLastEditTime = DateTime.TryParse(reader["KnowledgeTime"].ToString(), out tempKnowledgeTime) ? tempKnowledgeTime : DateTime.Now;
                        knowledgePet.KnowledgeTime = tempLastEditTime.ToString("yyyy/MM/dd hh:mm:ss");

                        knowledgePet.IP = reader["IP"].ToString();
                        int tempFocusNum = 0;
                        knowledgePet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                        knowledgePet.CommentContent = reader["CommentContent"].ToString();
                        knowledgePet.CommentIP = reader["CommentIP"].ToString();
                        knowledgePet.CommentUserName = reader["CommentUserName"].ToString();
                        knowledgePet.CommentUserProtrait = reader["CommentUserProtrait"].ToString();
                        knowledgePet.CommentUserLevel = reader["CommentUserLevel"].ToString();
                        knowledgePet.CommentID = reader["CommentID"].ToString();
                        commentList.Add(knowledgePet);
                    }
                    reader.Close();
                    reader.Dispose();
                    int tempHowmanyPages = 0;
                    howmanyPages=int.TryParse(knowledgePetParams[4].Value.ToString(),out tempHowmanyPages)?tempHowmanyPages:0;
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return commentList;
        }

    }
}
