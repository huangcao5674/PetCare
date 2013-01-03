using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PetCare.BLL;
using PetCare.Model;
using PetCare.Dao;

namespace PetCare.Controllers.PetAdoption
{
    public class AdoptController : Controller
    {
        //
        // GET: /Adopt/
        /// <summary>
        /// 获取领养宠物信息
        /// </summary>
        /// <param name="pageIndex">当前页码</param>
        /// <param name="limit">每页显示条数</param>
        /// <returns></returns>
        public JsonResult Index(int pageIndex, int limit)
        {
            AdoptPet adoption = new AdoptPet();
            PagingModel<WebCommonModel> _pageKnowledge = new PagingModel<WebCommonModel>();
            List<WebCommonModel> commonList = new List<WebCommonModel>();
            List<CVAdoptPet> adoptList = new List<CVAdoptPet>();
            //获取总页数
            int count = 0;
            try
            {
                adoptList = adoption.GetPetAdoptPerPageList(pageIndex, limit, out count);
                commonList = CommonDao.DataTransferToAdoptionWebCommonModelList(adoptList);
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
