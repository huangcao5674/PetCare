//---------------------------------
//time 20120923
//create by huangyanchao 
//---------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;

namespace Model
{
    /// <summary>
    /// 包含通用数据库访问功能的类，业务逻辑层会用到它
    /// </summary>
    public static class CGenerateDataAccess
    {
        static CGenerateDataAccess()
        {
            //构造函数
        }


        /// <summary>
        /// 创建并准备基于新连接的DbCommand对象， 参数为可选的存储过程或者sql语句
        /// </summary>
        /// <returns></returns>
        public static DbCommand CreateCommand(CommandType commandtype,string commandText)
        {
            //数据库服务器名称
            string dataProviderName = "";
            //数据库连接字符串
            string ConnectionString = "";
            //数据库数据提供器工厂
            DbProviderFactory factory = DbProviderFactories.GetFactory(dataProviderName);
            //获取某种特定的数据库连接
            DbConnection conn = factory.CreateConnection();
            conn.ConnectionString = ConnectionString;
            DbCommand comm = conn.CreateCommand();
            //类型为存储过程
            comm.CommandType = commandtype;
            comm.CommandText = commandText;
            
            return comm;
        }


        //执行dbcommand 并返回一个datatable
        public static DataTable ExecuteSelectCommand(DbCommand command)
        {
            DataTable table;
            try
            {
                command.Connection.Open();
                DbDataReader reader = command.ExecuteReader();
                table = new DataTable();
                table.Load(reader);
                reader.Close();
            }
            catch (Exception ex)
            {
                CUtilities.LogError(ex);
                throw;
            }
            finally
            {
                command.Connection.Close();
            }
            return table;
        }

        /// <summary>
        /// 执行一个update,delete,insert 命令返回影响的数据的行数
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static int ExecuteNonQuery(DbCommand command)
        {
            //受影响的行数
            int affectedRows = -1;
            try
            {
                command.Connection.Open();
                affectedRows = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                CUtilities.LogError(ex);
                throw;
            }
            finally
            {
                command.Connection.Close();
            }
            return affectedRows;
        }


        /// <summary>
        /// 执行一个select命令并返回行数
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public static string ExecuteScalar(DbCommand command)
        {
            //将要返回的值
            string value =string.Empty;
            try
            {
                command.Connection.Open();
                value = command.ExecuteScalar().ToString();
            }
            catch (Exception ex)
            {
                CUtilities.LogError(ex);
                throw;
            }
            finally
            {
                command.Connection.Close();
            }
            return value;
        }

    }
}
