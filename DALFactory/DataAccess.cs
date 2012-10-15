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
        private static readonly string path = ConfigurationManager.AppSettings["WebDAL"];

        private DataAccess()
        {
        }

        public static PetCare.IDAL.IUser CreateUser()
        {
            string className = path + ".User";
            return (PetCare.IDAL.IUser)Assembly.Load(path).CreateInstance(className);
        }

    }

}
