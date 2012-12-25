//---------------------------------
//time 20120923
//create by huangyanchao 
//---------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Configuration.Provider;

namespace PetCare.DBUtility
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
        public static string MailServer
        {
            get
            {
                return ConfigurationManager.AppSettings["MailServer"].ToString();
            }
        }
        public static string MailUsername
        {
            get
            {
                return ConfigurationManager.AppSettings["MailUsername"].ToString();
            }
        }
        public static string MailPassword
        {
            get
            {
                return ConfigurationManager.AppSettings["MailPassword"].ToString();
            }
        }
        public static string MailFrom
        {
            get
            {
                return ConfigurationManager.AppSettings["MailFrom"].ToString();
            }
            
        }



        //代表文章缩略显示的个数
        public static int ArticleBreviaryNum
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["ArticleBreviaryNum"].ToString());
            }
        }
        //代表文章所有显示的个数
        public static int AriticleAllNum
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["AriticleAllNum"].ToString());
            }
        }

        //分业每页显示的数量
        public static int PetPerPageNumbers
        {
            get
            {
                return int.Parse(ConfigurationManager.AppSettings["PerPageNum"].ToString());
            }
        }
    }
}
