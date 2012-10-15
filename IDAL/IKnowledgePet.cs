using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetCare.IDAL
{
    public interface IKnowledgePet
    {
        //得到宠物的知识的所有的信息
        List<IKnowledgePet> GetAllKnowledgePetList();

        //根据用户ID得到用户发布的宠物知识的信息
        List<IKnowledgePet> GetKnowledgePetListByUser(int UserID);
    }
}
