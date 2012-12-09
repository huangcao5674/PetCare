using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;
using System.Data;
using System.Data.SqlClient;
using PetCare.DBUtility;

namespace PetCare.SQLServerDAL
{
    public class AdoptPetComment:IAdoptPetComment
    {

        private const string SQL_INSERT_AdoptComment = @"INSERT INTO [PETCAREDB].[dbo].[DB_AdoptPetComment]([CommentID] ,[UserID],[AdoptID],[CommentTime],[IP],[CommentContent],[IsVisible]) VALUES"
                            + "(@CommentID  ,@UserID ,@AdoptID ,@CommentTime ,@IP ,@CommentContent ,@IsVisible)";

       public  List<CTAdoptPetComment> GetAdoptPetCommentListByID(int UserID)
        {
            List<CTAdoptPetComment> list = new List<CTAdoptPetComment>();
            return list;
        }

       public int InsertAdoptPetComment(CTAdoptPetComment adoptComment)
       {
           int insertStatus = 0;
           SqlParameter[] parms = null;
           parms = new SqlParameter[]
                            {
                                new SqlParameter("@CommentID",SqlDbType.NVarChar,20),
                                new SqlParameter("@UserID",SqlDbType.NVarChar,20),
                                new SqlParameter("@AdoptID",SqlDbType.NVarChar,20),
                                new SqlParameter("@CommentTime",SqlDbType.DateTime ),
                                new SqlParameter("@IP",SqlDbType.NVarChar,20),
                                new SqlParameter("@CommentContent",SqlDbType.NVarChar,100),
                                new SqlParameter("@IsVisible",SqlDbType.Bit),
                            };

           parms[0].Value = adoptComment.CommentID;
           parms[1].Value = adoptComment.UserID;
           parms[2].Value = adoptComment.AdoptID;
           parms[3].Value = adoptComment.CommentTime;
           parms[4].Value = adoptComment.IP;
           parms[5].Value = adoptComment.CommentContent;
           parms[6].Value = adoptComment.IsVisible;

           using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
           {
               insertStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_AdoptComment, parms);
           }
           return insertStatus;
       }
       
    }
}
