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
            string adoptID = ddAdopt.SelectedValue.ToString();
            GridBindData(1,adoptID);
        }

        private void GridBindData(int pageNumb,string adoptID)
        {
            int perPage = CPetCareConfiguration.PetPerPageNumbers;
            AdoptPet adopt = new AdoptPet();
            List<CVAdoptPetComment> listData = new List<CVAdoptPetComment>();
            int howmany = 0;
            listData = adopt.GetPetAdoptCommentPerPageList(adoptID, pageNumb, perPage, out howmany);
            int howmanyPages = 0;
            howmanyPages=int.Parse(Math.Ceiling((double)howmany / (double)perPage).ToString());
            List<int> list = new List<int>();
            for (int a = 1; a <= howmanyPages; a++)
            {
                list.Add(a);
            }
            ddPages.DataSource = list;
            ddPages.DataBind();
            GridView1.DataSource = listData;
            GridView1.DataKeyNames = new string[] { "CommentID" };
            GridView1.DataBind();
        }


        //选择所有
        protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox");
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
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox");
                cbox.Checked = false;
            }
        }

        //删除
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            AdoptPetComment petcomment = new AdoptPetComment();
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox");
                if (cbox.Checked == true)
                {
                    string sqlstr = GridView1.DataKeys[i].Value.ToString();
                    petcomment.DeleteAdoptComment(sqlstr);
                }
            }
            string adoptID = ddAdopt.SelectedValue.ToString();
            GridBindData(1, adoptID);
        }

        //编辑
        protected void BtnEdit_Click1(object sender, EventArgs e)
        {
            string commentID=string.Empty;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox");
                if (cbox.Checked == true)
                {
                     commentID = GridView1.DataKeys[i].Value.ToString();
                    break;
                }
            }
            AdoptPetComment petcomment = new AdoptPetComment();
            CTAdoptPetComment comment = new CTAdoptPetComment();
            comment = petcomment.GetAdoptCommentByCommentID(commentID);
            tbAdoptID.Text = comment.AdoptID;
            tbCommentID.Text = comment.CommentID;
            tbCommentTime.Text = comment.CommentTime;
            tbContent.Text = comment.CommentContent;
            tbIP.Text = comment.IP;
            tbUserID.Text = comment.UserID;
            cbIsVisible.Checked = comment.IsVisible;

            
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            int pageNumb =Int16.Parse(ddPages.SelectedValue.ToString());
            string adoptID = ddAdopt.SelectedValue.ToString();
            GridBindData(pageNumb, adoptID);
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string adoptID = tbAdoptID.Text.Trim().ToString();
            string commentID = tbCommentID.Text.Trim().ToString();
            string commentTime = tbCommentTime.Text.Trim().ToString();
            string commentIP = tbIP.Text.Trim().ToString();
            string commentContent = tbContent.Text.Trim().ToString();
            string commentUser=tbUserID.Text.Trim().ToString();
            bool isVisible= bool.Parse(cbIsVisible.Checked.ToString());
            CTAdoptPetComment comment = new CTAdoptPetComment();
            comment.AdoptID = adoptID;
            comment.CommentContent = commentContent;
            comment.CommentID = commentID;
            comment.IP = commentIP;
            comment.UserID = commentUser;
            comment.CommentTime = commentTime;
            comment.IsVisible = isVisible;
            AdoptPetComment adoptpetCommnet = new AdoptPetComment();
            int updateStatus = adoptpetCommnet.EditAdoptComment(comment);
            if (updateStatus == 1)
            {
                Response.Write("<script>alert('保存成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('保存失败!')</script>");
            }
        }
    }
}