using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet.Controllers.PetAdoption
{
    public class AdoptController : Controller
    {
        //
        // GET: /Adopt/

        public JsonResult GetBasicMessage()
        {
            return Json("This is a message from AdoptController",JsonRequestBehavior.AllowGet);
        }

    }
}
