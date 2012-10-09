using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet.Controllers.PetBussiness
{
    public class BussinessController : Controller
    {
        //
        // GET: /Bussiness/

        public JsonResult GetBasicMessage()
        {
            return Json("This is a message from BussinessController",JsonRequestBehavior.AllowGet);
        }

    }
}
