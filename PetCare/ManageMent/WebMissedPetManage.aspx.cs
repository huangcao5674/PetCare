using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.Model;
using PetCare.BLL;
using PetCare.DBUtility;
using System.Net;

namespace PetCare.ManageMent
{
    public partial class WebMissedPetManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUser();
                LoadArea();
                LoadPetCategory();
                BindGridNew(1);
            }
        }


        //单机根据条件搜索按钮
        protected void BtnSearch_Click(object sender, EventArgs e)
        {

        }

        //单机增加新文章
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string user = ddlUser.SelectedValue.ToString();
            string category = ddlCategoryAdd.SelectedValue.ToString();
            string address = ddlAddressAdd.SelectedValue.ToString();
            string title = tbTitle.Text.Trim().ToString();
            string content = tbContent.Text.Trim().ToString();
            //获取本机IP
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipa = ipe.AddressList[0];
            string ip = ipa.ToString();

            CTMissedPetInfo missedInfo = new CTMissedPetInfo();
            missedInfo.MissId = Guid.NewGuid().ToString();
            missedInfo.IsRecommand = false;
            missedInfo.IsVisible = true;
            missedInfo.IsEssence = false;
            missedInfo.LastEditTime = DateTime.Now.ToShortDateString();
            missedInfo.MissTime = DateTime.Now.ToShortDateString();
            missedInfo.MissTitle = title;
            missedInfo.AddressID = address;
            missedInfo.PetCategoryID = category;
            missedInfo.PriorityScore = 0;
            missedInfo.UserID = user;
            missedInfo.WeiBoID = "";
            missedInfo.MissInfo = content;
            missedInfo.IP = ip;
            missedInfo.FocusNum = 0;
            missedInfo.LinkUrl = "";
            missedInfo.Status = "";
            missedInfo.PicLocation = "";

            MissedPetInfo missedPetInfo = new MissedPetInfo();
            int insertStatus=0;
            insertStatus = missedPetInfo.InsertMissedPetInfo(missedInfo);
            if (insertStatus == 1)
            {
                Response.Write("<script>alert('添加成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败!')</script>");
            }

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


        //查看选定的页面
        protected void BtnLook_Click(object sender, EventArgs e)
        {
            int value = int.Parse(ddPages.SelectedValue.ToString());
            BindGridNew(value);
        }

        private void BindGridNew(int pageNumber)
        {
            int perPage = CPetCareConfiguration.PetPerPageNumbers;
            MissedPetInfo adopt = new MissedPetInfo();
            int howmany = 0;

            GridView1.DataSource = adopt.GetPetMissedPerPageList(pageNumber, perPage, out howmany);
            GridView1.DataKeyNames = new string[] { "MissID"};
            int howmanyPages = 0;

            howmanyPages = int.Parse(Math.Ceiling((double)howmany / (double)perPage).ToString());

            List<int> list = new List<int>();
            for (int a = 1; a <= howmanyPages; a++)
            {
                list.Add(a);
            }
            ddPages.DataSource = list;
            ddPages.DataBind();
            GridView1.DataBind();
        }


        //清空数据信息
        protected void BtnNull_Click(object sender, EventArgs e)
        {

        }

        protected void cb_SelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBoxs");
                if (cb_SelectAll.Checked == true)
                {
                    cbox.Checked = true;
                }
                else
                {
                    cbox.Checked = false;
                }
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            MissedPetInfo missPet = new MissedPetInfo();
            int selectNumber = 0;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBoxs");
                if (cbox.Checked == true)
                {
                    string sqlstr = GridView1.DataKeys[i].Value.ToString();
                    missPet.DeletePetInfo(sqlstr);
                    selectNumber++;
                }
            }
            BindGridNew(1);
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {
            
            int selectNumber = 0;
            string sqlstr = string.Empty;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBoxs");
                if (cbox.Checked == true)
                {
                    sqlstr = GridView1.DataKeys[i].Value.ToString();
                    selectNumber++;
                }
            }
            if (selectNumber > 1 || selectNumber < 1)
            {
                Response.Write("<script>alert('请选择一个!')</script>");
            }
            else
            {
                MissedPetInfo missPet = new MissedPetInfo();
                CTMissedPetInfo ctmiss = new CTMissedPetInfo();
                ctmiss = missPet.GetMissedInfoByMissedID(sqlstr);
                TextBox_MissID.Text = ctmiss.MissId;
                TextBox_MissIDInfo.Text = ctmiss.MissInfo;
                TextBox_AddressID.Text = ctmiss.AddressID;
                TextBox_MissIDTime.Text = ctmiss.MissTime.ToString();
                TextBox_MissIDTitle.Text = ctmiss.MissTitle.ToString();
                TextBox_FocusNum.Text = ctmiss.FocusNum.ToString();
                TextBox_IP.Text = ctmiss.IP.ToString();
                TextBox_PetCategoryID.Text = ctmiss.PetCategoryID.ToString();
                TextBox_PriorityScore.Text = ctmiss.PriorityScore.ToString();
                TextBox_UserID.Text = ctmiss.UserID.ToString();
                TextBox_WeiBoID.Text = ctmiss.WeiBoID.ToString();
            }
        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            if (TextBox_MissID.Text == "")
            {
                Response.Write("<script>alert('请选择一个编辑!')</script>");
            }
            else
            {
                CTMissedPetInfo ctmiss = new CTMissedPetInfo();
                ctmiss.MissId = TextBox_MissID.Text;
                ctmiss.MissInfo = TextBox_MissIDInfo.Text;
                ctmiss.AddressID = TextBox_AddressID.Text;
                ctmiss.MissTime = TextBox_MissIDTime.Text.ToString();
                ctmiss.MissTitle = TextBox_MissIDTitle.Text.ToString();
                ctmiss.FocusNum = int.Parse(TextBox_FocusNum.Text.ToString());
                ctmiss.IP = TextBox_IP.Text.ToString();
                ctmiss.PetCategoryID = TextBox_PetCategoryID.Text.ToString();
                ctmiss.PriorityScore = int.Parse(TextBox_PriorityScore.Text.ToString());
                ctmiss.UserID = TextBox_UserID.Text.ToString();
                ctmiss.WeiBoID = TextBox_WeiBoID.Text.ToString();
                ctmiss.LastEditTime = DateTime.Now.ToShortDateString();
                MissedPetInfo MISSPet = new MissedPetInfo();
                int editStatus = 0;
                editStatus = MISSPet.EditPetInfo(ctmiss);
                if (editStatus == 1)
                {
                    Response.Write("<script>alert('Edit成功!')</script>");
                }
                else
                {
                    Response.Write("<script>alert('Edit失败!')</script>");
                }
            }
        }
    }
}