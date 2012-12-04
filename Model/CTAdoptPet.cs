﻿////////////////////////////////////////////////////////
//这个类代表了用户发表领养宠物信息信息的类
//userID  代表是哪个用户发表的这篇文章
//addressID 代表 这篇文章关联的地区
//petcategory 代表这篇文章涉及到的宠物的种类
////////////////////////////////////////////////////////
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace PetCare.Model
{
    [Serializable]
    [Table(Name = "DB_AdoptPet")]
    public class CTAdoptPet
    {
        public CTAdoptPet()
        {
        }

        public CTAdoptPet(string userID, string addressID, string petCategoryId, string weiBoID, string adoptTitle,
            DateTime adoptTime, string adoptInfo,DateTime lastEditTime, string iP, int priorityScore, int focusNum, bool isVisible
           ,bool isAdopt)
        {
            this.UserID = userID;
            this.AddressID = addressID;
            this.PetCategoryID = petCategoryId;
            this.WeiBoID = weiBoID;
            this.AdoptTitle = adoptTitle;
            this.AdoptTime = adoptTime;
            this.AdoptInfo = adoptInfo;
            this.IP = iP;
            this.PriorityScore = priorityScore;
            this.FocusNum = focusNum;
            this.IsVisible = isVisible;
            this.LastEditTime = lastEditTime;
            this.IsAdopt = isAdopt;
        }
        public bool IsAdopt
        {
            get;
            set;
        }
        public DateTime LastEditTime
        {
            get;
            set;
        }
        public string AdoptID
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
        public string PetCategoryID
        {
            get;
            set;
        }
        public string WeiBoID
        {
            get;
            set;
        }
        public string AdoptTitle
        {
            get;
            set;
        }
        public DateTime AdoptTime
        {
            get;
            set;
        }
        public string AdoptInfo
        {
            get;
            set;
        }
        public string IP
        {
            get;
            set;
        }
        public int PriorityScore
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

    public class CVAdoptPet
    {
       public string Province{get;set;}
       public string City{get;set;}
       public string PetCategoryName{get;set;}
       public string AdoptID{get;set;}
       public string AdoptTitle{get;set;}
       public DateTime AdoptTime{get;set;}
       public DateTime LastEditTime{get;set;}
       public string AdoptInfo{get;set;}
       public string IP{get;set;}
       public int PriorityScore{get;set;}
       public int FocusNum{get;set;}
       public bool IsVisible{get;set;}
       public bool IsAdopt { get; set; }
 
    }
}
