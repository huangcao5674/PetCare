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
    /// 这个类的作用为处理异常错误信息，监控访问信息等
    /// </summary>
    public static class CUtilities
    {
        static CUtilities()
        {

        }
        public static void LogError(Exception ex)
        {
            string dateTime = DateTime.Now.ToLongDateString() + ",at" + DateTime.Now.ToShortTimeString();

            string errorMessage = "Exception genereated on " + dateTime;

            
        }
    }
}
