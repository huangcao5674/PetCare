using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.Model;
using PetCare.IDAL;

namespace PetCare.BLL
{
    public class AdoptPetComment
    {
        private static readonly IAdoptPetComment dal = PetCare.DALFactory.DataAccess.CreateAdoptPetComment();

 
        public int InsertComment(CTAdoptPetComment adoptComment)
        {
            return dal.InsertAdoptPetComment(adoptComment);
        }
    }
}
