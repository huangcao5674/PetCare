using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.Model;
using PetCare.BLL;

namespace PetCare.ManageMent
{
    public partial class FocusManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUser();
            }
        }

        private void LoadUser()
        {
            List<CTUserInfo> userList = new List<CTUserInfo>();
            User user = new User();
            userList = user.GetAllUserList();
            dpUser.DataSource = userList;
            dpUser.DataTextField = "UserName";
            dpUser.DataValueField = "UserID";
            dpUser.DataBind();
        }

        protected void BtnCheck_Click(object sender, EventArgs e)
        {
            List<CUserFocusArticle> list = new List<CUserFocusArticle>();
            UserFocus userfocus = new UserFocus();
            string userID = dpUser.SelectedValue.ToString();
            list = userfocus.GetAllUserFocusInfoByUserID(userID);
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm1.aspx", false); 
        }
    }
}