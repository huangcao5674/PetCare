using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PetCare.Model
{
    /// <summary>
    /// 前台显示的公共类，用于userHome中不同的类模板
    /// </summary>
    public class WebCommonModel
    {
        /// <summary>
        /// 用户头像地址
        /// </summary>
        public string userPhoto { get; set; }
        /// <summary>
        /// 发表信息的用户名
        /// </summary>
        public string userName { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        public string publishTime { get; set; }
        /// <summary>
        /// 发布标题
        /// </summary>
        public string publishTitle { get; set; }
        /// <summary>
        /// 发布的内容
        /// </summary>
        public string publishContent { get; set; }
        /// <summary>
        /// 发布的主图片
        /// </summary>
        public string publishPhoto { get; set; }
        /// <summary>
        /// 当前所属主题
        /// </summary>
        public string classify { get; set; }
        /// <summary>
        /// 评论数量
        /// </summary>
        public int publishComment { get; set; }
    }
}
