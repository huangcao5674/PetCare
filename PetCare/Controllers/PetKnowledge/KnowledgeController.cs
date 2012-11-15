using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetCare.Controllers.PetKnowledge
{
    public class KnowledgeController : Controller
    {
        //
        // GET: /Knowledge/

        public JsonResult Index()
        {
            return Json("knowledge message", JsonRequestBehavior.AllowGet);
        }

    }
}
