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
            if (!IsPostBack)
            {
                LoadUser();
            }
        }

        private void LoadUser()
        {
            List<CTUserInfo> userList = new List<CTUserInfo>();
            PetCare.BLL.User user = new User();
            userList = user.GetAllUserList();
            GridViewUsers.DataSource = userList;
            GridViewUsers.DataKeyNames =new string[]{ "UserID"};
            GridViewUsers.DataBind();
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
            userinfo.UserPass = "";
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

        protected void CheckBoxAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i <= GridViewUsers.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridViewUsers.Rows[i].FindControl("CheckBoxs");
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
            for (int i = 0; i <= GridViewUsers.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridViewUsers.Rows[i].FindControl("CheckBoxs");
                cbox.Checked = false;
            }
        }

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

        }

        protected void BtnEdit_Click1(object sender, EventArgs e)
        {
            for (int i = 0; i <= GridViewUsers.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridViewUsers.Rows[i].FindControl("CheckBoxs");
                if (cbox.Checked == true)
                {
                    string userID = GridViewUsers.DataKeys[i].Value.ToString();
                    User user = new User();
                    CTUserInfo userinfo = new CTUserInfo();
                    userinfo = user.GetUserInfoByUserID(userID).First();

                    //tbUserId.Text = userID;
                    //string userName = GridViewUsers.Rows[i].Cells[2].Text.ToString();
                    //tbUserName.Text = userName;
                    //string UserRealName = GridViewUsers.Rows[i].Cells[3].Text.ToString();
                    //tbUserRealName.Text = UserRealName;
                    //string userage = GridViewUsers.Rows[i].Cells[4].Text.ToString();
                    //tbUserAge.Text = userage;
                    //string usersex = GridViewUsers.Rows[i].Cells[5].Text.ToString();
                    //tbUserSex.Text = usersex;
                    //string userAddress = GridViewUsers.Rows[i].Cells[6].Text.ToString();
                    //tbUserAddress.Text = userAddress;
                    //string userEmail = GridViewUsers.Rows[i].Cells[7].Text.ToString();
                    //tbUserEmail.Text = userEmail;

                    tbUserId.Text = userID;
                    tbUserName.Text = userinfo.UserName;
                    tbUserRealName.Text = userinfo.UserRealName;
                    tbUserAge.Text = userinfo.UserAge.ToString();
                    tbUserSex.Text = userinfo.UserSex;
                    tbUserAddress.Text =userinfo.UserAddress;
                    tbUserEmail.Text = userinfo.UserEmail;
                    tbUserWeiBo.Text = userinfo.UserWeiBo;
                    tbUserQQNumber.Text = userinfo.UserQQNum;
                    tbUserLevel.Text = userinfo.UserLevel;
                    tbUserUserInfo.Text = userinfo.UserInfo;
                    tbUserComplaintNumber.Text = userinfo.ComplainNum.ToString();
                    tbPortrait.Text = userinfo.Portrait;
                    tbRoldID.Text = userinfo.RoldID;
                    tbLastLoginTime.Text = userinfo.LastLoginTime;
                    tbLoginTimes.Text = userinfo.LoginTimes.ToString();
                    tbModifyTime.Text = userinfo.ModifyTime;
                    tbCreateTime.Text = userinfo.CreateTime;
                    tbIsUsed.Text = userinfo.IsUsed.ToString();
                   

                }
            }
        }

        protected void GridViewUsers_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewUsers.PageIndex = e.NewPageIndex;
            LoadUser();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string userID = tbUserId.Text.Trim().ToString();
            string userName = tbUserName.Text.Trim().ToString();
            string userRealName = tbUserRealName.Text.Trim().ToString();
            string userSex = tbUserSex.Text.Trim().ToString();
            string userAge = tbUserAge.Text.Trim().ToString();
            string userAddress = tbUserAddress.Text.Trim().ToString();
            string userEmail = tbUserEmail.Text.Trim().ToString();
            string userPhone = tbUserPhoneNumber.Text.Trim().ToString();
            string userQQNumb = tbUserQQNumber.Text.Trim().ToString();
            string userWeiBo = tbUserWeiBo.Text.Trim().ToString();
        }
    }
}