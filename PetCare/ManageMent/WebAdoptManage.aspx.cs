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
                LoadAdopt();
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
            adoptPet.AdoptTime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
            adoptPet.LastEditTime = DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss");
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

            //BindGrid();
            int pageNumber = int.Parse(TextBox1.Text.Trim().ToString());
            int perPage = int.Parse(TextBox2.Text.Trim().ToString());
            BindGridNew(pageNumber, perPage);
        }
        private void BindGrid()
        {
            AdoptPet adopet = new AdoptPet();
            GridView1.DataSource = adopet.GetPetAdoptPetList();
            GridView1.DataBind();
        }


        private void BindGridNew(int pageNumber,int perPage)
        {
            AdoptPet adopt = new AdoptPet();
            int howmany=0;
            GridView1.DataSource =  adopt.GetPetAdoptPerPageList(pageNumber,perPage,out howmany);
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
            ddUser11.DataSource = userList;
            ddUser11.DataTextField = "UserName";
            ddUser11.DataValueField = "UserID";
            ddUser11.DataBind();
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
        private void LoadAdopt()
        {
            List<CTAdoptPet> LIST = new List<CTAdoptPet>();
            AdoptPet aa = new AdoptPet();
            LIST = aa.GetPetAdoptPetList();
            ddAdopt.DataSource = LIST;
            ddAdopt.DataTextField = "AdoptTitle";
            ddAdopt.DataValueField = "AdoptID";
            ddAdopt.DataBind();
            ddAdopt1.DataSource = LIST;
            ddAdopt1.DataTextField = "AdoptTitle";
            ddAdopt1.DataValueField = "AdoptID";
            ddAdopt1.DataBind();
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


        //根据地区和类型进行检索
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void BtnNull_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
            GridView2.DataSource = null;
            GridView2.DataBind();
        }



        protected void BtnChekc_Click(object sender, EventArgs e)
        {
            int pageNumb = int.Parse(TextBoxPageNumber.Text.Trim().ToString());
            int perNumb = int.Parse(TextBoxPerPage.Text.Trim().ToString());
            AdoptPet adopt = new AdoptPet();
            string adoptID = ddAdopt.SelectedValue.ToString();
            List<CVAdoptPetComment> list = new List<CVAdoptPetComment>();
            int howmanyPages = 0;
            list = adopt.GetPetAdoptCommentPerPageList(adoptID, pageNumb, perNumb, out howmanyPages);
            GridView2.DataSource = list;
            GridView2.DataBind();
        }

        protected void BtnAddComment_Click(object sender, EventArgs e)
        {
            //获取本机IP
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipa = ipe.AddressList[0];
            string comment = TextBoxComment.Text.Trim().ToString();
            string userID = ddUser11.SelectedValue.ToString();
            string adoptID = ddAdopt1.SelectedValue.ToString();
            CTAdoptPetComment adoptComment = new CTAdoptPetComment();
            adoptComment.AdoptID = adoptID;
            adoptComment.CommentContent = comment;
            adoptComment.CommentID = Guid.NewGuid().ToString();
            adoptComment.CommentTime = DateTime.Now.ToString();
            adoptComment.IsVisible = true;
            adoptComment.UserID = userID;
            adoptComment.IP = ipa.ToString();
            AdoptPetComment ado = new AdoptPetComment();
            int insertStatus = 0;
            insertStatus = ado.InsertComment(adoptComment);
            if (insertStatus == 1)
            {
                Response.Write("<script>alert('添加成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败!')</script>");
            }
        }
    }
}