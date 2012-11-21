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
    public partial class WebKnowledgeManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadArea();
            LoadUser();
            LoadPetCategory();
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
            string userID = dpUsers.SelectedValue.ToString(); ;
            string knowledgeID = tbKnowledgeID.Text.Trim().ToString();
            string addressID = dpAddress.SelectedValue.ToString();
            string petcategoryID = dpCategory.SelectedValue.ToString();
            string weiboID = tbWeiBoID.Text.Trim().Trim();
            string knowledgeTitle = tbKnowLedgeTitle.Text.Trim().ToString();
            string knowledgeTime = tbKnowlegetTime.Text.Trim().ToString();
            string priorityScore = tbPriorityScore.Text.Trim().ToString();
            string ip = tbIP.Text.Trim().ToString();
            string focusNum = tbFocusNum.Text.Trim().ToString();
            string isVisible = tbIsVisible.Text.Trim().ToString();
            string content = tbContent.Text.Trim().ToString();
            //InsertKnowledgePet(CTKnowledgePet knowledgePet)
            CTKnowledgePet knowledge = new CTKnowledgePet();
            knowledge.UserID = userID;
            knowledge.KnowledgeID = knowledgeID;
            knowledge.AddressID = addressID;
            knowledge.PetCaretegoryID = petcategoryID;
            knowledge.WeiBoID = weiboID;
            knowledge.KnowledgeTitle = knowledgeTitle;
            knowledge.KnowledgeTime = DateTime.Now;
            knowledge.PriorityScore = int.Parse(priorityScore);
            knowledge.IP = ip;
            knowledge.IsVisible = bool.Parse(isVisible);
            knowledge.LastEditTime = DateTime.Now;
            knowledge.KnowledgeInfo = content;
            knowledge.FocusNum = int.Parse(focusNum);
            KnowledgePet knowledgePet = new KnowledgePet();
            knowledgePet.InsertKnowledgePet(knowledge);


        }
    }
}