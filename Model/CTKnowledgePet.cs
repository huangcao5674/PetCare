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
            string weiboID,string knowledgeTitle,string knowledgeInfo,int priorityScore, string  lastEditTime,
            string ip,int focusNum,bool isVisible,int complatinNum)
        {
            KnowledgeID = knowledgeid;
            UserID = userID;
            AddressID = addressID;
            PetCategoryID = petCategoryID;
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
        public  string  LastEditTime{get;set;}
        public string KnowledgeID{get;set;}
        public string UserID{ get; set; }
        public string AddressID{  get; set; }
        public string PetCategoryID{ get; set; }
        public string WeiBoID{ get; set; }
        public string KnowledgeTitle{ get; set;  }
        public  string  KnowledgeTime{get;set;}
        public string KnowledgeInfo{ get;set;}
        public int PriorityScore{ get; set;  }
        public string IP{ get;  set;  }
        public int FocusNum{  get; set; }
        public bool IsVisible{ get; set; }

    }


    //这个实体类用来检索出来所有的知识文章列表信息
    public class CVKnowledgePet
    {
        //用户姓名
        public string UserName { get; set; }
        //用户的weibo
        public string UserWeiBo { get; set; }
        //用户头像的位置
        public string Portrait { get; set; }
        //knowledgeID
        public string KnowledgeID { get; set; }
        //对应的宠物种类
        public string PetCategoryName { get; set; }
        //对应的省
        public string Province { get; set; }
        //对应的地区
        public string City { get; set; }
        //文章的标题
        public string KnowledgeTitle { get; set; }
        //最后一次更新的时间
        public  string  LastEditTime { get; set; }
        //最初发布的时间
        public  string  KnowledgeTime { get; set; }
        //具体的文章内容信息
        public string KnowledgeInfo { get; set; }
        //优先级的分数
        public int PriorityScore { get; set; }
        //发布的时候对应的IP
        public string IP { get; set; }
        //关注的数量
        public int FocusNum { get; set; }
        //具体的详细文章的地址
        public string LinkUrl { get; set; }
        //文章内部包含的图片
        public string PicLocation { get; set; }
        //是否是推荐文章
        public bool IsRecommand { get; set; }
        //状态（保留字段）
        public string Status { get; set; }
        //是否是精华的文章
        public bool IsEssence { get; set; }
        //评论的数量
        public int CommentCount { get; set; }
    }


    //这个实体类用来代表一条单独的知识文章的所有信息（包括所有评论，用户信息）
    public class CVKnowledgePetComment
    {
        //评论ID
        public string CommentID { get; set; }

        //文章ID
        public string KnowledgeID { get; set; }
        //文章的标题
        public string KnowledgeTitle { get; set; }
        //文章的发布时间
        public string KnowledgeTime { get; set; }
        //文章最后一次修改的时间
        public string LastEditTime { get; set; }
        //文章的具体内容
        public string KnowledgeInfo { get; set; }
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
        public  string  CommentTime { get; set; }
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
