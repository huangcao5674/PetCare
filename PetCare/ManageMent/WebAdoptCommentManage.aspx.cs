using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using PetCare.DBUtility;
using PetCare.Model;
using PetCare.BLL;

namespace PetCare.ManageMent
{
    public partial class WebAdoptCommentManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUser();
                LoadAdopt();
            }
        }

        private void LoadUser()
        {
            List<CTUserInfo> userList = new List<CTUserInfo>();
            User user = new User();
            userList = user.GetAllUserList();
            ddUser11.DataSource = userList;
            ddUser11.DataTextField = "UserName";
            ddUser11.DataValueField = "UserID";
            ddUser11.DataBind();
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



        protected void BtnChekc_Click(object sender, EventArgs e)
        {
            int pageNumb = int.Parse(TextBoxPageNumber.Text.Trim().ToString());
            string adoptID = ddAdopt.SelectedValue.ToString();
            GridBindData(pageNumb,adoptID);
        }

        private void GridBindData(int pageNumb,string adoptID)
        {
            int perNumb = CPetCareConfiguration.PetPerPageNumbers;
            AdoptPet adopt = new AdoptPet();
            List<CVAdoptPetComment> list = new List<CVAdoptPetComment>();
            int howmanyPages = 0;
            list = adopt.GetPetAdoptCommentPerPageList(adoptID, pageNumb, perNumb, out howmanyPages);
            GridView1.DataSource = list;
            GridView1.DataBind();
        }


        //选择所有
        protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBoxs");
                if (CheckBoxAll.Checked == true)
                {
                    cbox.Checked = true;
                }
                else
                {
                    cbox.Checked = false;
                }
            }
        }

        //取消选择
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            CheckBoxAll.Checked = false;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBoxs");
                cbox.Checked = false;
            }
        }

        //删除
        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        //编辑
        protected void BtnEdit_Click1(object sender, EventArgs e)
        {

        }
    }
}