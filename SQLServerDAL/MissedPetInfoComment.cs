using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using PetCare.Model;
using PetCare.DBUtility;
using PetCare.BLL;

namespace PetCare.SQLServerDAL
{
    public class MissedPetInfoComment:IMissedPetInfoComment
    {


        private const string SQL_SELECT_MissComment_BY_USERID = @"SELECT [CommentID],[UserID],[MissID],[CommentTime],[IP],[CommentContent],[IsVisible] FROM [PETCAREDB].[dbo].[DB_MissedPetComment] where UserID=@UserID";

        private const string SQL_SELECT_MissComment_BY_COMMENTID = @"SELECT [CommentID],[UserID],[MissID],[CommentTime],[IP],[CommentContent],[IsVisible] FROM [PETCAREDB].[dbo].[DB_MissedPetComment] where CommentID=@CommentID";

        private const string SQL_INSERT_MissComment = @"INSERT INTO [PETCAREDB].[dbo].[DB_MissedPetComment]([CommentID] ,[UserID],[MissID],[CommentTime],[IP],[CommentContent],[IsVisible]) VALUES"
            + "(@CommentID  ,@UserID ,@MissID ,@CommentTime ,@IP ,@CommentContent ,@IsVisible)";

        private const string SQL_UPDATE_MissComment = @"Update [PETCAREDB].[dbo].[DB_MissedPetComment] SET [CommentContent]=@CommentContent,[IsVisible]=@IsVisible WHERE CommentID=@CommentID";

        private const string SQL_SELECT_MissComment_BY_MissID = @"SELECT [CommentID],[UserID],[KnowledgeID],[CommentTime],[IP],[CommentContent],[IsVisible] FROM [PETCAREDB].[dbo].[DB_MissedPetComment] where MissID=@MissID";

        private const string SQL_DELETE_MissComment_BY_COMMENTID = @"DELETE FROM [PETCAREDB].[dbo].[DB_MissedPetComment] WHERE [CommentID]=@CommentID";

        private const string PARM_USER_ID = "@UserId";

        private const string PARM_MISS_ID = "@MissID";

        private const string PARM_MISSCOMMENT_ID = @"CommentID";


