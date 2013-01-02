using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.Model;
using PetCare.BLL;
using PetCare.DBUtility;

namespace PetCare.ManageMent
{
    public partial class WebKnowledgeCommentManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadAdoptList();
            }
        }

        protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void BtnEdit_Click1(object sender, EventArgs e)
        {

        }

        protected void BtnComment_Click(object sender, EventArgs e)
        {
            string adoptID = ddAdoptList.SelectedValue.ToString();
            KnowledgePet knowledgepet = new KnowledgePet();
            List<CVKnowledgePetComment> list = new List<CVKnowledgePetComment>();
            int numb = int.Parse(TextBox4.Text.Trim().ToString());
            int perPage = CPetCareConfiguration.PetPerPageNumbers;
            int hom;
            list = knowledgepet.GetPetKnowledgeCommentPerPageList(adoptID, numb, perPage, out hom);
            GridView1.DataSource = list;
            GridView1.DataBind();
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
    }
}