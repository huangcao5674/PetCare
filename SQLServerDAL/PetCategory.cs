using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using PetCare.DBUtility;

namespace PetCare.SQLServerDAL
{
    public class PetCategory:IPetCategory
    {

        private const string SQL_SELECT_PetCategory = @"SELECT [PetCategoryID],[PetCategoryName],[PetCategoryInfo],[IsVisible] FROM [PETCAREDB].[dbo].[DB_PetCategory]";

        private const string SQL_INSERT_PetCategory = @"INSERT INTO [PETCAREDB].[dbo].[DB_PetCategory]([PetCategoryID],[PetCategoryName],[PetCategoryInfo],[IsVisible])"
            + "VALUES(@PetCategoryId,@PetCategoryName,@PetCategoryInfo,1)";

        private const string SQL_DELETE_PetCategory = @"DELETE FROM [PETCAREDB].[dbo].[DB_PetCategory] WHERE PetCategoryID=@PetCategoryId";

        private const string SQL_EDIT_PetCategory = @"UPDATE [PETCAREDB].[dbo].[DB_PetCategory] SET [PetCategoryName]=@PetCategoryName, [PetCategoryInfo]=@PetCategoryInfo,[IsVisible]=@IsVisible where [PetCategoryID]=@PetCategoryID";

        private const string PARM_PetCategory_ID = "@PetCategoryID";

        private const string PARM_PetCategory_Name = "@PetCategoryName";

        private const string PARM_PetCategory_Info = "@PetCategoryInfo";



        //得到所有的宠物分类
        public List<CTPetCategory> GetAllPetCategoryInfo()
        {
            List<CTPetCategory> list = new List<CTPetCategory>();

            //execute the query
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_PetCategory, null))
            {
                while (rdr.Read())
                {
                    CTPetCategory petCategory = new CTPetCategory();
                    petCategory.petCategoryID = rdr["PetCategoryID"].ToString();
                    petCategory.petCategoryName = rdr["PetCategoryName"].ToString();
                    petCategory.petCategoryInfo = rdr["petCategoryInfo"].ToString();
                    petCategory.IsVisible = bool.Parse(rdr["IsVisible"].ToString());
                    list.Add(petCategory);
                }
                rdr.Close();
                rdr.Dispose();
            }

            return list;
        }

   
        //增加宠物分类信息
        public int InsertPetCategory(CTPetCategory petCategory)
        {
            int insertStatus = 0;
            SqlParameter[] parms = null;
            parms = new SqlParameter[]
                            {
                                new SqlParameter("@PetCategoryId",SqlDbType.NVarChar,20),
                                new SqlParameter("@PetCategoryName",SqlDbType.NVarChar,50),
                                new SqlParameter("@PetCategoryInfo",SqlDbType.NVarChar,50),
                            };
            parms[0].Value = petCategory.petCategoryID;
            parms[1].Value = petCategory.petCategoryName;
            parms[2].Value = petCategory.petCategoryInfo;
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
            {
                insertStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_PetCategory, parms);
            }
            return insertStatus;
        }

        //删除宠物分类信息
        public int DeletePetCategoryInfo(string petCategoryID)
        {
            int deleteStatus = 0;
            SqlParameter param = new SqlParameter();
            param.Value = petCategoryID;
            param.ParameterName = PARM_PetCategory_ID;
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
            {
                deleteStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_PetCategory, param);
            }
            return deleteStatus;
        }


        //编辑宠物分类信息
        public int EditPetCategoryInfo(CTPetCategory petCategory)
        {
            int editStatus = 0;
            SqlParameter[] parms = null;
            parms = new SqlParameter[]
                            {
                                new SqlParameter("@PetCategoryID",SqlDbType.NVarChar,20),
                                new SqlParameter("@PetCategoryName",SqlDbType.NVarChar,50),
                                new SqlParameter("@PetCategoryInfo",SqlDbType.NVarChar,50),
                                new SqlParameter("@IsVisible",SqlDbType.Bit),
                            };
            parms[0].Value = petCategory.petCategoryID;
            parms[1].Value = petCategory.petCategoryName;
            parms[2].Value = petCategory.petCategoryInfo;
            parms[3].Value = petCategory.IsVisible;
            using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
            {
                editStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_EDIT_PetCategory, parms);
            }
            return editStatus;
        }

    }
}
