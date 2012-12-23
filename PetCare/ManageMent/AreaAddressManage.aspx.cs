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
            LoadData();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            string province = tbProvince.Text.Trim().ToString();
            string area = tbArea.Text.Trim().ToString();
        }

        private void LoadData()
        {
            List<CTAddress> list = new List<CTAddress>();
            Address address = new Address();
            list = address.GetAllUserList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }
}