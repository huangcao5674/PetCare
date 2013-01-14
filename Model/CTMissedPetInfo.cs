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
        public CTMissedPetInfo(string missId, string userID, string addressID, string petCategory, string weiBoID, string missTitle,
             string  missTime, string  lastEditTime, string missInfo, int priorityScore, string iP, int focusNum, bool isVisible)
        {
            this.MissId = missId;
            this.UserID = userID;
            this.AddressID = addressID;
            this.PetCategoryID = PetCategoryID;
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
        public  string LastEditTime{get;set;}
        public string MissId{ get;set;}
        public string UserID{get;set;}
        public string AddressID{get;set;}
        public string PetCategoryID{get;set;}
        public string WeiBoID{get;set;}
        public string MissTitle{get;set;}
        public  string  MissTime{get;set;}
        public string MissInfo{get;set;}
        public int PriorityScore{get;set;}
        public string IP{get;set; }
        public int FocusNum{get;set;}
        public bool IsVisible{ get;set;}
        public bool IsRecommand { get; set; }
        public bool IsEssence { get; set; }
        public string LinkUrl { get; set; }
        public string Status { get; set; }
        public string PicLocation { get; set; }
    }

    public class CVMissedPetInfo
    {
        public string UserName { get; set; }
        public string Portrait { get; set; }
        public string MissID { get; set; }
        public string MissTitle { get; set; }
        public string MissTime { get; set; }
        public string LastEditTime { get; set; }
        public string MissInfo { get; set; }
        public int PriorityScore { get; set; }
        public string IP { get; set; }
        public string UserWeiBo { get; set; }
        public int FocusNum { get; set; }
        public bool IsRecommand { get; set; }//是否是被推荐的帖子
        public bool IsEssence { get; set; }//是否是精华帖子
        public string LinkUrl { get; set; }
        public string Status { get; set; } //状态，保留字段
        public string PicLocation { get; set; }
        public string Province { get; set; }
        public string City { get; set; }
        public string PetCategoryName { get; set; }
        public int CommentCount { get; set; }
    }

    public class CVMissedPetComment
    {
        //评论ID
        public string CommentID { get; set; }

        //文章ID
        public string MissID { get; set; }
        //文章的标题
        public string MissTitle { get; set; }
        //文章的发布时间
        public string MissTime { get; set; }
        //文章最后一次修改的时间
        public string LastEditTime { get; set; }
        //文章的具体内容
        public string MissInfo { get; set; }
        //文章发布的IP地址
        public string IP { get; set; }
        //文章的优先级分数
        public int PriorityScore { get; set; }
        //文章关注的数量
        public int FocusNum { get; set; }
        //文章的状态（保留字段）
        public string Status { get; set; }
        //是否被推荐
        public bool IsRecommand { get; set; }
        //是否是精华的内容
        public bool IsEssence { get; set; }
        //文章的具体的URL地址
        public string LinkUrl { get; set; }
        //文章具体包含的图片的地址
        public string PicLocation { get; set; }
        //这个文章对应的宠物的种类
        public string PetCategoryName { get; set; }
        //文章对应的地区--省份
        public string Province { get; set; }
        //文章对应的地区
        public string City { get; set; }
        //发表文章的用户
        public string UserName { get; set; }
        //发表文章用户的头像
        public string Portrait { get; set; }
        //发表文章的用户的等级
        public string UserLevel { get; set; }
        //发表文章的用户的性别
        public string UserSex { get; set; }
        //发表文章的用户的地址
        public string UserAddress { get; set; }
        //发表文章的用户的email
        public string UserEmail { get; set; }
        //发表文章的用户的电话
        public string UserPhoneNumber { get; set; }
        //发表文章的用户的qq
        public string UserQQNum { get; set; }
        //发表用户的weibo
        public string UserWeiBo { get; set; }
        //评论的时间
        public string CommentTime { get; set; }
        //评论的内容
        public string CommentContent { get; set; }
        //评论的IP地址
        public string CommentIP { get; set; }
        //文章设计到的宠物的信息
        public string PetCategoryInfo { get; set; }
        //评论的用户的用户名
        public string CommentUserName { get; set; }
        //评论的用户的等级
        public string CommentUserLevel { get; set; }
        //评论的用户的头像
        public string CommentUserProtrait { get; set; }
        //用户的角色ID
        public string RoleID { get; set; }
    }

}