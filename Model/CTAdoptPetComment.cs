using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace PetCare.Model
{
    [Serializable]
    [Table(Name="DB_CommentWeiBo")]
    public class CTAdoptPetComment
    {
        public CTAdoptPetComment()
        {
        }
        public CTAdoptPetComment(int userID,string commentContent)
        {
            UserID = userID;
            CommentContent = commentContent;
        }
        public string CommentWeiBoID{ get;set;}
        public int UserID{get;set;}
        public string CommentContent{ get;set;}
       
    }
}
