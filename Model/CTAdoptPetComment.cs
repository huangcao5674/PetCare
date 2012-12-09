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
        //没有写完，以后补上
        public CTAdoptPetComment(string userID,string commentContent)
        {
            UserID = userID;
            CommentContent = commentContent;
        }

        public string CommentID { get; set; }
        public string UserID { get; set; }
        public string CommentTime { get; set; }
        public string IP { get; set; }
        public string CommentContent { get; set; }
        public bool IsVisible { get; set; }
        public string AdoptID { get; set; }
       
    }
}
