using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;
using PetCare.IDAL;

namespace PetCare.DALFactory
{
    public sealed class DataAccess
    {
        private static readonly string path = ConfigurationManager.AppSettings["AdoptPet"];

        private DataAccess()
        {
        }

        public static PetCare.IDAL.IUser CreateUser()
        {
            string className = path + ".User";
            return (PetCare.IDAL.IUser)Assembly.Load(path).CreateInstance(className);
        }

        public static PetCare.IDAL.IKnowledgePet CreateKnowledgePet()
        {
            string className = path + ".KnowledgePet";
            return (PetCare.IDAL.IKnowledgePet)Assembly.Load(path).CreateInstance(className);
            
        }

    }

}
