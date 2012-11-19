////////////////////////////////////////////////////////
//这个类代表了用户发表丢失宠物信息信息的类
//misseId代表 每一篇文章的主键ID
//userID  代表是哪个用户发表的这篇文章
//addressID 代表 这篇文章关联的地区
//petcategory 代表这篇文章涉及到的宠物的种类
////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace PetCare.Model
{
    [Serializable]
    [Table(Name = "DB_MissedPet")]
    public class CTMissedPetInfo
    {
        public CTMissedPetInfo()
        {
        }
        public CTMissedPetInfo(string misseId, string userID, string addressID, string petCategory, string weiBoID, string missTitle,
            DateTime missTime,DateTime lastEditTime, string missInfo, int priorityScore, string iP, int focusNum, bool isVisible)
        {
            this.MisseId = misseId;
            this.UserID = userID;
            this.AddressID = addressID;
            this.PetCaretoryID = PetCaretoryID;
            this.WeiBoID = weiBoID;
            this.MissTitle = missTitle;
            this.MissTime = missTime;
            this.MissInfo = missInfo;
            this.PriorityScore = priorityScore;
            this.IP = iP;
            this.FocusNum = focusNum;
            this.IsVisible = isVisible;
            this.LastEditTime = lastEditTime;
        }
        public DateTime LastEditTime
        {
            get;
            set;
        }
        public string MisseId
        {
            get;
            set;
        }
        public string UserID
        {
            get;
            set;
        }
        public string AddressID
        {
            get;
            set;
        }
        public string PetCaretoryID
        {
            get;
            set;
        }
        public string WeiBoID
        {
            get;
            set;
        }
        public string MissTitle
        {
            get;
            set;
        }
        public DateTime MissTime
        {
            get;
            set;
        }
        public string MissInfo
        {
            get;
            set;
        }
        public int PriorityScore
        {
            get;
            set;
        }
        public string IP
        {
            get;
            set;
        }
        public int FocusNum
        {
            get;
            set;
        }
        public bool IsVisible
        {
            get;
            set;
        }
    }
}