////////////////////////////////////////////////////////
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
             string  adoptTime, string adoptInfo, string  lastEditTime, string iP, int priorityScore, int focusNum, bool isVisible
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
        public bool IsAdopt{get;set;}
        public  string  LastEditTime{get;set;}
        public string AdoptID{get;set;}
        public string UserID{get;set;}
        public string AddressID{get;set;}
        public string PetCategoryID{get;set;}
        public string WeiBoID{get;set;}
        public string AdoptTitle{get;set;}
        public  string  AdoptTime{get; set;}
        public string AdoptInfo{ get; set;}
        public string IP{get;set;}
        public int PriorityScore{get;set;}
        public int FocusNum{ get;set;}
        public bool IsVisible{ get;set;}
    }


    //这个实体类用来检索出来所有的领养文章列表信息
    public class CVAdoptPet
    {
       public string Province{get;set;}
       public string City{get;set;}
       public string PetCategoryName{get;set;}
       public string AdoptID{get;set;}
       public string AdoptTitle{get;set;}
       public  string  AdoptTime{get;set;}
       public  string  LastEditTime{get;set;}
       public string AdoptInfo{get;set;}
       public string IP{get;set;}
       public int PriorityScore{get;set;}
       public int FocusNum{get;set;}
       public bool IsAdopt { get; set; }
       public string UserName { get; set; }
       public string Portrait { get; set; }
       public string LinkUrl { get; set; }
       public string PicLocation { get; set; }
       public int CommentCount { get; set; }
       public string UserWeiBo { get; set; }
       public string Status { get; set; } //状态，保留字段
       public bool IsRecommand { get; set; } //是否是被推荐的帖子
       public bool IsEssence { get; set; }//是否是精华的帖子
 
    }

    //这个实体类用来代表一条单独的领养文章的所有信息（包括所有评论，用户信息）
    public class CVAdoptPetComment
    {
        public string CommentID { get; set; }
        //领养宠物的城市
       public string Province {get;set;}
        //领养宠物的区
       public string City {get;set;}
        //发布文章用户的姓名
       public string UserName {get;set;}
        //发布文章用户的性别
       public string UserSex {get;set;}
       public string UserAddress {get;set;}
       public string UserEmail {get;set;}
       public string UserPhoneNumber {get;set;}
       public string UserQQNum {get;set;}
       public string UserWeiBo {get;set;}
       public string Portrait {get;set;}
       public string UserLevel {get;set;}
       public string RoleID {get;set;}
       public string AdoptID {get;set;}
       public string AdoptTitle {get;set;}
       public  string  AdoptTime {get;set;}
       public  string  LastEditTime {get;set;}
       public string AdoptInfo {get;set;}
       public string IP {get;set;}
       public int PriorityScore {get;set;}
       public string PetCategoryName { get; set; }
       public int FocusNum {get;set;}
       public bool IsAdopt {get;set;}
       public string Status {get;set;}
       public bool IsRecommand {get;set;}
       public bool IsEssence {get;set;}
       public string LinkUrl {get;set;}
       public string PicLocation {get;set;}
       public string CommentContent {get;set;}
       public  string  CommentTime {get;set;}
       public string CommentIP {get;set;}
       public string CommentUserName {get;set;}
       public string CommentUserProtrait {get;set;}
       public string CommentUserLevel {get;set;}
    }
}
