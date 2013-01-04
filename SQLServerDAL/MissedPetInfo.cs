﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PetCare.DBUtility;
using PetCare.Model;
using PetCare.IDAL;

namespace PetCare.SQLServerDAL
{
    public class MissedPetInfo:IMissedPetInfo
    {
        private const string SQL_SELECT_MISSEDPETINFO_BY_USERID = "";

        private const string SQL_SELECT_MISSEDPETINFO = "";

        private const string SQL_INSERT_MISSEDPETINFO = "";

        private const string SQL_DELETE_MISSEDPETINFO = "";

        private const string PARM_USER_ID = "@UserId";


        //实现接口定义的函数：获得所有的丢失信息
        public List<CTMissedPetInfo> GetAllMissedPetInfoList()
        {
            List<CTMissedPetInfo> MissedPetInfoList = new List<CTMissedPetInfo>();
            return MissedPetInfoList;
        }

        //实现接口定义的函数：根据用户ID获取丢失宠物信息
        public List<CTMissedPetInfo> GetMissedPetInfoListByUser(int UserID)
        {
            List<CTMissedPetInfo> MissedPetInfoList = new List<CTMissedPetInfo>();
            return MissedPetInfoList;
        }

        //实现接口定义的函数，增加一条信息
        public int InsertMissedPet(CTMissedPetInfo MissedPetInfo)
        {
            int InsertStatus = 0;
            return InsertStatus;
        }
        public int DeleteMissedPet(string MissedID)
        {
            int DeleteStatus = 0;
            return DeleteStatus;
        }

        public int EditMissedPet(CTMissedPetInfo MissedPetInfo)
        {
            int editStatus = 0;
            return editStatus;
        }

        //根据MissedID查找miss文章信息
        public CTMissedPetInfo GetMissedPetByMissedID(string MissedID)
        {
            CTMissedPetInfo missedPetInfo = new CTMissedPetInfo();
            return missedPetInfo;
        }
    }
}
