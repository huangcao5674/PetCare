using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;
using System.Data.Common;
using System.Data.SqlClient;
using PetCare.DBUtility;
using System.Data;

namespace PetCare.SQLServerDAL
{
    public class Address:IAddress
    {

        private const string SQL_SELECT_ADDRESS = @"SELECT [AddressID],[Province],[City],[FatherID],[Visible] FROM [PETCAREDB].[dbo].[DB_Address]";

        private const string SQL_INSERT_ADDRESS = @"INSERT INTO [PETCAREDB].[dbo].[DB_Address]([AddressID],[Province],[City],[Visible]) VALUES"
            + "(@AddressID,@Province,@City,1)";

        private const string SQL_DELETE_ADDRESS = @"DELETE FROM [PETCAREDB].[dbo].[DB_Address] WHERE [AddressID]=@AddressID";

        private const string SQL_UPDATE_ADDRESS = @"Update [PETCAREDB].[dbo].[DB_Address] SET [Province]=@Province,[City]=@City,[Visible]=@Visible WHERE [AddressID]=@AddressID";

        private const string SQL_SELECT_ADDRESS_BY_PROVINCE = @"SELECT [AddressID],[Province],[City],[FatherID],[Visible] FROM [PETCAREDB].[dbo].[DB_Address] WHERE Province=@Province";

        //得到所有的地址的信息
        public List<CTAddress> GetAllAddressInfo()
        {
            List<CTAddress> addressList = new List<CTAddress>();
            try
            {
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_ADDRESS, null))
                {
                    while (rdr.Read())
                    {
                        CTAddress address = new CTAddress();
                        address.AddressID = rdr["AddressID"].ToString();
                        address.Province = rdr["Province"].ToString();
                        address.City = rdr["City"].ToString();
                        address.FatherID = rdr["FatherID"].ToString();
                        bool tempIsVisible = true;
                        address.IsVisible = bool.TryParse(rdr["Visible"].ToString(), out tempIsVisible) ? tempIsVisible : true;
                        addressList.Add(address);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return addressList;
        }
       

        //根据省份获取地区名称
       public List<CTAddress> GetUserInfoByProvince(string provinceName)
        {
            List<CTAddress> addressList = new List<CTAddress>();
            SqlParameter param = new SqlParameter();
            param.Value = provinceName;
            try
            {
                using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_ADDRESS_BY_PROVINCE, param))
                {
                    while (rdr.Read())
                    {
                        CTAddress address = new CTAddress();
                        address.AddressID = rdr["AddressID"].ToString();
                        address.Province = rdr["Province"].ToString();
                        address.City = rdr["City"].ToString();
                        address.FatherID = rdr["FatherID"].ToString();
                        bool tempIsVisible = true;
                        address.IsVisible = bool.TryParse(rdr["Visible"].ToString(), out tempIsVisible) ? tempIsVisible : true;
                        addressList.Add(address);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return addressList;
        }

        //增加地址信息
        public int InsertAddress(CTAddress addressInfo)
        {
            int insertStatus = 0;
            SqlParameter[] parms = null;
            parms = new SqlParameter[]
                            {
                                new SqlParameter("@AddressID",SqlDbType.NVarChar,20),
                                new SqlParameter("@Province",SqlDbType.NVarChar,20),
                                new SqlParameter("@City",SqlDbType.NVarChar,20),
                            };
            parms[0].Value = addressInfo.AddressID;
            parms[1].Value = addressInfo.Province;
            parms[2].Value = addressInfo.City;
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
                {
                    insertStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_INSERT_ADDRESS, parms);
                }
            }
            catch(Exception ex)
            {

            }
            return insertStatus;
        }

        //更新地址信息
        public int UpdateAddress(CTAddress addressInfo)
        {
            int updateStatus = 0;
            SqlParameter[] parms = null;
            parms = new SqlParameter[]
                            {
                                new SqlParameter("@Province",SqlDbType.NVarChar,20),
                                new SqlParameter("@City",SqlDbType.NVarChar,20),
                                new SqlParameter("@Visible",SqlDbType.Bit),
                                new SqlParameter("@AddressID",SqlDbType.NVarChar,20),
                            };
            parms[0].Value = addressInfo.Province;
            parms[1].Value = addressInfo.City;
            parms[2].Value = addressInfo.IsVisible;
            parms[3].Value = addressInfo.AddressID;
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
                {
                    updateStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_UPDATE_ADDRESS, parms);
                }
            }
            catch (Exception ex)
            {

            }
            return updateStatus;
        }

        //删除地址信息
       public  int DeleteAddress(string addressID)
        {
            int deleteStatus = 0;
            SqlParameter parm = new SqlParameter();
            parm.ParameterName = "@AddressID";
            parm.Value = addressID;
            try
            {
                using (SqlConnection conn = new SqlConnection(SqlHelper.ConnectionStringOrderDistributedTransaction))
                {
                    deleteStatus = SqlHelper.ExecuteNonQuery(conn, CommandType.Text, SQL_DELETE_ADDRESS, parm);
                }
            }
            catch (Exception ex)
            {

            }
            return deleteStatus;
        }
    }
}
