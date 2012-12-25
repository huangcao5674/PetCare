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
    public partial class PetCategoryManage : System.Web.UI.Page
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
            string petcategoryID = tbPetCategoryID.Text.Trim().ToString();
            string categoryName = tbCategoryName.Text.Trim().ToString();
            string categoryInfo = tbCategoryInfo.Text.Trim().ToString();

            CTPetCategory category = new CTPetCategory();
            category.petCaregoryID = petcategoryID;
            category.petCategoryName = categoryName;
            category.petCategoryInfo = categoryInfo;

            PetCategory petcategory = new PetCategory();
            int insertStatus = 0;
            insertStatus = petcategory.InsertPetCategory(category);

            if (insertStatus != 0)
            {
                Response.Write("<script>alert('添加成功!')</script>");
            }
            else
            {
                Response.Write("<script>alert('添加失败!')</script>");
            }

        }

        private void LoadData()
        {
            List<CTPetCategory> list = new List<CTPetCategory>();

            PetCategory petcategory = new PetCategory();
            list=petcategory.GetPetCategoryList();
            GridView1.DataSource = list;
            GridView1.DataKeyNames = new string[] { "petCaregoryID" };
            GridView1.DataBind();
        }

        //单击下一页
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            this.GridView1.PageIndex = e.NewPageIndex;
            LoadData();
        }

        //单击取消按钮
        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            CheckBoxAll.Checked = false;
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBoxs");
                cbox.Checked = false;
            }
        }

        //单击删除按钮
        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            PetCategory petcategory = new PetCategory();
            for (int i = 0; i <= GridView1.Rows.Count - 1; i++)
            {
                CheckBox cbox = (CheckBox)GridView1.Rows[i].FindControl("CheckBoxs");
                if (cbox.Checked == true)
                {
                    string sqlstr = GridView1.DataKeys[i].Value.ToString();
                    petcategory.DeletePetCategory(sqlstr);
                }
            }
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
                    tbEditPetCategoryID.Text = sqlstr;
                    string categoryName = GridView1.Rows[i].Cells[2].Text.ToString();
                    tbEditPetCategoryName.Text= categoryName;
                    string petCategoryInfo = GridView1.Rows[i].Cells[3].Text.ToString();
                    tbCategoryInfo.Text = petCategoryInfo;
                    bool isVisible = bool.Parse(GridView1.Rows[i].Cells[4].Text.ToString());
                    cbIsvisible.Checked = isVisible;

                }
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

        //单击save按钮
        protected void btnSave_Click(object sender, EventArgs e)
        {
            string petCategoryID = tbEditPetCategoryID.Text.Trim().ToString();
            string petCategoryInfo = tbEditPetCategoryInfo.Text.Trim().ToString();
            string petCategoryName=tbEditPetCategoryName.Text.Trim().ToString();
            bool isVisible = bool.Parse(cbIsvisible.Checked.ToString());

            CTPetCategory tpetcategory = new CTPetCategory();
            tpetcategory.petCaregoryID = petCategoryID;
            tpetcategory.petCategoryInfo = petCategoryInfo;
            tpetcategory.petCategoryName = petCategoryName;
            tpetcategory.IsVisible = isVisible;

            PetCategory petcategory = new PetCategory();
            int insertStatus = petcategory.EditPetCategory(tpetcategory);
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