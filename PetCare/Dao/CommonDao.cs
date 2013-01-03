using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetCare.Model;

namespace PetCare.Dao
{
    internal class CommonDao
    {
        /// <summary>
        /// 转换宠物知识的模板为web的公用模板
        /// </summary>
        /// <returns></returns>
        internal static List<WebCommonModel> DataTransferToKnowledgeWebCommonModelList(List<CVKnowledgePet> knowledgeList) {
            List<WebCommonModel> _list = new List<WebCommonModel>();
            foreach (CVKnowledgePet item in knowledgeList)
            {
                WebCommonModel model = new WebCommonModel();
                model.userPhoto = item.Portrait;
                model.userName = item.UserName;
                model.publishTime = item.KnowledgeTime;
                model.publishTitle = item.KnowledgeTitle;
                model.publishContent = item.KnowledgeInfo;
                model.publishPhoto = item.PicLocation;
                model.classify = item.PetCategoryName;
                model.publishComment = item.CommentCount;
                _list.Add(model);
            }
            return _list;
        }

        /// <summary>
        /// 转换领养宠物的模板为web的公用模板
        /// </summary>
        /// <returns></returns>
        internal static List<WebCommonModel> DataTransferToAdoptionWebCommonModelList(List<CVAdoptPet> knowledgeList)
        {
            List<WebCommonModel> _list = new List<WebCommonModel>();
            foreach (CVAdoptPet item in knowledgeList)
            {
                WebCommonModel model = new WebCommonModel();
                model.userPhoto = item.Portrait;
                model.userName = item.UserName;
                model.publishTime = item.AdoptTime;
                model.publishTitle = item.AdoptTitle;
                model.publishContent = item.AdoptInfo;
                model.publishPhoto = item.PicLocation;
                model.classify = item.PetCategoryName;
                model.publishComment = item.CommentCount;
                _list.Add(model);
            }
            return _list;
        }
    }
}