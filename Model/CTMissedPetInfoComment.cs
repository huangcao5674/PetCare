﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetCare.Model
{
    public class CTMissedPetInfoComment
    {
        public string CommentID { get; set; }
        public string UserID { get; set; }
        public string CommentWeiBoID { get; set; }
        public  string  CommentTime { get; set; }
        public string IP { get; set; }
        public string CommentContent { get; set; }
        public string MissID { get; set; }
        public bool IsVisible { get; set; }
    }
}
