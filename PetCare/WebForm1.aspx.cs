using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.BLL;
using PetCare.Model;

namespace PetCare
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<CTKnowledgePet> list = new List<CTKnowledgePet>();
            KnowledgePet aa = new  KnowledgePet();
            list = aa.GetKnowledgePetList();
            GridView1.DataSource = list;
            GridView1.DataBind();
        }
    }
}