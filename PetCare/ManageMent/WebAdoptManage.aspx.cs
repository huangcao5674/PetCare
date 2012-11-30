using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.BLL;
using PetCare.Model;
using System.Net;

namespace PetCare.ManageMent
{
    public partial class WebAdoptManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUser();
                LoadArea();
                LoadPetCategory();
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string title = tbTitle.Text.Trim().ToString();
            string content = tbContent.Text.ToString();
            string userID = ddlUser.SelectedValue.ToString();
            string categoryID = ddlCategoryAdd.SelectedValue.ToString();
            string addressID = ddlAddressAdd.SelectedValue.ToString();
            string adoptID = Guid.NewGuid().ToString();
            bool isAdopt = bool.Parse(CheckBox1.Checked.ToString());
            //获取本机IP
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipa = ipe.AddressList[0];
            string ip=ipa.ToString();

            CTAdoptPet adoptPet = new CTAdoptPet();
            adoptPet.AddressID = addressID;
            adoptPet.PetCategoryID = categoryID;
            adoptPet.AdoptID = adoptID;
            adoptPet.AdoptInfo = content;
            adoptPet.AdoptTime = DateTime.Now;
            adoptPet.LastEditTime = DateTime.Now;
            adoptPet.AdoptTitle = title;
            adoptPet.FocusNum = 0;
            adoptPet.IP = ip;
            adoptPet.IsVisible = true;
            adoptPet.PriorityScore = 0;
            adoptPet.WeiBoID = "";
            adoptPet.UserID = userID;
            adoptPet.IsAdopt = isAdopt;

            AdoptPet adoptPetone = new AdoptPet();
            int insertStatus = 0;
            insertStatus=adoptPetone.InsertAdoptPet(adoptPet);
            if (insertStatus == 1)
            {
                Response.Write("<script>alert('添加成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败!')</script>");
            }

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {

            BindGrid();

        }
        private void BindGrid()
        {
            AdoptPet adopet = new AdoptPet();
            GridView1.DataSource = adopet.GetPetAdoptPetList();
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
        private void LoadArea()
        {
            List<CTAddress> addressList = new List<CTAddress>();
            Address address = new Address();
            addressList = address.GetAllUserList();
            ddlAddress.DataSource = addressList;
            ddlAddress.DataTextField = "City";
            ddlAddress.DataValueField = "AddressID";
            ddlAddress.DataBind();
            ddlAddressAdd.DataSource = addressList;
            ddlAddressAdd.DataTextField = "City";
            ddlAddressAdd.DataValueField = "AddressID";
            ddlAddressAdd.DataBind();
        }

        private void LoadPetCategory()
        {
            List<CTPetCategory> petcategoryList = new List<CTPetCategory>();
            PetCategory petcategory = new PetCategory();
            petcategoryList = petcategory.GetPetCategoryList();
            ddlPetCategory.DataSource = petcategoryList;
            ddlPetCategory.DataTextField = "petCategoryName";
            ddlPetCategory.DataValueField = "petCaregoryID";
            ddlPetCategory.DataBind();
            ddlCategoryAdd.DataSource = petcategoryList;
            ddlCategoryAdd.DataTextField = "petCategoryName";
            ddlCategoryAdd.DataValueField = "petCaregoryID";
            ddlCategoryAdd.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindGrid();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {

        }
    }
}