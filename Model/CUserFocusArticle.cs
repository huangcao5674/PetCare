using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetCare.Model
{
    public class CUserFocusArticle
    {
       public  string userID { get; set; }
       public string userName { get; set; }
       public  string deployTime { get; set; }
       public string articleTitle { get; set; }
       public string articleType { get; set; }
       public string aritcleInfo { get; set; }
       public int focusNum { get; set; }
    }
}
