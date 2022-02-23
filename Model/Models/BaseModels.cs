using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{

    [NotMapped]
    public class BaseModels
    {
        /// <summary>
        /// 添加时需要的提交动作 看发起流程线上的文字来定义
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 登录服务器的用户名或密码
        /// </summary>
        public string BPMUser { get; set; }
        /// <summary>
        /// 登录服务器密码，登录平台的密码
        /// </summary>
        public string BPMUserPass { get; set; }
        /// <summary>
        /// 发起流程人员
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// 流程名称
        /// </summary>
        public string ProcessName { get; set; }


    }
}
