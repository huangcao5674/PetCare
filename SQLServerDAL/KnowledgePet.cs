using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;
using System.Data.SqlClient;
using System.Data;
using PetCare.DBUtility;

namespace PetCare.SQLServerDAL
{
    public class KnowledgePet:IKnowledgePet
    {
        private const string ConnectionString = @"Server=I264G68GORRHRTN;Initial Catalog=PETCAREDB;User ID=honkcal;Password=huang123;TimeOut=200";

        private const string SQL_SELECT_KNOWLEDGEPET_BY_USERID = "";

        private const string SQL_SELECT_KNOWLEDGEPET="SELECT KnowledgeID,UserID,AddressID,PetCategoryID,WeiBoID,KnowledgeTitle,KnowledgeTime,KnowledgeInfo,PriorityScore,IP,FocusNum,IsVisible from DB_KnowledgePet";

        private const string SQL_INSERT_KNOWLEDGEPET = "";

        private const string SQL_DELETE_KNOWLEDGEPET = "";

        private const string PARM_USER_ID = "@UserId";

       public List<CTKnowledgePet> GetAllKnowledgePetList()
       {
           List<CTKnowledgePet> KnowledgePetList = new List<CTKnowledgePet>();


           //Execute the query against the database
           using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text,SQL_SELECT_KNOWLEDGEPET,null))
           {
               // Scroll through the results
               while (rdr.Read())
               {
                   CTKnowledgePet item = new CTKnowledgePet(rdr.GetString(0), int.Parse(rdr.GetString(1)), rdr.GetValue(2).ToString(), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5), rdr.GetString(6), rdr.GetString(7),rdr.GetString(8),int.Parse(rdr.GetString(9)),bool.Parse(rdr.GetValue(10).ToString()));
                   //Add each item to the arraylist
                   KnowledgePetList.Add(item);
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
        public void InsertKnowledgePet(CTKnowledgePet KnowledgePetInfo)
        {
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
