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
        private static readonly string Path = ConfigurationManager.AppSettings["AdoptPet"];
        private static readonly string AdoptPath = ConfigurationManager.AppSettings["AdoptPet"];
        private static readonly string KnowledgePath = ConfigurationManager.AppSettings["KnowledgePet"];
        private static readonly string MissedPetPath=ConfigurationManager.AppSettings[""];

        private DataAccess()
        {
        }


        //创建User类
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

        //创建KnowledgePet  类
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

        //创建knowledgePetComment类
        public static PetCare.IDAL.IKnowledgePetComment CreateKnowledgeComment()
        {
            try
            {
                string className = KnowledgePath + ".KnowledgePetComment";
                return (PetCare.IDAL.IKnowledgePetComment)Assembly.Load(KnowledgePath).CreateInstance(className);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //创建AdoptPet类
        public static PetCare.IDAL.IAdoptPet CreateAdoptPet()
        {
            try
            {
                string className = AdoptPath + ".AdoptPet";
                return (PetCare.IDAL.IAdoptPet)Assembly.Load(AdoptPath).CreateInstance(className);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //创建AdoptPetComment类
        public static PetCare.IDAL.IAdoptPetComment CreateAdoptPetComment()
        {
            try
            {
                string className = Path + ".AdoptPetComment";
                return (PetCare.IDAL.IAdoptPetComment)Assembly.Load(KnowledgePath).CreateInstance(className);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //创建Missedpet 类
        public static PetCare.IDAL.IMissedPetInfo CreateMissedPet()
        {
            try
            {
                string className = MissedPetPath + ".MissedPetInfo";
                return (PetCare.IDAL.IMissedPetInfo)Assembly.Load(MissedPetPath).CreateInstance(className);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //创建Address 类
        public static PetCare.IDAL.IAddress CreateAddress()
        {
            try
            {
                string className = AdoptPath + ".Address";
                return (PetCare.IDAL.IAddress)Assembly.Load(AdoptPath).CreateInstance(className);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //创建Category类
        public static PetCare.IDAL.IPetCategory CreateCategory()
        {
            try
            {
                string className = Path + ".PetCategory";
                return (PetCare.IDAL.IPetCategory)Assembly.Load(Path).CreateInstance(className);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        //创建UserFocus类
        public static PetCare.IDAL.IUserFocus CreateUserFocus()
        {
            try
            {
                string className = Path + ".UserFocus";
                return (PetCare.IDAL.IUserFocus)Assembly.Load(Path).CreateInstance(className);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        //创建LoginLog类
        public static PetCare.IDAL.ILoginLog CreateLoginLog()
        {
            try
            {
                string className = Path + ".LoginLog";
                return (PetCare.IDAL.ILoginLog)Assembly.Load(Path).CreateInstance(className);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }

}
