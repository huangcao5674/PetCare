using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.Model;
using PetCare.BLL;
using System.Net;
using PetCare.DBUtility;

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
                BindGridNew(1);
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
            ddlAddress.DataSource = addressList;
            ddlAddress.DataTextField = "City";
            ddlAddress.DataValueField = "AddressID";
            ddlAddress.DataBind();
            ddlAddress.Items.Insert(0, new ListItem("", ""));
        }

        private void LoadPetCategory()
        {
            List<CTPetCategory> petcategoryList = new List<CTPetCategory>();
            PetCategory petcategory = new PetCategory();
            petcategoryList = petcategory.GetPetCategoryList();
            dpCategory.DataSource = petcategoryList;
            dpCategory.DataTextField = "petCategoryName";
            dpCategory.DataValueField = "petCategoryID";
            dpCategory.DataBind();
            ddlPetCategory.DataSource = petcategoryList;
            ddlPetCategory.DataTextField = "petCategoryName";
            ddlPetCategory.DataValueField = "petCategoryID";
            ddlPetCategory.DataBind();
            ddlPetCategory.Items.Insert(0, new ListItem("", ""));
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
            knowledge.PetCategoryID = petcategoryID;
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


        //分页检索数据
        protected void BtnCheckData_Click(object sender, EventArgs e)
        {
            int value = int.Parse(ddPage.SelectedValue.ToString());
            BindGridNew(value);
        }

        private void BindGridNew(int pageNumber)
        {
            int perPage = CPetCareConfiguration.PetPerPageNumbers;
            List<CVKnowledgePet> list = new List<CVKnowledgePet>();
            KnowledgePet knowleget = new KnowledgePet();
            int howmany = 0;
            list = knowleget.GetPetKnowledgePerPageList(pageNumber, perPage, out howmany);
            GridView1.DataSource = list;
            GridView1.DataKeyNames = new string[] { "KnowledgeID"};
            GridView1.DataBind();
            int howmanyPages = 0;

            howmanyPages = int.Parse(Math.Ceiling((double)howmany / (double)perPage).ToString());
            List<int> listPage = new List<int>();
            for (int b = 1; b <= howmanyPages; b++)
            {
                listPage.Add(b);
            }
            ddPage.DataSource = listPage;
            ddPage.DataBind();
        }


        //根据条件检索
        protected void BtnSearch_Click(object sender, EventArgs e)
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
        }


        //单击全选按钮
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

        //单机删除按钮
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            KnowledgePet knowledgePet = new KnowledgePet();
            int selectNumber = 0;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBoxs");
                if (cbox.Checked == true)
                {
                    string sqlstr = GridView1.DataKeys[i].Value.ToString();
                    knowledgePet.DeleteKnowledgePet(sqlstr);
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
                KnowledgePet knowledgePet = new KnowledgePet();
                CTKnowledgePet knowledgetable = new CTKnowledgePet();
                knowledgetable = knowledgePet.GetKnowledgePetByKnowledgeID(sqlstr);
                TextBox_KnowledgeID.Text = knowledgetable.KnowledgeID;
                TextBox_MissIDInfo.Text = knowledgetable.KnowledgeInfo;
                TextBox_AddressID.Text = knowledgetable.AddressID;
                TextBox_KnowledgeTime.Text = knowledgetable.KnowledgeTime.ToString();
                TextBox_KnowledgeTitle.Text = knowledgetable.KnowledgeTitle.ToString();
                TextBox_FocusNum.Text = knowledgetable.FocusNum.ToString();
                TextBox_IP.Text = knowledgetable.IP.ToString();
                TextBox_PetCategoryID.Text = knowledgetable.PetCategoryID.ToString();
                TextBox_PriorityScore.Text = knowledgetable.PriorityScore.ToString();
                TextBox_UserID.Text = knowledgetable.UserID.ToString();
                TextBox_WeiBoID.Text = knowledgetable.WeiBoID.ToString();
            }

        }

        protected void Btn_Save_Click(object sender, EventArgs e)
        {
            if (TextBox_KnowledgeID.Text == "")
            {
                Response.Write("<script>alert('请选择一个编辑!')</script>");
            }
            else
            {
                CTKnowledgePet knowledgetable = new CTKnowledgePet();
                knowledgetable.KnowledgeID = TextBox_KnowledgeID.Text;
                knowledgetable.KnowledgeInfo = TextBox_MissIDInfo.Text;
                knowledgetable.AddressID = TextBox_AddressID.Text;
                knowledgetable.KnowledgeTime = TextBox_KnowledgeTime.Text.ToString();
                knowledgetable.KnowledgeTitle = TextBox_KnowledgeTitle.Text.ToString();
                knowledgetable.FocusNum = int.Parse(TextBox_FocusNum.Text.ToString());
                knowledgetable.IP = TextBox_IP.Text.ToString();
                knowledgetable.PetCategoryID = TextBox_PetCategoryID.Text.ToString();
                knowledgetable.PriorityScore = int.Parse(TextBox_PriorityScore.Text.ToString());
                knowledgetable.UserID = TextBox_UserID.Text.ToString();
                knowledgetable.WeiBoID = TextBox_WeiBoID.Text.ToString();
                knowledgetable.LastEditTime = DateTime.Now.ToShortDateString();
                KnowledgePet knowledgepet = new KnowledgePet();
                int editStatus = 0;
                editStatus = knowledgepet.EditKnowledgePet(knowledgetable);
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