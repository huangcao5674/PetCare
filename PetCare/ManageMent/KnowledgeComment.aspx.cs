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
    public partial class KnowledgeComment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LoadKnowledge();
                LoadUser();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string knowledgeID = DropDownList1.SelectedValue.ToString();
            KnowledgePetComment comment = new KnowledgePetComment();
            List<CTKnowledgePetComment> list = new List<CTKnowledgePetComment>();
            list = comment.GetAllCommentByKnowledge(knowledgeID);
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
        private void LoadKnowledge()
        {
            KnowledgePet knowledge = new KnowledgePet();
            List<CTKnowledgePet> list = new List<CTKnowledgePet>();
            list=knowledge.GetKnowledgePetList();
            DropDownList1.DataSource = list;
            DropDownList1.DataTextField = "KnowledgeTitle";
            DropDownList1.DataValueField = "KnowledgeID";
            DropDownList1.DataBind();
        }

        private void LoadUser()
        {
            User user = new User();
            List<CTUserInfo> list = new List<CTUserInfo>();
            list = user.GetAllUserList();
            DropDownList2.DataSource = list;
            DropDownList2.DataTextField = "UserName";
            DropDownList2.DataValueField = "UserID";
            DropDownList2.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/WebForm1.aspx", false); 
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            //获取本机IP
            IPHostEntry ipe = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipa = ipe.AddressList[0];
            string content = tb_Conetent.Text.Trim().ToString();
            string userID = DropDownList2.SelectedValue;
            string knowledgeID = DropDownList1.SelectedValue;
            string commentID=Guid.NewGuid().ToString();
            string ip = ipa.ToString();
            bool visible = true;
            CTKnowledgePetComment comment = new CTKnowledgePetComment();
            comment.IsVisible = visible;
            comment.KnwoledgeID = knowledgeID;
            comment.UserID = userID;
            comment.CommentID = commentID;
            comment.CommentContent = content;
            comment.CommentTime = DateTime.Now.ToString(); ;
            comment.IP = ip;
            KnowledgePetComment knowledgecomment = new KnowledgePetComment();
            int insertStatus=  knowledgecomment.InsertComment(comment);
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