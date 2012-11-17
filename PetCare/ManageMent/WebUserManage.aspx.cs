using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.BLL;
using PetCare.Model;

namespace PetCare.ManageMent
{
    public partial class WebUserManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadUser();
        }

        private void LoadUser()
        {
            List<CTUserInfo> userList = new List<CTUserInfo>();
            PetCare.BLL.User user = new User();
            userList = user.GetAllUserList();
            GridViewUsers.DataSource = userList;
            GridViewUsers.DataBind();
        }

        protected void BtnDelete1_Click(object sender, EventArgs e)
        {

        }

        protected void BtnEdit_Click(object sender, EventArgs e)
        {

        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {

        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            string userID = TextBox1.Text.Trim().ToString();
            List<CTUserInfo> userList = new List<CTUserInfo>();
            PetCare.BLL.User user = new User();
            userList = user.GetUserInfoByUserID(userID);
            GridViewUsers.DataSource = userList;
            GridViewUsers.DataBind();
        }

        protected void Btn_Click(object sender, EventArgs e)
        {
            string name = tbUserName.Text.Trim().ToString();
            string address = tbUserAddress.Text.Trim().ToString();
            string email = tbUserEmail.Text.Trim().ToString();
            int age = int.Parse(tbUserAge.Text.Trim().ToString());
            string pass = tbUserPass.Text.Trim().ToString();
            string realname = tbUserRealName.Text.Trim().ToString();
            string sex = tbUserSex.Text.Trim().ToString();
            int complaintNumb = int.Parse(tbUserComplaintNumber.Text.Trim().ToString());
            string qqNumb = tbUserQQNumber.Text.Trim().ToString();
            string phoneNumb = tbUserPhoneNumber.Text.Trim().ToString();
            string userInfo = tbUserUserInfo.Text.Trim().ToString();

            CTUserInfo userinfo = new CTUserInfo();
            userinfo.UserName = name;
            userinfo.UserAddress = address;
            userinfo.UserEmail = email;
            userinfo.UserAge = age;
            userinfo.UserPass = pass;
            userinfo.UserRealName = realname;
            userinfo.UserSex = sex;
            userinfo.ComplainNum = complaintNumb;
            userinfo.UserQQNum = qqNumb;
            userinfo.UserInfo = userInfo;
            userinfo.UserPhoneNumber = phoneNumb;

            PetCare.BLL.User user = new User();
            int insertStatus= user.InsertUserInfo(userinfo);
            if (insertStatus > 0)
            {
               
            }
            LoadUser();
            
            
        }

        protected void BtnDelete_Click1(object sender, EventArgs e)
        {
            string deleteID = TextBox2.Text.Trim().ToString();
            PetCare.BLL.User user = new User();
            user.DeleteUserInfo(deleteID);
            LoadUser();
        }
    }
}