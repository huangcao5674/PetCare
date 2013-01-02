using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.BLL;
using PetCare.Model;
using System.Net;
using PetCare.DBUtility;

namespace PetCare.ManageMent
{
    public partial class WebAdoptManage : System.Web.UI.Page
    {
        private static bool isUserSession = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUser();
                LoadArea();
                LoadAdopt();
                LoadPetCategory();
                BindGridNew(1);
            }
            
            //Label1.Text = CheckUser();
        }


        //登出功能
        //protected void BtnLogOff_Click(object sender, EventArgs e)
        //{
        //    UserOut();
        //}

        public static void UserOut()
        {
            System.Web.HttpContext.Current.Session["UserName"] = null;
            System.Web.HttpContext.Current.Response.Cookies["UserName"].Value = null;
        }

        public static string CheckUser()
        {
            if (isUserSession)
            {
                if (System.Web.HttpContext.Current.Session["UserName"] == null)
                    //没有登录
                    return null;
                else
                {
                    //返回信息
                    string info = System.Web.HttpContext.Current.Session["UserName"].ToString();
                    //info = Encryptor.Decrypt(info);
                    //判断信息是否正确
                    if (info.Length ==0)
                        //信息不正确
                        return null;
                    
                    return info;
                }
            }
            else
            {
                if (System.Web.HttpContext.Current.Request.Cookies ["UserName"] == null)
                    //没有登录
                    return null;
                else
               {
                    //返回信息
                    string info = System.Web.HttpContext.Current.Request.Cookies["UserName"].Value;
                    //判断信息是否正确
                    if (info.Length ==0)
                        //信息不正确
                        return null;
                    
                    return info;
                }
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



        private void BindGridNew(int pageNumber)
        {
            int perPage = CPetCareConfiguration.PetPerPageNumbers;
            AdoptPet adopt = new AdoptPet();
            int howmany = 0;
            GridView1.DataSource = adopt.GetPetAdoptPerPageList(pageNumber, perPage, out howmany);
            int howmanyPages = int.Parse((howmany / perPage).ToString());
            List<int> list = new List<int>();
            for(int a=1;a<=howmanyPages;a++)
            {
                list.Add(a);
            }
            ddPages.DataSource = list;
            ddPages.DataBind();
            GridView1.DataBind();
        }

        private void BindGrid()
        {
            AdoptPet adopet = new AdoptPet();
            GridView1.DataSource = adopet.GetPetAdoptPetList();
            GridView1.DataBind();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string delAdoptID= GridView1.DataKeys[e.RowIndex].Value.ToString() ;
            AdoptPet adoptPetone = new AdoptPet();
            adoptPetone.DeleteAdoptPet(delAdoptID);
        }


        //加载当前用户load用户信息
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
            ddlAddress.Items.Insert(0, new ListItem("", ""));

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
        }
        private void LoadPetCategory()
        {
            List<CTPetCategory> petcategoryList = new List<CTPetCategory>();
            PetCategory petcategory = new PetCategory();
            petcategoryList = petcategory.GetPetCategoryList();
            ddlPetCategory.DataSource = petcategoryList;
            ddlPetCategory.DataTextField = "petCategoryName";
            ddlPetCategory.DataValueField = "petCategoryID";
            ddlPetCategory.DataBind();
            ddlPetCategory.Items.Insert(0, new ListItem("", ""));

            ddlCategoryAdd.DataSource = petcategoryList;
            ddlCategoryAdd.DataTextField = "petCategoryName";
            ddlCategoryAdd.DataValueField = "petCategoryID";
            ddlCategoryAdd.DataBind();
        }


        //根据地区和类型进行检索
        protected void Button1_Click(object sender, EventArgs e)
        {
            string address = ddlAddress.SelectedValue.ToString();
            string petcategory = ddlPetCategory.SelectedValue.ToString();
            if (address == "")
            {
                address = "NULL";
            }
            if (petcategory == "")
            {
                petcategory = "NULL";
            }
            bool isAdopt=bool.Parse(ckIsAdopt.Checked.ToString());
            int perPageNumb=CPetCareConfiguration.PetPerPageNumbers;
            int pageNumb=1;
            int howmanyPages=0;
            AdoptPet adoptpet = new AdoptPet();
            List<CVAdoptPet>list=new List<CVAdoptPet>();
            list=adoptpet.GetPetAdoptPetListByAddressID(isAdopt,address,petcategory, pageNumb, perPageNumb, out howmanyPages);
            GridView1.DataSource = list;
            GridView1.DataBind();
        }



        protected void BtnNull_Click(object sender, EventArgs e)
        {
            GridView1.DataSource = null;
            GridView1.DataBind();
        }

        protected void BtnLook_Click(object sender, EventArgs e)
        {
            int value = int.Parse(ddPages.SelectedValue.ToString());
            BindGridNew(value);
        }
    }
}