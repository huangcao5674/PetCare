using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Caching;

namespace PetCare.ICacheDependency
{
    public interface IPetShopCacheDependency
    {

        /// <summary>
        /// Method to create the appropriate implementation of Cache Dependency
        /// </summary>
        /// <returns>CacheDependency object(s) embedded in AggregateCacheDependency</returns>
        AggregateCacheDependency GetDependency();
    }
}
