﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PetCare.BLL;
using PetCare.Model;

namespace PetCare.Interface
{
    public partial class KnowledgeInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            List<CTKnowledgePet> list = new List<CTKnowledgePet>();
            KnowledgePet knowleget = new KnowledgePet();
            list = knowleget.GetKnowledgePetList();
            GridView1.DataSource = list;
            GridView1.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string userID = string.Empty;
            userID = TextBox1.Text.Trim().ToString();
            List<CTKnowledgePet> list = new List<CTKnowledgePet>();
            User user = new User();
            list = user.GetKnowLedgePetListByUserID(userID);
            GridView2.DataSource = list;
            GridView2.DataBind();
        }
    }
}