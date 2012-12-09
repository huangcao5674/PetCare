using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetCare.BLL;
using PetCare.Model;

namespace PetCare.Controllers.PetKnowledge
{
    public class KnowledgeController : Controller
    {
        //
        // GET: /Knowledge/

        public JsonResult Index()
        {
            KnowledgePet knowledge = new KnowledgePet();
            PagingModel<CVKnowledgePet> _pageKnowledge = new PagingModel<CVKnowledgePet>();
            List<CVKnowledgePet> knowledgeList = new List<CVKnowledgePet>();
            //获取总页数
            int count = 0;
            try
            {
                knowledgeList = knowledge.GetPetKnowledgePerPageList(1,5,out count);
                _pageKnowledge.total = count;
                _pageKnowledge.records = knowledgeList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(_pageKnowledge, JsonRequestBehavior.AllowGet);
        }

    }
}
