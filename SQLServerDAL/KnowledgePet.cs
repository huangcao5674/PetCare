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

        private const string SQL_DELETE_KNOWLEDGEPET = "INSERT INTO [PETCAREDB].[dbo].[DB_AdoptPet]([UserID],[AddressID],[PetCategoryID]"
          +",[WeiBoID],[AdoptTitle],[AdoptTime],[LastEditTime],[AdoptInfo],[IP],[PriorityScore],[FocusNum],[IsVisible])VALUES"
          +"(@UserID ,@AddressID ,@PetCategoryID ,@WeiBoID ,@AdoptTitle ,@AdoptTime ,@LastEditTime ,@AdoptInfo ,@IP ,@PriorityScore ,@FocusNum ,@IsVisible)";

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
                   knowledgepet.PetCaretegoryID = reader["PetCategoryID"].ToString();
                   knowledgepet.PriorityScore = int.Parse(reader["PriorityScore"].ToString());
                   knowledgepet.WeiBoID = reader["WeiBoID"].ToString();

                   DateTime tempLastEditTime=DateTime.Now;
                  // knowledgepet.LastEditTime = DateTime.TryParse(reader["LastEditTime"].ToString(),out tempLastEditTime)?tempLastEditTime:DateTime.Now;
                   DateTime tempKnowledgeTime=DateTime.Now;
                  // knowledgepet.KnowledgeTime = DateTime.TryParse(reader["KnowledgeTime"].ToString(),out tempKnowledgeTime)?tempKnowledgeTime:DateTime.Now;
                   knowledgepet.IsVisible = bool.Parse(reader["IsVisible"].ToString());
                   knowledgepet.IP = reader["IP"].ToString();
                   int tempFocusNum = 0;
                   knowledgepet.FocusNum = int.TryParse(reader["FocusNum"].ToString(),out tempFocusNum)?tempFocusNum:0;
                   KnowledgePetList.Add(knowledgepet);
               }
           }
           return KnowledgePetList;
       }

        public List<CTKnowledgePet> GetKnowledgePetListByUser(int UserID)
        {
            List<CTKnowledgePet> KnowledgePetList = new List<CTKnowledgePet>();
            return KnowledgePetList;
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
                                new SqlParameter("@KnowledgeTime",SqlDbType.DateTime),
                                new SqlParameter("@KnowledgeTitle",SqlDbType.NVarChar,50),
                                new SqlParameter("@PetCategoryID",SqlDbType.NVarChar,20),
                                new SqlParameter("@PriorityScore",SqlDbType.Int),
                                new SqlParameter("@UserID",SqlDbType.NVarChar,20),
                                new SqlParameter("@WeiBoID",SqlDbType.NVarChar,20),
                                new SqlParameter("@FocusNum",SqlDbType.Int),
                                new SqlParameter("@ComplaintNum",SqlDbType.Int),
                                new SqlParameter("@IP",SqlDbType.NVarChar,20),
                                new SqlParameter("@LastEditTime",SqlDbType.DateTime),
                                new SqlParameter("@IsVisible",SqlDbType.Bit),
                            };

            knowledgeParams[0].Value = KnowledgePetInfo.AddressID;
            knowledgeParams[1].Value = KnowledgePetInfo.KnowledgeID;
            knowledgeParams[2].Value = KnowledgePetInfo.KnowledgeInfo;
            knowledgeParams[3].Value = KnowledgePetInfo.KnowledgeTime;
            knowledgeParams[4].Value = KnowledgePetInfo.KnowledgeTitle;
            knowledgeParams[5].Value = KnowledgePetInfo.PetCaretegoryID;
            knowledgeParams[6].Value = KnowledgePetInfo.PriorityScore;
            knowledgeParams[7].Value = KnowledgePetInfo.UserID;
            knowledgeParams[8].Value = KnowledgePetInfo.WeiBoID;
            knowledgeParams[9].Value = KnowledgePetInfo.FocusNum;
            knowledgeParams[10].Value = KnowledgePetInfo.ComplaintNum;
            knowledgeParams[11].Value = KnowledgePetInfo.IP;
            knowledgeParams[12].Value = KnowledgePetInfo.LastEditTime;
            knowledgeParams[13].Value = KnowledgePetInfo.IsVisible;
 

            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
            {
                insertStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_KNOWLEDGEPET, knowledgeParams);
            }

            return insertStatus;

            
        }
    }
}
