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
        public CTKnowledgePet(string knowledgeid,int userID,string addressID,string petCategoryID,
            string weiboID,string knowledgeTitle,string knowledgeInfo,string priorityScore,
            string ip,int focusNum,bool isVisible)
        {
            KnowledgeID = knowledgeid;
            UserID = userID;
            AddressID = addressID;
            PetCaretegoryID = petCategoryID;
            WeiBoID = weiboID;
            KnowledgeID = knowledgeid;
            KnowledgeTime = KnowledgeTime;
            KnowledgeInfo = knowledgeInfo;
            PriorityScore = priorityScore;
            IP = ip;
            FocusNum = focusNum;
            IsVisible = isVisible;
        }
        public string KnowledgeID
        {
            get;
            set;
        }
        public int UserID
        { 
            get; 
            set; 
        }
        public string AddressID
        { 
            get; 
            set; 
        }
        public string PetCaretegoryID
        { 
            get; 
            set; 
        }
        public string WeiBoID
        { 
            get; 
            set; 
        }
        public string KnowledgeTitle
        { 
            get; 
            set; 
        }
        public DateTime KnowledgeTime
        {
            get;
            set;
        }
        public string KnowledgeInfo
        {
            get;
            set;
        }
        public string PriorityScore
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
