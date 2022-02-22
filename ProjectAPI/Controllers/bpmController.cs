using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication21.Models;

namespace ProjectAPI.Controllers
{
    [ApiController]
    public class bpmController : BaseController
    {
        public bpmController(IConfiguration configuration) : base(configuration)
        {
        }
        [HttpPost, Route("api/startleave")]
        public void StartLeave(LeaveNew leave)
        {//发起流程
            StartProccess<LeaveNew>(leave);
        }
    }
}
