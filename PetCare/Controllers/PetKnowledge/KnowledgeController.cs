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
        /// <summary>
        /// 获取宠物知识的信息
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="limit">每页的显示条数</param>
        /// <returns></returns>
        public JsonResult Index(int pageIndex,int limit)
        {
            KnowledgePet knowledge = new KnowledgePet();
            PagingModel<CVKnowledgePet> _pageKnowledge = new PagingModel<CVKnowledgePet>();
            List<CVKnowledgePet> knowledgeList = new List<CVKnowledgePet>();
            //获取总页数
            int count = 0;
            try
            {
                knowledgeList = knowledge.GetPetKnowledgePerPageList(pageIndex,limit,out count);
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
