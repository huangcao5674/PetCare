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
        }

        private void LoadUser()
        {
            List<CTUserInfo> userList = new List<CTUserInfo>();
            User user = new User();
            userList = user.GetAllUserList();
        }
        private void LoadArea()
        {
            List<CTAddress> addressList = new List<CTAddress>();
            Address address = new Address();
            addressList = address.GetAllUserList();
            dpAddress.DataSource = addressList;
            dpAddress.DataTextField = "City";
        }

        private void LoadPetCategory()
        {
            List<CTPetCategory> petcategoryList = new List<CTPetCategory>();
            PetCategory petcategory = new PetCategory();
            petcategoryList = petcategory.GetPetCategoryList();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string userID = tbUserID.Text.Trim().ToString();
            string knowledgeID = tbKnowledgeID.Text.Trim().ToString();
            string addressID = tbAddressID.Text.Trim().ToString();
            string petcategoryID = tbPetCategoryID.Text.Trim().ToString();
            string weiboID = tbWeiBoID.Text.Trim().Trim();
            string knowledgeTitle = tbKnowLedgeTitle.Text.Trim().ToString();
            string knowledgeTime = tbKnowlegetTime.Text.Trim().ToString();
            string priorityScore = tbPriorityScore.Text.Trim().ToString();
            string ip = tbIP.Text.Trim().ToString();
            string focusNum = tbFocusNum.Text.Trim().ToString();
            string isVisible = tbIsVisible.Text.Trim().ToString();
            string content = tbContent.Text.Trim().ToString();
        }
    }
}