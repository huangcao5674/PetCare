using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetCare.BLL;
using PetCare.Model;

namespace PetCare.Controllers.PetAdoption
{
    public class AdoptController : Controller
    {
        //
        // GET: /Adopt/

        public JsonResult GetBasicMessage()
        {
            return Json("knowledge message", JsonRequestBehavior.AllowGet);
        }

    }
}
