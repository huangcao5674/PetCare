using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pet.Controllers.Common
{
    public class CommonController : Controller
    {
        //
        // GET: /Common/

        public JsonResult Index()
        {
            return Json("This is a message from CommonController",JsonRequestBehavior.AllowGet);
        }

    }
}
