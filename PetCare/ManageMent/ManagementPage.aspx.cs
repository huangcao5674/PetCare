using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.BLL;
using PetCare.Model;
using System.Web.SessionState;
 

namespace PetCare
{
    public partial class ManagementPage : System.Web.UI.Page
    {
        private static bool isUserSession = true;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            LbUserName.Text = CheckUser();
        }

        public static string CheckUser()
        {
            if (isUserSession)
            {
                if (System.Web.HttpContext.Current.Session["UserName"] == null)
                    //没有登录
                    return null;
                else
                {
                    //返回信息
                    string info = System.Web.HttpContext.Current.Session["UserName"].ToString();
                    //info = Encryptor.Decrypt(info);
                    //判断信息是否正确
                    if (info.Length == 0)
                        //信息不正确
                        return null;

                    return info;
                }
            }
            else
            {
                if (System.Web.HttpContext.Current.Request.Cookies["UserName"] == null)
                    //没有登录
                    return null;
                else
                {
                    //返回信息
                    string info = System.Web.HttpContext.Current.Request.Cookies["UserName"].Value;
                    //判断信息是否正确
                    if (info.Length == 0)
                        //信息不正确
                        return null;

                    return info;
                }
            }
        }
 
        //public static void UserOut()
        //{
        //    System.Web.HttpContext.Current.Session["UserName"] = null;
        //    System.Web.HttpContext.Current.Response.Cookies["UserName"].Value = null;
        //}
    }
}