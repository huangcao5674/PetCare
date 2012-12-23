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
            LoadData();
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
            GridView1.DataBind();
        }
    }
}