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
            GridView1.DataBind();
            int howmanyPages = 0;
            int a = howmany % perPage;
            if (a>0)
            {
                howmanyPages = int.Parse((howmany / perPage).ToString());
            }
            else
            {
                howmanyPages=int.Parse(((howmany / perPage)+1).ToString());
            }
 
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
    }
}