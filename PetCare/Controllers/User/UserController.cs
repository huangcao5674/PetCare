using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetCare.Controllers.User
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        public JsonResult Index()
        {
            return Json("This is a message from UserController", JsonRequestBehavior.AllowGet);
        }

    }
}
