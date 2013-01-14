using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.BLL;
using PetCare.DALFactory;
using PetCare.IDAL;
using PetCare.Model;

namespace PetCare.BLL
{
    public class MissedPetInfo
    {
        private static readonly IMissedPetInfo dal = PetCare.DALFactory.DataAccess.CreateMissedPet();

        //获取所有的领养宠物的文章列表，返回信息列表，分页的方式
        public List<CVMissedPetInfo> GetPetMissedPerPageList(int pageNumber, int perPage, out int howmanyPages)
        {
            return dal.GetAllMissedPetListPerPage(pageNumber, perPage, out howmanyPages);
        }

        //获得一条丢失信息的所有信息，所有评论等
        public List<CVMissedPetComment> GetPetMissCommentPageList(string missPetID, int pageNumber, int NumberPerPage, out int howmanyPages)
        {
            return dal.GetMissPetCommentPageList(missPetID, pageNumber, NumberPerPage, out howmanyPages);
        }

        //返回所有的领养文章的列表
        public List<CTMissedPetInfo> GetPetMissedAllList()
        {
            return dal.GetAllMissedPetInfoList();
        }

        //删除Miss信息
        public int DeletePetInfo(string missID)
        {
            return dal.DeleteMissedPet(missID);
        }

        //编辑Miss 信息
        public int EditPetInfo(CTMissedPetInfo missPetInfo)
        {
            return dal.EditMissedPet(missPetInfo);
        }

        //插入丢失信息
        public int InsertMissedPetInfo(CTMissedPetInfo missedPetInfo)
        {
            return dal.InsertMissedPet(missedPetInfo);
        }

        public CTMissedPetInfo GetMissedInfoByMissedID(string MissedID)
        {
            return dal.GetMissedPetByMissedID(MissedID);
        }

        public List<CTMissedPetInfo> SearchMissedInfoByUserID(string UserID)
        {
            return dal.GetMissedPetInfoListByUser(UserID);
        }
    }
}
