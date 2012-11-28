using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetCare.TableCacheDependency
{
    public class PetCategory : TableDependency
    {
        public PetCategory() : base("CategoryTableDependency") { }
    }
}
