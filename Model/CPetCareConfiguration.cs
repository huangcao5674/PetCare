//---------------------------------
//time 20120923
//create by huangyanchao 
//---------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Model
{
    /// <summary>
    /// 从配置文件读取信息类
    /// </summary>
    public static class CPetCareConfiguration
    {
        //连接字符串
        private static string dbConnectionString;

        //数据库提供器名称
        private static string dbProviderName;

        static CPetCareConfiguration()
        {

        }
        public static string DbConnectionString
        {
            get
            {
                return dbConnectionString;
            }
        }
        public static string DbProviderName
        {
            get
            {
                return dbProviderName;
            }
        }
    }
}
