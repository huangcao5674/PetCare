using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetCare.Model
{
    /// <summary>
    /// 分页类
    /// </summary>
    public class PagingModel<T> where T:class,new()
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int total { get; set; }
        /// <summary>
        /// 返回的记录信息
        /// </summary>
        public List<T> records { get; set; }
    }
}
