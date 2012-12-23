using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.BLL;

namespace PetCare.ManageMent
{
    public partial class Login : System.Web.UI.Page
    {
        private static bool isUserSession = true;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string userName = tbUserName.Text.Trim().ToString();
            string userPass = tbPassword.Text.Trim().ToString();
            User user = new User();
            int validateStatus = user.ValidateUserLogin(userName, userPass);
            if (validateStatus > 0)
            {

                if (isUserSession)
                {
                    System.Web.HttpContext.Current.Session["UserName"] = userName;
                    Response.Redirect("ManagementIndex.aspx");
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Cookies["UserName"].Value = null;
                    Response.Write("<script>alert('登录成功!')</script>");
                }
            }
            else
            {

                if (isUserSession)
                {
                    System.Web.HttpContext.Current.Session["UserName"] = null;
                    Response.Write("<script>alert('登录失败!')</script>");
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Cookies["UserName"].Value = null;
                    Response.Write("<script>alert('登录失败!')</script>");
                }
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }
    }
}