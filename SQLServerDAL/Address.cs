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

        private const string SQL_SELECT_ADDRESS = @"SELECT [AddressID],[Province],[City] FROM [PETCAREDB].[dbo].[DB_Address]";

        private const string SQL_INSERT_ADDRESS = @"INSERT INTO [PETCAREDB].[dbo].[DB_Address]([AddressID],[Province],[City]) VALUES"
            + "(@AddressID,@Province,@City)";



        //得到所有的地址的信息
        public List<CTAddress> GetAllAddressInfo()
        {
            List<CTAddress> addressList = new List<CTAddress>();
            using (SqlDataReader rdr = SqlHelper.ExecuteReader(SqlHelper.ConnectionStringLocalTransaction, CommandType.Text, SQL_SELECT_ADDRESS, null))
            {
                while (rdr.Read())
                {
                    CTAddress address = new CTAddress();
                    address.AddressID = rdr["AddressID"].ToString();
                    address.Province = rdr["Province"].ToString();
                    address.City = rdr["City"].ToString();
                    addressList.Add(address);
                }
            }
            return addressList;
        }
       

        //根据信息
       public List<CTAddress> GetUserInfoByProvince(string provinceName)
        {
            List<CTAddress> addressList = new List<CTAddress>();
            return addressList;
        }

        //增加地址信息
        public int InsertAddress(CTAddress addressInfo)
        {
            int insertStatus = 0;
            return insertStatus;
        }

        //删除地址信息
       public  int DeleteAddress(string addressInfo)
        {
            int deleteStatus = 0;
            return deleteStatus;
        }
    }
}
