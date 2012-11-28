using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using PetCare.ICacheDependency;
using System.Reflection;

namespace PetCare.CatcheDependencyFactory
{
    public static class DependencyAccess
    {
        /// <summary>
        /// Method to create an instance of Category dependency implementation
        /// </summary>
        /// <returns>Category Dependency Implementation</returns>
        public static IPetShopCacheDependency CreateCategoryDependency()
        {
            return LoadInstance("PetCategory");
        }

        public static IPetShopCacheDependency CreateAddressDependency()
        {
            return LoadInstance("Address");
        }

        private static IPetShopCacheDependency LoadInstance(string className)
        {

            string path = ConfigurationManager.AppSettings["CacheDependencyAssembly"];
            string fullyQualifiedClass = path + "." + className;

            // Using the evidence given in the config file load the appropriate assembly and class
            return (IPetShopCacheDependency)Assembly.Load(path).CreateInstance(fullyQualifiedClass);
        }
    }
}
