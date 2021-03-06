﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using PetCare.DBUtility;


namespace PetCare.SQLServerDAL
{
    public class KnowledgePetComment:IKnowledgePetComment
    {
        private const string SQL_SELECT_KnowledgeComment_BY_USERID = @"SELECT [CommentID],[UserID],[KnowledgeID],[CommentTime],[IP],[CommentContent],[IsVisible] FROM [PETCAREDB].[dbo].[DB_KnowledgePetComment] where UserID=@UserID";

        private const string SQL_SELECT_KnowledgeComment_BY_COMMENTID = @"SELECT [CommentID],[UserID],[KnowledgeID],[CommentTime],[IP],[CommentContent],[IsVisible] FROM [PETCAREDB].[dbo].[DB_KnowledgePetComment] where CommentID=@CommentID";

        private const string SQL_INSERT_KnowledgeComment = @"INSERT INTO [PETCAREDB].[dbo].[DB_KnowledgePetComment]([CommentID] ,[UserID],[KnowledgeID],[CommentTime],[IP],[CommentContent],[IsVisible]) VALUES"
            + "(@CommentID  ,@UserID ,@KnowledgeID ,@CommentTime ,@IP ,@CommentContent ,@IsVisible)";
       
        private const string SQL_UPDATE_KnowledgeComment = @"Update [PETCAREDB].[dbo].[DB_KnowledgePetComment] SET [CommentContent]=@CommentContent,[IsVisible]=@IsVisible WHERE CommentID=@CommentID";


        private const string SQL_DELETE_KnowledgeComment = @"DELETE FROM [PETCAREDB].[dbo].[DB_UserInfo] WHERE UserID=@UserId";

        private const string SQL_EDIT_USER = @"UPDATE [PETCAREDB].[dbo].[DB_UserInfo] SET [UserName] = @UserName,[UserPass] = @UserPass,[UserRealName]= @UserRealName,[UserAge] =@UserAge "
            + ",[UserSex] @UserSex,[UserAddress]=@UserAddress,[UserEmail]=@UserEmail,[UserPhoneNumber]=@UserPhoneNumber"
            + " ,[UserQQNum]=@UserQQNum,[UserInfo]= @UserInfo,[ComplaintNum]=@ComplaintNum WHERE UserID=@UserID";

        private const string SQL_SELECT_KnowledgeComment_BY_Knowledge = @"SELECT [CommentID],[UserID],[KnowledgeID],[CommentTime],[IP],[CommentContent],[IsVisible] FROM [PETCAREDB].[dbo].[DB_KnowledgePetComment] where KnowledgeID=@KnowledgeID";

        private const string SQL_DELETE_KnowledgeComment_BY_COMMENTID = @"DELETE FROM [PETCAREDB].[dbo].[DB_KnowledgePetComment] WHERE [CommentID]=@CommentID";

        private const string PARM_USER_ID = "@UserId";

        private const string PARM_KNOWLEDGE_ID = "@KnowledgeID";

        private const string PARM_KNOWLEDGECOMMENT_ID = @"CommentID";


       public  List<CTKnowledgePetComment> GetKnowledgePetCommentListByUserID(string UserID)
        {
            List<CTKnowledgePetComment> list = new List<CTKnowledgePetComment>();
            SqlParameter parm = new SqlParameter(PARM_USER_ID, SqlDbType.NVarChar);
            parm.Value = UserID;

            //execute the query
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_KnowledgeComment_BY_USERID, parm))
            {
                while (rdr.Read())
                {
                    CTKnowledgePetComment petComment = new CTKnowledgePetComment();
                    petComment.UserID = rdr["UserID"].ToString();
                    petComment.CommentID = rdr["CommentID"].ToString();
                    petComment.CommentTime = rdr["CommentTime"].ToString();
                    petComment.CommentContent = rdr["CommentContent"].ToString();
                    petComment.IP = rdr["IP"].ToString();
                    petComment.IsVisible = bool.Parse(rdr["IsVisible"].ToString());
                    list.Add(petComment);
                }
            }

