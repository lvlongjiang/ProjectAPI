using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 登录表/Token认证
    /// </summary>
    public class Login
    {
        [Key]
        /// <summary>
        /// 用户名字段
        /// </summary>
        public string  UserName { get; set; }
        /// <summary>
        /// 用户名登录密码
        /// </summary>
        public string  UserPass { get; set; }
    }
}
