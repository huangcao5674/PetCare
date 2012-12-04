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
            KnowledgePet knowledge = new KnowledgePet();
            List<CTKnowledgePet> knowledgeList = new List<CTKnowledgePet>();
            try
            {
                knowledgeList = knowledge.GetKnowledgePetList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(knowledgeList, JsonRequestBehavior.AllowGet);
        }

    }
}
