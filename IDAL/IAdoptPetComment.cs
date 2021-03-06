﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;

namespace PetCare.IDAL
{
    public  interface IAdoptPetComment
    {
        
        List<CTAdoptPetComment> GetAdoptPetCommentListByID(int UserID);

        int InsertAdoptPetComment(CTAdoptPetComment adoptComment);

        int DeleteAdoptPetComment(string commendID);

        int EditAdoptPetComment(CTAdoptPetComment adoptComment);

        CTAdoptPetComment GetAdoptPetCommentByCommentID(string commentID);
    }
}
