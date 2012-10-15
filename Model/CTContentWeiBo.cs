using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace PetCare.Model
{
    [Serializable]
    [Table(Name="DB_ContentWeiBo")]
    public class CTContentWeiBo
    {
        public CTContentWeiBo()
        {
        }
        public CTContentWeiBo(string weiBoID,int userID,string weiboContent)
        {
            this.WeiBoID = weiBoID;
            this.UserID = userID;
            this.WeiboContent = weiboContent;
        }
        public string WeiBoID
        {
            get;
            set;
        }
        public int UserID
        {
            get;
            set;
        }
        public string WeiboContent
        {
            get;
            set;
        }
    }
}
