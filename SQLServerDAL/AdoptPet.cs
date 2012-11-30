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
            + ",[AdoptInfo],[IP],[PriorityScore],[FocusNum],[IsVisible] FROM [PETCAREDB].[dbo].[DB_AdoptPet]";

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

        private const string SQL_UPDATE_ADOPTPET = "UPDATE [PETCAREDB].[dbo].[DB_AdoptPet] SET [AdoptTitle]=@AdoptTitle,";

        private const string PARM_USER_ID = "@UserId";

        private const string PARM_ADOPT_ID = "@AdoptID";

        private const string PARM_ADDRESS_ID = "@AddressID";

        private const string PARM_PETCATEGORU_ID = "@PetCategoryID";

        //获取所有的petlist
        public List<CTAdoptPet> GetAllAdoptPetList()
        {
            List<CTAdoptPet> AdoptPetList = new List<CTAdoptPet>();
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

                    DateTime tempLastEditTime = DateTime.Now;
                    // knowledgepet.LastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(),out tempLastEditTime)?tempLastEditTime:DateTime.Now;
                    DateTime tempKnowledgeTime = DateTime.Now;
                    // knowledgepet.KnowledgeTime = DateTime.TryParse(reader["KnowledgeTime"].ToString(),out tempKnowledgeTime)?tempKnowledgeTime:DateTime.Now;
                    adoptPet.IsVisible = bool.Parse(reader["IsVisible"].ToString());
                    adoptPet.IP = reader["IP"].ToString();
                    int tempFocusNum = 0;
                    adoptPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                    AdoptPetList.Add(adoptPet);
                }
            }

            return AdoptPetList;
        }

        //根据userID获取其发布petlist
        public  List<CTAdoptPet> GetAdoptPetListByUser(string UserID) 
        {
            List<CTAdoptPet> AdoptPetList = new List<CTAdoptPet>();
            SqlParameter parm = new SqlParameter(PARM_USER_ID, SqlDbType.NVarChar);
            parm.Value = UserID;
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
                    // knowledgepet.LastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(),out tempLastEditTime)?tempLastEditTime:DateTime.Now;
                    DateTime tempKnowledgeTime = DateTime.Now;
                    // knowledgepet.KnowledgeTime = DateTime.TryParse(reader["KnowledgeTime"].ToString(),out tempKnowledgeTime)?tempKnowledgeTime:DateTime.Now;
                    adoptPet.IsVisible = bool.Parse(reader["IsVisible"].ToString());
                    adoptPet.IP = reader["IP"].ToString();
                    int tempFocusNum = 0;
                    adoptPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                    AdoptPetList.Add(adoptPet);
                }
            }
            return AdoptPetList;
        }

        //根据地区得到领养宠物的信息
        public List<CTAdoptPet> GetAdoptPetListByAddress(string AddressID)
        {
            List<CTAdoptPet> AdoptPetList = new List<CTAdoptPet>();
            SqlParameter parm = new SqlParameter(PARM_ADDRESS_ID, SqlDbType.NVarChar);
            parm.Value = AddressID;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_ADOPTPET_BY_ADDRESS, parm))
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
                    // knowledgepet.LastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(),out tempLastEditTime)?tempLastEditTime:DateTime.Now;
                    DateTime tempKnowledgeTime = DateTime.Now;
                    // knowledgepet.KnowledgeTime = DateTime.TryParse(reader["KnowledgeTime"].ToString(),out tempKnowledgeTime)?tempKnowledgeTime:DateTime.Now;
                    adoptPet.IsVisible = bool.Parse(reader["IsVisible"].ToString());
                    adoptPet.IP = reader["IP"].ToString();
                    int tempFocusNum = 0;
                    adoptPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                    AdoptPetList.Add(adoptPet);
                }
            }
            return AdoptPetList;
        }

        //根据宠物类型得到领养宠物的信息
        public List<CTAdoptPet> GetAdoptPetListByPetCategory(string PetCategoryID)
        {
            List<CTAdoptPet> AdoptPetList = new List<CTAdoptPet>();
            SqlParameter parm = new SqlParameter(PARM_PETCATEGORU_ID, SqlDbType.NVarChar);
            parm.Value = PetCategoryID;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_ADOPTPET_BY_PETCATEGORY, parm))
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
                    // knowledgepet.LastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(),out tempLastEditTime)?tempLastEditTime:DateTime.Now;
                    DateTime tempKnowledgeTime = DateTime.Now;
                    // knowledgepet.KnowledgeTime = DateTime.TryParse(reader["KnowledgeTime"].ToString(),out tempKnowledgeTime)?tempKnowledgeTime:DateTime.Now;
                    adoptPet.IsVisible = bool.Parse(reader["IsVisible"].ToString());
                    adoptPet.IP = reader["IP"].ToString();
                    int tempFocusNum = 0;
                    adoptPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                    AdoptPetList.Add(adoptPet);
                }
            }
            return AdoptPetList;
        }


        public List<CTAdoptPet> GetAdoptPetListByPetCategoryAddress(string PetCategoryID, string AddressID)
        {
            List<CTAdoptPet> AdoptPetList = new List<CTAdoptPet>();
            SqlParameter parm = new SqlParameter(PARM_PETCATEGORU_ID, SqlDbType.NVarChar);
            parm.Value = PetCategoryID;
            using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_ADOPTPET_BY_PETCATEGORY, parm))
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
                    // knowledgepet.LastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(),out tempLastEditTime)?tempLastEditTime:DateTime.Now;
                    DateTime tempKnowledgeTime = DateTime.Now;
                    // knowledgepet.KnowledgeTime = DateTime.TryParse(reader["KnowledgeTime"].ToString(),out tempKnowledgeTime)?tempKnowledgeTime:DateTime.Now;
                    adoptPet.IsVisible = bool.Parse(reader["IsVisible"].ToString());
                    adoptPet.IP = reader["IP"].ToString();
                    int tempFocusNum = 0;
                    adoptPet.FocusNum = int.TryParse(reader["FocusNum"].ToString(), out tempFocusNum) ? tempFocusNum : 0;
                    AdoptPetList.Add(adoptPet);
                }
            }
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
                                new SqlParameter("@AdoptID",SqlDbType.NVarChar,20),
                                new SqlParameter("@UserID",SqlDbType.NVarChar,20),
                                new SqlParameter("@AddressID",SqlDbType.NVarChar,20),
                                new SqlParameter("@PetCategoryID",SqlDbType.NVarChar,20),
                                new SqlParameter("@WeiBoID",SqlDbType.NVarChar,20),
                                new SqlParameter("@AdoptTitle",SqlDbType.NVarChar,20),
                                new SqlParameter("@AdoptTime",SqlDbType.DateTime),
                                new SqlParameter("@LastEditTime",SqlDbType.DateTime),
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
            adoptPetParams[6].Value = AdoptPetInfo.AdoptTime;
            adoptPetParams[7].Value = AdoptPetInfo.LastEditTime;
            adoptPetParams[8].Value = AdoptPetInfo.AdoptInfo;
            adoptPetParams[9].Value = AdoptPetInfo.IP;
            adoptPetParams[10].Value = AdoptPetInfo.PriorityScore;
            adoptPetParams[11].Value = AdoptPetInfo.FocusNum;
            adoptPetParams[12].Value = AdoptPetInfo.IsVisible;
            adoptPetParams[13].Value = AdoptPetInfo.IsAdopt;


            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
            {
                insertStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_ADOPTPET, adoptPetParams);
            }

            return insertStatus;

        }

        //删除记录
        public int DeleteAdoptPet(string AdoptPetID)
        {
            int deleteStatus = 0;
            SqlParameter parm = new SqlParameter(PARM_ADOPT_ID, SqlDbType.NVarChar);
            parm.Value = AdoptPetID;
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
            {
                deleteStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_ADOPTPET, parm);
            }
            return deleteStatus;
        }

        //更新记录
        public int UpdateAdoptPet(CTAdoptPet AdoptPetInfo)
        {
            int updateStatus = 0;
            return updateStatus;
        }
            
    }
}
