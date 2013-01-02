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
    public partial class KnowledgeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUser();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int pageNumb =int.Parse( TextBox2.Text.Trim().ToString());
            int pagePerPage = CPetCareConfiguration.PetPerPageNumbers;

            List<CVKnowledgePet> list = new List<CVKnowledgePet>();
            KnowledgePet knowleget = new KnowledgePet();
            int howmanyPages = 0;
            list = knowleget.GetPetKnowledgePerPageList(pageNumb, pagePerPage,out howmanyPages);
            GridView1.DataSource = list;
            GridView1.DataBind();

        }

        private void LoadUser()
        {
            List<CTUserInfo> userList = new List<CTUserInfo>();
            User user = new User();
            userList = user.GetAllUserList();
            ddlUser.DataSource = userList;
            ddlUser.DataTextField = "UserName";
            ddlUser.DataValueField = "UserID";
            ddlUser.DataBind();
        }




    }
}