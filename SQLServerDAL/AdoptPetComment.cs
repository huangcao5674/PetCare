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
        private const string SQL_DELETE_AdoptComment = @"DELETE FROM [PETCAREDB].[dbo].[DB_AdoptPetComment] WHERE [CommentID]=@CommentID";

        private const string SQL_EDIT_AdoptComment = @"UPDATE [PETCAREDB].[dbo].[DB_AdoptPetComment] SET [CommentContent]=@CommentContent,[IsVisible]=@IsVisible WHERE [CommentID]=@CommentID";

        private const string SQL_SELECT_ADOPTComment = @"Select [CommentID] ,[UserID],[AdoptID],[CommentTime],[IP],[CommentContent],[IsVisible] FROM [PETCAREDB].[dbo].[DB_AdoptPetComment] WHERE CommentID=@CommentID ";

        private string PARAM_COMMENTID = "@CommentID";

        public  List<CTAdoptPetComment> GetAdoptPetCommentListByID(int UserID)
        {
            List<CTAdoptPetComment> list = new List<CTAdoptPetComment>();
            return list;
        }


        //插入评论信息
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

        //删除评论信息
       public int DeleteAdoptPetComment(string commendID)
       {
           int deleteStatus = 0;

           SqlParameter parms = new SqlParameter();
           parms.Value = commendID;
           parms.ParameterName = PARAM_COMMENTID;

           using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
           {
               deleteStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_AdoptComment, parms);
           }
           return deleteStatus;
       }

        //编辑评论信息
       public int EditAdoptPetComment(CTAdoptPetComment adoptComment)
       {
           int editStatus = 0;

           SqlParameter[] parms = null;
           parms = new SqlParameter[]
                            {
                                new SqlParameter("@CommentID",SqlDbType.NVarChar,20),
                                new SqlParameter("@CommentContent",SqlDbType.NVarChar,100),
                                new SqlParameter("@IsVisible",SqlDbType.Bit),
                            };

           parms[0].Value = adoptComment.CommentID;
           parms[1].Value = adoptComment.CommentContent;
           parms[2].Value = adoptComment.IsVisible;

           using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
           {
               editStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_EDIT_AdoptComment, parms);
           }

           return editStatus;
       }


        //根据CommentID获取相应的comment信息
       public CTAdoptPetComment GetAdoptPetCommentByCommentID(string commentID)
       {
           CTAdoptPetComment adoptPetCommnet = new CTAdoptPetComment();

           SqlParameter parm = new SqlParameter();
           parm.Value = commentID;
           parm.ParameterName = PARAM_COMMENTID;

           //execute the query
           using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_ADOPTComment, parm))
           {
               while (rdr.Read())
               {

                   adoptPetCommnet.CommentID = rdr["CommentID"].ToString();
                   adoptPetCommnet.AdoptID = rdr["AdoptID"].ToString();
                   adoptPetCommnet.CommentContent = rdr["CommentContent"].ToString();
                   adoptPetCommnet.CommentTime = rdr["CommentTime"].ToString();
                   adoptPetCommnet.IP = rdr["IP"].ToString();
                   adoptPetCommnet.UserID = rdr["UserID"].ToString();
                   adoptPetCommnet.IsVisible = bool.Parse(rdr["IsVisible"].ToString());
                   break;
                   
               }
               rdr.Close();
               rdr.Dispose();
           }

           return adoptPetCommnet;
       }
    }
}
