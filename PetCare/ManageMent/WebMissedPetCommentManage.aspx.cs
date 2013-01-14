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
    public partial class WebMissedPetCommentManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUser();
                LoadMissedArticle();
            }
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

        private void LoadMissedArticle()
        {
            List<CTMissedPetInfo> missList = new List<CTMissedPetInfo>();
            MissedPetInfo missInfo = new MissedPetInfo();
            missList = missInfo.GetPetMissedAllList();
            ddMissList.DataSource = missList;
            ddMissList.DataTextField = "MissTitle";
            ddMissList.DataValueField = "MissId";
            ddMissList.DataBind();
            ddKnowledgeManageList.DataSource = missList;
            ddKnowledgeManageList.DataTextField = "MissTitle";
            ddKnowledgeManageList.DataValueField = "MissId";
            ddKnowledgeManageList.DataBind();
        }

        protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {

        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void BtnEdit_Click1(object sender, EventArgs e)
        {

        }


        //增加一条评论
        protected void BtnAddComment_Click(object sender, EventArgs e)
        {
            //获取本机IP
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipa = ipe.AddressList[0];
            string user = ddUserList.SelectedValue.ToString();
            string missID = ddMissList.SelectedValue.ToString();
            string comment = tbComment.Text.Trim().ToString();

            CTMissedPetInfoComment missPetComment = new CTMissedPetInfoComment();
            missPetComment.CommentID = Guid.NewGuid().ToString();
            missPetComment.CommentTime = DateTime.Now.ToShortDateString();
            missPetComment.CommentWeiBoID = "";
            missPetComment.UserID = user;
            missPetComment.MissID = missID;
            missPetComment.CommentContent = comment;
            missPetComment.IP = ipa.ToString();

            MissedPetComment missComment = new MissedPetComment();
            int insertStatus= missComment.InsertComment(missPetComment);
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
            int pageNumber = int.Parse(ddPages.SelectedValue.ToString());
            string missedID = ddKnowledgeManageList.SelectedValue.ToString();
            GridViewBind(pageNumber, missedID);
        }

        protected void BtnComment_Click(object sender, EventArgs e)
        {
            string missedID = ddKnowledgeManageList.SelectedValue.ToString();
            GridViewBind(1, missedID);
        }

        private void GridViewBind(int pageNumber,string missedID)
        {
            int numberPerPage = CPetCareConfiguration.PetPerPageNumbers;
            MissedPetInfo missedPetInfo = new MissedPetInfo();
            List<CVMissedPetComment> commentList = new List<CVMissedPetComment>();
            int howmany = 0;
            commentList = missedPetInfo.GetPetMissCommentPageList(missedID, pageNumber, numberPerPage, out howmany);
            GridView1.DataSource = commentList;
            GridView1.DataKeyNames = new string[] { "CommentID" };
            GridView1.DataBind();

            int howmanyPages = 0;
            howmanyPages = int.Parse(Math.Ceiling((double)howmany / (double)numberPerPage).ToString());
            List<int> listPage = new List<int>();
            for (int a = 1; a <= howmanyPages; a++)
            {
                listPage.Add(a);
            }
            ddPages.DataSource = listPage;
            ddPages.DataBind();
        }

        protected void CheckBoxAll_CheckedChanged1(object sender, EventArgs e)
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

        //单机取消按钮
        protected void BtnCancel_Click1(object sender, EventArgs e)
        {
            CheckBoxAll.Checked = false;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBox");
                cbox.Checked = false;
            }
        }

        //单击删除按钮
        protected void BtnDelete_Click1(object sender, EventArgs e)
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
            string missID = ddKnowledgeManageList.SelectedValue.ToString();
            GridViewBind(1, missID);
        }

        protected void BtnEdit_Click(object sender, EventArgs e)
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
            MissedPetComment petcomment = new MissedPetComment();
            CTMissedPetInfoComment comment = new CTMissedPetInfoComment();
            comment = petcomment.GetMissPetCommentByCommentID(commentID);
            tbMissID.Text = comment.MissID;
            tbCommentID.Text = comment.CommentID;
            tbCommentTime.Text = comment.CommentTime;
            tbContent.Text = comment.CommentContent;
            tbIP.Text = comment.IP;
            tbUserID.Text = comment.UserID;
            cbIsVisible.Checked = comment.IsVisible;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string missID = tbMissID.Text.Trim().ToString();
            string commentID = tbCommentID.Text.Trim().ToString();
            string commentTime = tbCommentTime.Text.Trim().ToString();
            string commentIP = tbIP.Text.Trim().ToString();
            string commentContent = tbContent.Text.Trim().ToString();
            string commentUser = tbUserID.Text.Trim().ToString();
            bool isVisible = bool.Parse(cbIsVisible.Checked.ToString());
            CTMissedPetInfoComment comment = new CTMissedPetInfoComment();
            comment.MissID = missID;
            comment.CommentContent = commentContent;
            comment.CommentID = commentID;
            comment.IP = commentIP;
            comment.UserID = commentUser;
            comment.CommentTime = commentTime;
            comment.IsVisible = isVisible;
            MissedPetComment missPetCommnet = new MissedPetComment();
            int updateStatus = missPetCommnet.EditKnowledgeComment(comment);
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