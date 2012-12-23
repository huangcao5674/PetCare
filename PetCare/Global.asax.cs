using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PetCare
{
    // 注意: 有关启用 IIS6 或 IIS7 经典模式的说明，
    // 请访问 http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // 路由名称
                "{controller}/{action}", // 带有参数的 URL
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // 参数默认值
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            Application.Lock();    ///Application对象加锁  
            if (Application["OnlineCount"] == null)
            {   ///初始化在线人数为1  
                Application["OnlineCount"] = 1;
            }
            Application.UnLock();///Application对象解锁  
        }
        void Session_Start(object sender, EventArgs e)
        {
            Application.Lock();   ///Application对象加锁  
            if (Application["OnlineCount"] != null)
            {   ///获取当前在线人数  
                int count = Int32.Parse(Application
                ["OnlineCount"].ToString());
                ///设置当前在线人数，计数器增1  
                Application["OnlineCount"] = count + 1;
            }
            else
            {   ///计数器初始化为1  
                Application["OnlineCount"] = 1;
            }
            Application.UnLock();///Application对象解锁  
        }
        void Session_End(object sender, EventArgs e)
        {
            Application.Lock();   ///Application对象加锁  
            if (Application["OnlineCount"] != null)
            {   ///获取当前在线人数  
                int count = Int32.Parse(Application
                ["OnlineCount"].ToString());
                ///设置当前在线人数，计数器减1  
                Application["OnlineCount"] = count - 1;
            }
            else
            {   ///计数器初始化为1  
                Application["OnlineCount"] = 0;
            }
            Application.UnLock();///Application对象解锁  
        } 
    }
}