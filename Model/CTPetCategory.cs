using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetCare.Model
{
    public class CTPetCategory
    {
        public string petCategoryID{get;set;}
        public string petCategoryName { get; set; }
        public string petCategoryInfo { get; set; }
        public bool IsVisible { get; set; }
    }
}
