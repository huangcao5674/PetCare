using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.Model;
using PetCare.BLL;
using System.Net;

namespace PetCare.ManageMent
{
    public partial class WebKnowledgeManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadArea();
                LoadUser();
                LoadPetCategory();
            }
        }

        private void LoadUser()
        {
            List<CTUserInfo> userList = new List<CTUserInfo>();
            User user = new User();
            userList = user.GetAllUserList();
            dpUsers.DataSource = userList;
            dpUsers.DataTextField = "UserName";
            dpUsers.DataValueField = "UserID";
            dpUsers.DataBind();
        }
        private void LoadArea()
        {
            List<CTAddress> addressList = new List<CTAddress>();
            Address address = new Address();
            addressList = address.GetAllUserList();
            dpAddress.DataSource = addressList;
            dpAddress.DataTextField = "City";
            dpAddress.DataValueField = "AddressID";
            dpAddress.DataBind();
        }

        private void LoadPetCategory()
        {
            List<CTPetCategory> petcategoryList = new List<CTPetCategory>();
            PetCategory petcategory = new PetCategory();
            petcategoryList = petcategory.GetPetCategoryList();
            dpCategory.DataSource = petcategoryList;
            dpCategory.DataTextField = "petCategoryName";
            dpCategory.DataValueField = "petCaregoryID";
            dpCategory.DataBind();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            //获取本机IP
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipa = ipe.AddressList[0];
            string userID = dpUsers.SelectedValue.ToString(); 
            string knowledgeID =Guid.NewGuid().ToString();
            string addressID = dpAddress.SelectedValue.ToString();
            string petcategoryID = dpCategory.SelectedValue.ToString();
            string weiboID = "";
            string knowledgeTitle = tbKnowLedgeTitle.Text.Trim().ToString();
            string knowledgeTime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            string ip = ipa.ToString();
            string content = tbContent.Text.Trim().ToString();
            CTKnowledgePet knowledge = new CTKnowledgePet();
            knowledge.UserID = userID;
            knowledge.KnowledgeID = knowledgeID;
            knowledge.AddressID = addressID;
            knowledge.PetCaretegoryID = petcategoryID;
            knowledge.WeiBoID = weiboID;
            knowledge.KnowledgeTitle = knowledgeTitle;
            knowledge.KnowledgeTime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            knowledge.PriorityScore = 0;
            knowledge.IP = ip;
            knowledge.IsVisible = true;
            knowledge.LastEditTime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            knowledge.KnowledgeInfo = content;
            knowledge.FocusNum = 0;
            KnowledgePet knowledgePet = new KnowledgePet();
            int insertStatus=knowledgePet.InsertKnowledgePet(knowledge);
            if (insertStatus == 1)
            {
                Response.Write("<script>alert('添加成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败!')</script>");
            }

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm1.aspx", false); 
        }
    }
}