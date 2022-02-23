using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bpmdemoapi.models
{
    public class BPMModels
    {
        private IConfiguration configuration;


        public BPMModels(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        /// <summary>
        /// 流程名称
        /// </summary>
        public string ProcessName { get; set; }
        /// <summary>
        /// 添加时需要的提交动作 看发起流程线上的文字来定义
        /// </summary>
        public string Action { get; set; }
        /// <summary>
        /// 发起流程人员
        /// </summary>
        public string FullName { get; set; }
        /// <summary>
        /// bpm服务器IP
        /// </summary>
        public string BPMServerIP { get { return configuration.GetSection("bpmServerIp").Value; } }
        /// <summary>
        /// 登录服务器密码，登录平台的密码
        /// </summary>
        public string BPMUserPass { get; set; }
        /// <summary>
        /// 登录服务器的用户名或密码
        /// </summary>
        public string BPMUser { get; set; }
        /// <summary>
        /// 服务器端口
        /// </summary>
        public int BPMServerPort { get { return int.Parse( configuration.GetSection("bpmPort").Value);} }
        /// <summary>
        /// 传递到流程的数据
        /// </summary>
        public string FormDataSet { get; set; }
        public string BpmServerUrl { get { return configuration.GetSection("bpmServerUrl").Value; } }
    }
}
