using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.IDAL;
using PetCare.Model;

namespace PetCare.SQLServerDAL
{
    public class AdoptPetComment:IAdoptPetComment
    {
       public  List<CTAdoptPetComment> GetAdoptPetCommentListByID(int UserID)
        {
            List<CTAdoptPetComment> list = new List<CTAdoptPetComment>();
            return list;
        }
       
    }
}
