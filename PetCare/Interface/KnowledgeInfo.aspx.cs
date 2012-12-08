using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.BLL;
using PetCare.Model;

namespace PetCare.Interface
{
    public partial class KnowledgeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUser();
                LoadAdoptList();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            int pageNumb =int.Parse( TextBox2.Text.Trim().ToString());
            int pagePerPage = int.Parse(TextBox3.Text.Trim().ToString());
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
        private void LoadAdoptList()
        {
            List<CTKnowledgePet> adoptList = new List<CTKnowledgePet>();
            KnowledgePet knowledgePet = new KnowledgePet();
            adoptList = knowledgePet.GetKnowledgePetList();
            ddAdoptList.DataSource = adoptList;
            ddAdoptList.DataTextField = "KnowledgeTitle";
            ddAdoptList.DataValueField = "KnowledgeID";
            ddAdoptList.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userID = string.Empty;
            userID = ddlUser.SelectedValue.ToString();
            List<CTKnowledgePet> list = new List<CTKnowledgePet>();
            User user = new User();
            list = user.GetKnowLedgePetListByUserID(userID);
            GridView1.DataSource = list;
            GridView1.DataBind();
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string adoptID = ddAdoptList.SelectedValue.ToString();
            KnowledgePet knowledgepet = new KnowledgePet();
            List<CVKnowledgePetComment>list=new List<CVKnowledgePetComment>();
            int numb=int.Parse(TextBox4.Text.Trim().ToString());
            int perPage=int.Parse(TextBox5.Text.Trim().ToString());
            int hom;
            list = knowledgepet.GetPetKnowledgeCommentPerPageList(adoptID,numb,perPage,out hom);
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }
}