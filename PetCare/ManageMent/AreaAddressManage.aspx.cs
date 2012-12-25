using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.Model;
using PetCare.BLL;

namespace PetCare.ManageMent
{
    public partial class AreaAddressManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            
            string province = tbProvince.Text.Trim().ToString();
            string area = tbArea.Text.Trim().ToString();
            string addressID = tbPostCode.Text.Trim().ToString();
            CTAddress address = new CTAddress();
            address.AddressID = addressID;
            address.Province = province;
            address.City = area;
            Address caddress = new Address();
            int insertStatus=caddress.InsertAddressInfo(address);
            if (insertStatus != 0)
            {
                LoadData();
                Response.Write("<script>alert('添加成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败!')</script>");
            }

        }

        private void LoadData()
        {
            List<CTAddress> list = new List<CTAddress>();
            Address address = new Address();
            list = address.GetAllUserList();
            GridView1.DataSource = list;
            GridView1.DataKeyNames = new string[] { "AddressID" };
            GridView1.DataBind();
        }

        //单击删除按钮
        protected void BtnDelete_Click(object sender, EventArgs e)
        {

            Address address = new Address();
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBoxs");
                if (cbox.Checked == true)
                {
                    string sqlstr = GridView1.DataKeys[i].Value.ToString();
                    address.DeleteAddressInfo(sqlstr);
                }
            }
            LoadData();
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            CheckBoxAll.Checked = false;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBoxs");
                cbox.Checked = false;
            }
        }

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




        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            LoadData();
        }

        //单击编辑按钮
        protected void BtnEdit_Click1(object sender, EventArgs e)
        {
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBoxs");
                if (cbox.Checked == true)
                {
                    string sqlstr = GridView1.DataKeys[i].Value.ToString();
                    tbEditPostCode.Text = sqlstr;
                    string province = GridView1.Rows[i].Cells[2].Text.ToString();
                    tbEditProvince.Text = province;
                    string city = GridView1.Rows[i].Cells[3].Text.ToString();
                    tbEditCity.Text = city;
                    bool isVisible = bool.Parse(GridView1.Rows[i].Cells[5].Text.ToString());
                    cbIsvisible.Checked = isVisible;
                    
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string addressID = tbEditPostCode.Text.Trim().ToString();
            string province = tbEditProvince.Text.Trim().ToString();
            string city = tbEditCity.Text.Trim().ToString();
            bool isVisible = bool.Parse(cbIsvisible.Checked.ToString());

            CTAddress cta = new CTAddress();
            cta.City = city;
            cta.Province = province;
            cta.AddressID = addressID;
            cta.IsVisible = isVisible;
            Address address = new Address();
           int insertStatus= address.UpdateAddressInfo(cta);
            if (insertStatus != 0)
            {
                LoadData();
                Response.Write("<script>alert('update成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('update失败!')</script>");
            }
        }


     
    }
}