            return list;
        }

       public  List<CTKnowledgePetComment> GetKnowledgePetCommentListByKnowledge(string KnowledgeID)
        {
            List<CTKnowledgePetComment> list = new List<CTKnowledgePetComment>();
            SqlParameter parm = new SqlParameter(PARM_KNOWLEDGE_ID, SqlDbType.NVarChar);
            parm.Value = KnowledgeID;

            //execute the query
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_KnowledgeComment_BY_Knowledge, parm))
            {
                while (rdr.Read())
                {
                    CTKnowledgePetComment petComment = new CTKnowledgePetComment();
                    petComment.UserID = rdr["UserID"].ToString();
                    petComment.CommentID = rdr["CommentID"].ToString();
                    petComment.CommentTime =  rdr["CommentTime"].ToString();
                    petComment.CommentContent = rdr["CommentContent"].ToString();
                    petComment.IP = rdr["IP"].ToString();
                    petComment.IsVisible = bool.Parse(rdr["IsVisible"].ToString());
                    list.Add(petComment);
                }
            }

            return list;
        }

        //插入一条评论信息
       public int InsertKnowledgePetComment(CTKnowledgePetComment knowledgeComment)
        {
            int insertStatus = 0;
            SqlParameter[] parms = null;
            parms = new SqlParameter[]
                            {
                                new SqlParameter("@CommentID",SqlDbType.NVarChar,20),
                                new SqlParameter("@UserID",SqlDbType.NVarChar,20),
                                new SqlParameter("@KnowledgeID",SqlDbType.NVarChar,20),
                                new SqlParameter("@CommentTime",SqlDbType.DateTime ),
                                new SqlParameter("@IP",SqlDbType.NVarChar,20),
                                new SqlParameter("@CommentContent",SqlDbType.NVarChar,100),
                                new SqlParameter("@IsVisible",SqlDbType.Bit),
                            };

            parms[0].Value = knowledgeComment.CommentID;
            parms[1].Value = knowledgeComment.UserID;
            parms[2].Value = knowledgeComment.KnwoledgeID;
            parms[3].Value = knowledgeComment.CommentTime;
            parms[4].Value = knowledgeComment.IP;
            parms[5].Value = knowledgeComment.CommentContent;
            parms[6].Value = knowledgeComment.IsVisible;
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
                {
                    insertStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_KnowledgeComment, parms);
                }
            }
            catch (Exception ex)
            {
            }
            return insertStatus;
        }


        //根据commentID 删除对应的评论信息
       public int DeleteKnowledgePetComment(string commentID)
       {
           int deleteStatus = 0;
           SqlParameter parm = new SqlParameter();
           parm.Value = commentID;
           parm.ParameterName = PARM_KNOWLEDGECOMMENT_ID;
           try
           {
               using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
               {
                   deleteStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_KnowledgeComment_BY_COMMENTID, parm);
               }
           }
           catch (Exception ex)
           {
           }

           return deleteStatus;
       }


        //根据commentID编辑对应的评论信息
       public int EditKnowledgePetComment(CTKnowledgePetComment knowledgeComment)
       {
           int editStatus = 0;
           SqlParameter[] parms = null;
           parms = new SqlParameter[]
                            {
                                new SqlParameter("@CommentID",SqlDbType.NVarChar,20),
                                new SqlParameter("@CommentContent",SqlDbType.NVarChar,100),
                                new SqlParameter("@IsVisible",SqlDbType.Bit),
                            };

           parms[0].Value = knowledgeComment.CommentID;
           parms[1].Value = knowledgeComment.CommentContent;
           parms[2].Value = knowledgeComment.IsVisible;

           try
           {
               using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
               {
                   editStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UPDATE_KnowledgeComment, parms);
               }
           }
           catch (Exception ex)
           {
           }
 
           return editStatus;
       }

        //根据commentID 获取相应的comment信息
       public CTKnowledgePetComment GetKnowledgePetCommentByCommentID(string commentID)
       {
           CTKnowledgePetComment knowledgeComment = new CTKnowledgePetComment();

           SqlParameter parm = new SqlParameter();
           parm.Value = commentID;
           parm.ParameterName=PARM_KNOWLEDGECOMMENT_ID;
           parm.SqlDbType=SqlDbType.NVarChar;

           try
           {
               using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_KnowledgeComment_BY_COMMENTID, parm))
               {
                   while (rdr.Read())
                   {
                       knowledgeComment.UserID = rdr["UserID"].ToString();
                       knowledgeComment.CommentID = rdr["CommentID"].ToString();
                       knowledgeComment.CommentTime = rdr["CommentTime"].ToString();
                       knowledgeComment.CommentContent = rdr["CommentContent"].ToString();
                       knowledgeComment.IP = rdr["IP"].ToString();
                       knowledgeComment.IsVisible = bool.Parse(rdr["IsVisible"].ToString());
                       knowledgeComment.KnwoledgeID = rdr["KnowledgeID"].ToString();
                       
                   }
               }
           }
           catch (Exception ex)
           {
           }
           return knowledgeComment;
       }
    }
}
