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
    public partial class WebKnowledgeCommentManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadKnowledgeList();
                LoadUser();
            }
        }

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

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            CheckBoxAll.Checked = false;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox");
                cbox.Checked = false;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            KnowledgePetComment knowledgePetComment = new KnowledgePetComment();
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox");
                if (cbox.Checked == true)
                {
                    string sqlstr = GridView1.DataKeys[i].Value.ToString();
                    
                }
            }
            string knowledgeID = ddKnowledgeList.SelectedValue.ToString();
            GridViewBind(1, knowledgeID);
        }

        //编辑按钮单机事件
        protected void BtnEdit_Click1(object sender, EventArgs e)
        {
            string commentID = string.Empty;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox");
                if (cbox.Checked == true)
                {
                    commentID = GridView1.DataKeys[i].Value.ToString();
                    break;
                }
            }
            KnowledgePetComment petcomment = new KnowledgePetComment();
            CTKnowledgePetComment comment = new CTKnowledgePetComment();
            comment = petcomment.GetKnowledgePetCommentByCommentID(commentID);
            tbKnowledgeID.Text = comment.KnwoledgeID;
            tbCommentID.Text = comment.CommentID;
            tbCommentTime.Text = comment.CommentTime;
            tbContent.Text = comment.CommentContent;
            tbIP.Text = comment.IP;
            tbUserID.Text = comment.UserID;
            cbIsVisible.Checked = comment.IsVisible;
        }

        protected void BtnComment_Click(object sender, EventArgs e)
        {
            string knowledgeID = ddKnowledgeManageList.SelectedValue.ToString();
            GridViewBind(1, knowledgeID);
        }

        private void GridViewBind(int pageNumb,string knowledgeID)
        {
            KnowledgePet knowledgepet = new KnowledgePet();
            List<CVKnowledgePetComment> list = new List<CVKnowledgePetComment>();
            int perPage = CPetCareConfiguration.PetPerPageNumbers;
            int howmany;
            list = knowledgepet.GetPetKnowledgeCommentPerPageList(knowledgeID, pageNumb, perPage, out howmany);
            int howmanyPages = 0;
            howmanyPages = int.Parse(Math.Ceiling((double)howmany / (double)perPage).ToString());
            List<int> listPage = new List<int>();
            for (int a = 1; a <= howmanyPages; a++)
            {
                listPage.Add(a);
            }
            ddPages.DataSource = listPage;
            ddPages.DataBind();
            
            GridView1.DataSource = list;
            GridView1.DataKeyNames = new string[] { "CommentID" };
            GridView1.DataBind();
        }




        private void LoadKnowledgeList()
        {
            List<CTKnowledgePet> knowledgeList = new List<CTKnowledgePet>();
            KnowledgePet knowledgePet = new KnowledgePet();
            knowledgeList = knowledgePet.GetKnowledgePetList();
            ddKnowledgeManageList.DataSource = knowledgeList;
            ddKnowledgeManageList.DataTextField = "KnowledgeTitle";
            ddKnowledgeManageList.DataValueField = "KnowledgeID";
            ddKnowledgeManageList.DataBind();
            ddKnowledgeList.DataSource = knowledgeList;
            ddKnowledgeList.DataTextField = "KnowledgeTitle";
            ddKnowledgeList.DataValueField = "KnowledgeID";
            ddKnowledgeList.DataBind();
        }
        private void LoadUser()
        {
            List<CTUserInfo> userList = new List<CTUserInfo>();
            User user = new User();
            userList = user.GetAllUserList();
            ddUserList.DataSource = userList;
            ddUserList.DataTextField = "UserName";
            ddUserList.DataValueField = "UserID";
            ddUserList.DataBind();
        }


        //增加一条评论信息
        protected void BtnAddComment_Click(object sender, EventArgs e)
        {
            //获取本机IP
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipa = ipe.AddressList[0];
            string UserID = ddUserList.SelectedValue.ToString();
            string knowledgeID = ddKnowledgeList.SelectedValue.ToString();
            string commentContent = tbComment.Text.Trim().ToString();
            CTKnowledgePetComment knowledgeComment = new CTKnowledgePetComment();
            knowledgeComment.CommentID = Guid.NewGuid().ToString();
            knowledgeComment.CommentContent = commentContent;
            knowledgeComment.CommentTime = DateTime.Now.ToString();
            knowledgeComment.IsVisible = true;
            knowledgeComment.UserID = UserID;
            knowledgeComment.KnwoledgeID = knowledgeID;
            knowledgeComment.IP = ipa.ToString();

            KnowledgePetComment CknowledgePetCommnet=new KnowledgePetComment();
            int insertStatus = 0;
            insertStatus=CknowledgePetCommnet.InsertComment(knowledgeComment);
            if (insertStatus == 1)
            {
                Response.Write("<script>alert('添加成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败!')</script>");
            }
        }

        protected void BtnView_Click(object sender, EventArgs e)
        {
            string knowledgeID=ddKnowledgeList.SelectedValue.ToString();
            int page=int.Parse(ddPages.SelectedValue.ToString());
            GridViewBind(page, knowledgeID);
        }

        //保存按钮事件
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string knowledgeID = tbKnowledgeID.Text.Trim().ToString();
            string commentID = tbCommentID.Text.Trim().ToString();
            string commentTime = tbCommentTime.Text.Trim().ToString();
            string commentIP = tbIP.Text.Trim().ToString();
            string commentContent = tbContent.Text.Trim().ToString();
            string commentUser = tbUserID.Text.Trim().ToString();
            bool isVisible = bool.Parse(cbIsVisible.Checked.ToString());
            CTKnowledgePetComment comment = new CTKnowledgePetComment();
            comment.KnwoledgeID = knowledgeID;
            comment.CommentContent = commentContent;
            comment.CommentID = commentID;
            comment.IP = commentIP;
            comment.UserID = commentUser;
            comment.CommentTime = commentTime;
            comment.IsVisible = isVisible;
            KnowledgePetComment knowledgePetCommnet = new KnowledgePetComment();
            int updateStatus = knowledgePetCommnet.EditKnowledgeComment(comment);
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