        //根据用户ID 查找其所有的评论
        public  List<CTMissedPetInfoComment> GetMissPetCommentListByUserID(string UserID)
        {
            List<CTMissedPetInfoComment> missList = new List<CTMissedPetInfoComment>();

            SqlParameter parm = new SqlParameter(PARM_USER_ID, SqlDbType.NVarChar);
            parm.Value = UserID;

            //execute the query
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_MissComment_BY_USERID, parm))
            {
                while (rdr.Read())
                {
                    CTMissedPetInfoComment petComment = new CTMissedPetInfoComment();
                    petComment.UserID = rdr["UserID"].ToString();
                    petComment.CommentID = rdr["CommentID"].ToString();
                    petComment.CommentTime = rdr["CommentTime"].ToString();
                    petComment.CommentContent = rdr["CommentContent"].ToString();
                    petComment.IP = rdr["IP"].ToString();
                    petComment.IsVisible = bool.Parse(rdr["IsVisible"].ToString());
                    petComment.MissID = rdr["MissID"].ToString();
                    missList.Add(petComment);
                }
            }
            return missList;
        }

        //根据宠物丢失ID查找其所有的评论
        public List<CTMissedPetInfoComment> GetMissPetCommentListByMissID(string MissID)
        {
            List<CTMissedPetInfoComment> missList = new List<CTMissedPetInfoComment>();

            SqlParameter parm = new SqlParameter(PARM_MISS_ID, SqlDbType.NVarChar);
            parm.Value = MissID;

            //execute the query
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_MissComment_BY_MissID, parm))
            {
                while (rdr.Read())
                {
                    CTMissedPetInfoComment petComment = new CTMissedPetInfoComment();
                    petComment.UserID = rdr["UserID"].ToString();
                    petComment.CommentID = rdr["CommentID"].ToString();
                    petComment.CommentTime = rdr["CommentTime"].ToString();
                    petComment.CommentContent = rdr["CommentContent"].ToString();
                    petComment.IP = rdr["IP"].ToString();
                    petComment.IsVisible = bool.Parse(rdr["IsVisible"].ToString());
                    petComment.MissID = rdr["MissID"].ToString();
                    missList.Add(petComment);
                }
            }
            return missList;
        }

        //根据commentID超找一条comment信息
        public CTMissedPetInfoComment GetMissPetCommentByCommentID(string commentID)
        {
            CTMissedPetInfoComment petComment = new CTMissedPetInfoComment();

            SqlParameter parm = new SqlParameter(PARM_MISSCOMMENT_ID, SqlDbType.NVarChar);
            parm.Value = commentID;

            //execute the query
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_MissComment_BY_COMMENTID, parm))
            {
                while (rdr.Read())
                {
                    petComment.UserID = rdr["UserID"].ToString();
                    petComment.CommentID = rdr["CommentID"].ToString();
                    petComment.CommentTime = rdr["CommentTime"].ToString();
                    petComment.CommentContent = rdr["CommentContent"].ToString();
                    petComment.IP = rdr["IP"].ToString();
                    petComment.IsVisible = bool.Parse(rdr["IsVisible"].ToString());
                    petComment.MissID = rdr["MissID"].ToString();
                }
            }

            return petComment;
        }

        //增减一条宠物丢失评论
        public int InsertMissPetComment(CTMissedPetInfoComment missComment)
        {
            int insertStatus = 0;
            SqlParameter[] parms = null;
            parms = new SqlParameter[]
                            {
                                new SqlParameter("@CommentID",SqlDbType.NVarChar,32),
                                new SqlParameter("@UserID",SqlDbType.NVarChar,20),
                                new SqlParameter("@MissID",SqlDbType.NVarChar,32),
                                new SqlParameter("@CommentTime",SqlDbType.DateTime ),
                                new SqlParameter("@IP",SqlDbType.NVarChar,20),
                                new SqlParameter("@CommentContent",SqlDbType.NVarChar,100),
                                new SqlParameter("@IsVisible",SqlDbType.Bit),
                            };

            parms[0].Value = missComment.CommentID;
            parms[1].Value = missComment.UserID;
            parms[2].Value = missComment.MissID;
            parms[3].Value = missComment.CommentTime;
            parms[4].Value = missComment.IP;
            parms[5].Value = missComment.CommentContent;
            parms[6].Value = missComment.IsVisible;
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
                {
                    insertStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_MissComment, parms);
                }
            }
            catch (Exception ex)
            {
            }
            return insertStatus;
        }

        //删除宠物丢失评论
        public int DeleteMissPetComment(string commentID)
        {
            int deleteStatus = 0;
            SqlParameter parm = new SqlParameter();
            parm.Value = commentID;
            parm.ParameterName = PARM_MISSCOMMENT_ID;
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
                {
                    deleteStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_MissComment_BY_COMMENTID, parm);
                }
            }
            catch (Exception ex)
            {
            }

            return deleteStatus;
        }

        //编辑宠物丢失评论
        public int EditMissPetComment(CTMissedPetInfoComment missPetComment)
        {
            int editStatus = 0;
            SqlParameter[] parms = null;
            parms = new SqlParameter[]
                            {
                                new SqlParameter("@CommentID",SqlDbType.NVarChar,20),
                                new SqlParameter("@CommentContent",SqlDbType.NVarChar,100),
                                new SqlParameter("@IsVisible",SqlDbType.Bit),
                            };

            parms[0].Value = missPetComment.CommentID;
            parms[1].Value = missPetComment.CommentContent;
            parms[2].Value = missPetComment.IsVisible;

            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
                {
                    editStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UPDATE_MissComment, parms);
                }
            }
            catch (Exception ex)
            {
            }

            return editStatus;
        }
    }
}
