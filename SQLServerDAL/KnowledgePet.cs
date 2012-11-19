using System;
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

        private const string SQL_DELETE_KNOWLEDGEPET = "";

        private const string PARM_USER_ID = "@UserId";


        //得到所有的宠物知识信息
        public List<CTKnowledgePet> GetAllKnowledgePetList()
       {
           List<CTKnowledgePet> KnowledgePetList = new List<CTKnowledgePet>();
           using(SqlDataReader reader=SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_KNOWLEDGEPET, null))
           {
               while(reader.Read())
               {
                   CTKnowledgePet ONE=new CTKnowledgePet();
                   ONE.KnowledgeID=reader["KnowledgeID"].ToString();
                   ONE.UserID=reader["UserID"].ToString();
                   ONE.AddressID=reader["AddressID"].ToString();
                   ONE.KnowledgeInfo = reader["KnowledgeInfo"].ToString();
                   KnowledgePetList.Add(ONE);
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

            SqlCommand cmd = new SqlCommand();

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
            foreach (SqlParameter parm in knowledgeParams)
            {
                cmd.Parameters.Add(parm);
            }

            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
            {
                insertStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_KNOWLEDGEPET, knowledgeParams);
            }

            return insertStatus;

            
        }
    }
}
