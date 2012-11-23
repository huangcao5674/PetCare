using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.BLL;
using PetCare.Model;
using PetCare.DBUtility;


namespace PetCare.Interface
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegister_Click(object sender, EventArgs e)
        {
 
            string username = tb_UserName.Text.Trim().ToString();
            string pass = tb_Pass.Text.Trim().ToString();
            string passConfirm = tb_PassConfirm.Text.Trim().ToString();
            string email = tb_Email.Text.Trim().ToString();
            int age = int.Parse(tb_Age.Text.Trim().ToString());
            User user = new User();
            CTUserInfo userInfo = new CTUserInfo(username, pass,"","", age, "", email, "", "", "", "", 0);
            int insertStatus= user.InsertUserInfo(userInfo);
            if (insertStatus == 1)
            {
                //CUtilities.SendMail("petcareweb", "honkcal@163.com", "aaa", "aaa");
                Response.Write("<script>alert('注册成功!')</script>");

            }
            else
            {
                Response.Write("<script>alert('注册失败!')</script>");
            }
            
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm1.aspx", false); 
        }
    }
}