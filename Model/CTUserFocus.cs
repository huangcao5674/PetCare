using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetCare.Model
{
    //用户收藏的文章
    public class CTUserFocus
    {
       public string FocusID { get; set; }
       public string UserID { get; set; }
       public string FocusType { get; set; }
       public string ArticleID { get; set; }
    }
}
