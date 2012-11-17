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
        private const string SQL_SELECT_KNOWLEDGEPET_BY_USERID = "";

        private const string SQL_SELECT_KNOWLEDGEPET = "SELECT KnowledgeID,UserID,AddressID,PetCategoryID,WeiBoID,KnowledgeTitle,KnowledgeTime,KnowledgeInfo,PriorityScore,IP,FocusNum,IsVisible from [PETCAREDB].[dbo].[DB_KnowledgePet]";

        private const string SQL_INSERT_KNOWLEDGEPET = "";

        private const string SQL_DELETE_KNOWLEDGEPET = "";

        private const string PARM_USER_ID = "@UserId";

       public List<CTKnowledgePet> GetAllKnowledgePetList()
       {
           List<CTKnowledgePet> KnowledgePetList = new List<CTKnowledgePet>();
           using(SqlDataReader reader=SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_KNOWLEDGEPET, null))
           {
               while(reader.Read())
               {
                   CTKnowledgePet ONE=new CTKnowledgePet();
                   ONE.KnowledgeID=reader["KnowledgeID"].ToString();
                   ONE.UserID=int.Parse(reader["UserID"].ToString());
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
            int isTrue = 0;
            StringBuilder strSQL = new StringBuilder();

            //得到所有的参数数组
            SqlParameter[] knowledgeParams = GetKnowledgePetParameters();

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
            foreach (SqlParameter parm in knowledgeParams)
            {
                cmd.Parameters.Add(parm);
            }

            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
            {
                strSQL.Append(SQL_INSERT_KNOWLEDGEPET);
                SqlParameter[] itemParms;
                int i = 0;
                
            }
            return isTrue;

            
        }

        private static SqlParameter[] GetKnowledgePetParameters()
        {
            SqlParameter[]parms=SqlHelper.GetCachedParameters(SQL_INSERT_KNOWLEDGEPET);
            if (parms == null)
            {
            }
            return parms;
        }
    }
}
