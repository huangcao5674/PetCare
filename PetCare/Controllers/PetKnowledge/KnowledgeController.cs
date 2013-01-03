using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetCare.BLL;
using PetCare.Model;
using PetCare.Dao;

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
            PagingModel<WebCommonModel> _pageKnowledge = new PagingModel<WebCommonModel>();
            List<WebCommonModel> commonList = new List<WebCommonModel>();
            List<CVKnowledgePet> knowledgeList = new List<CVKnowledgePet>();
            //获取总页数
            int count = 0;
            try
            {
                knowledgeList = knowledge.GetPetKnowledgePerPageList(pageIndex,limit,out count);
                commonList = CommonDao.DataTransferToKnowledgeWebCommonModelList(knowledgeList);
                _pageKnowledge.total = count;
                _pageKnowledge.records = commonList;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Json(_pageKnowledge, JsonRequestBehavior.AllowGet);
        }

    }
}
