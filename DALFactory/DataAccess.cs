using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace PetCare.DALFactory
{
    public sealed class DataAccess
    {
        private static readonly string AdoptPath = ConfigurationManager.AppSettings["AdoptPet"];
        private static readonly string KnowledgePath = ConfigurationManager.AppSettings["KnowledgePet"];
        private static readonly string MissedPetPath=ConfigurationManager.AppSettings[""];

        private DataAccess()
        {
        }

        public static PetCare.IDAL.IUser CreateUser()
        {
            try
            {
                string className = KnowledgePath + ".User";
                return (PetCare.IDAL.IUser)Assembly.Load(KnowledgePath).CreateInstance(className);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static PetCare.IDAL.IKnowledgePet CreateKnowledgePet()
        {
            try
            {
                string className = KnowledgePath + ".KnowledgePet";
                return (PetCare.IDAL.IKnowledgePet)Assembly.Load(KnowledgePath).CreateInstance(className);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static PetCare.IDAL.IAdoptPet CreateAdoptPet()
        {
            try
            {
                string className = AdoptPath + "AdoptPet";
                return (PetCare.IDAL.IAdoptPet)Assembly.Load(AdoptPath).CreateInstance(className);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static PetCare.IDAL.IMissedPetInfo CreateMissedPet()
        {
            try
            {
                string className = MissedPetPath + "MissedPetInfo";
                return (PetCare.IDAL.IMissedPetInfo)Assembly.Load(MissedPetPath).CreateInstance(className);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }

}
