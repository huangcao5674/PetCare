using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web.Caching;

namespace PetCare.CatcheDependencyFactory
{
    public static class DependencyFacade
    {
        private static readonly string path = ConfigurationManager.AppSettings["CacheDependencyAssembly"];

        public static AggregateCacheDependency GetCategoryDependency()
        {
            if (!string.IsNullOrEmpty(path))
                return DependencyAccess.CreateCategoryDependency().GetDependency();
            else
                return null;
        }
    }
}
