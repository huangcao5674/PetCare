////////////////////////////////////////////////////////
//这个类代表了用户发表宠物知识信息的类
//knowledgeID代表 每一篇文章的主键ID
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
    [Table(Name = "DB_KnowledgePet")]
    public class CTKnowledgePet
    {
        public CTKnowledgePet()
        {
        }
        public CTKnowledgePet(string knowledgeid,string userID,string addressID,string petCategoryID,
            string weiboID,string knowledgeTitle,string knowledgeInfo,int priorityScore,DateTime lastEditTime,
            string ip,int focusNum,bool isVisible,int complatinNum)
        {
            KnowledgeID = knowledgeid;
            UserID = userID;
            AddressID = addressID;
            PetCaretegoryID = petCategoryID;
            WeiBoID = weiboID;
            KnowledgeTime = KnowledgeTime;
            KnowledgeInfo = knowledgeInfo;
            PriorityScore = priorityScore;
            IP = ip;
            FocusNum = focusNum;
            IsVisible = isVisible;
            LastEditTime = lastEditTime;
            ComplaintNum = complatinNum;
        }
        public int ComplaintNum{ get;set; }
        public DateTime LastEditTime{get;set;}
        public string KnowledgeID{get;set;}
        public string UserID{ get; set; }
        public string AddressID{  get; set; }
        public string PetCaretegoryID{ get; set; }
        public string WeiBoID{ get; set; }
        public string KnowledgeTitle{ get; set;  }
        public DateTime KnowledgeTime{get;set;}
        public string KnowledgeInfo{ get;set;}
        public int PriorityScore{ get; set;  }
        public string IP{ get;  set;  }
        public int FocusNum{  get; set; }
        public bool IsVisible{ get; set; }

    }


    //这个实体类用来检索出来所有的知识文章列表信息
    public class CVKnowledgePet
    {
        public string UserName { get; set; }
        public string UserWeiBo { get; set; }
        public string Portrait { get; set; }
        public string KnowledgeID { get; set; }
        public string PetCategoryName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string KnowledgeTitle { get; set; }
        public DateTime LastEditTime { get; set; }
        public DateTime KnowledgeTime { get; set; }
        public string KnowledgeInfo { get; set; }
        public int PriorityScore { get; set; }
        public string IP { get; set; }
        public int FocusNum { get; set; }
        public string LinkUrl { get; set; }
        public string PicLocation { get; set; }
        public bool IsRecommand { get; set; }
        public string Status { get; set; }
        public bool IsEssence { get; set; }
        public int CommentCount { get; set; }
    }


    //这个实体类用来代表一条单独的知识文章的所有信息（包括所有评论，用户信息）
    public class CVKnowledgePetComment
    {
        public string KnowledgeID { get; set; }
        public string KnowledgeTitle { get; set; }
        public DateTime KnowledgeTime { get; set; }
        public DateTime LastEditTime { get; set; }
        public string KnowledgeInfo { get; set; }
        public string IP { get; set; }
        public int PriorityScore { get; set; }
        public int FocusNum { get; set; }
        public string Status { get; set; }
        public bool IsRecommand { get; set; }
        public bool IsEssence { get; set; }
        public string LinkUrl { get; set; }
        public string PicLocation { get; set; }
        public string PetCategoryName { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string UserName { get; set; }
        public string Portrait { get; set; }
        public string UserLevel { get; set; }
        public string UserSex { get; set; }
        public string UserAddress { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserQQNum { get; set; }
        public string UserWeiBo { get; set; }
        public DateTime CommentTime { get; set; }
        public string CommentContent { get; set; }
        public string CommentIP { get; set; }
        public string PetCategoryInfo { get; set; }
        public string CommentUserName { get; set; }
        public string CommentUserLevel { get; set; }
        public string CommentUserProtrait { get; set; }
        public string RoleID { get; set; } 
    }


}
