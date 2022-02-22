using IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{

    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IServicesUser db;
        public UserController(IServicesUser db)
        {
            this.db = db;
        }

        /// <summary>
        /// User表显示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/UserShow")]
        public IActionResult UserShow()
        {
            return Ok(db.UserShow().ToList());
        }


    }
}
