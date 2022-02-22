using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ProjectAPI.Controllers
{

    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly IConfiguration configuration;

        public LoginController(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        [HttpGet]
        [Route("api/Login")]
        public string Login(string UserName, string UserPass)
        {
            Login deng = new Login()
            {
                UserName=UserName,
                UserPass=UserPass,
            };
            return GetJWT(deng);
        }



        /// <summary>
        /// 生成JWT字符串
        /// </summary>
        /// <param name="tokenModel"></param>
        /// <returns></returns>
        private string GetJWT(Login tokenModel)
        {
            //DateTime utc = DateTime.UtcNow;
            var claims = new List<Claim>
            {

                new Claim(JwtRegisteredClaimNames.Jti,JsonConvert.SerializeObject(tokenModel)),
                // 令牌颁发时间
                new Claim(JwtRegisteredClaimNames.Iat, $"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Nbf,$"{new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds()}"),
                 // 过期时间 100秒
                new Claim(JwtRegisteredClaimNames.Exp,$"{new DateTimeOffset(DateTime.Now.AddSeconds(1000)).ToUnixTimeSeconds()}"),
                new Claim(JwtRegisteredClaimNames.Iss,"API"), // 签发者
                new Claim(JwtRegisteredClaimNames.Aud,"User") // 接收者
               
            };

            // 密钥
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("secretKey").Value));
            //sha256加密规则
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken jwt = new JwtSecurityToken(

                claims: claims,// 声明的集合
                               //expires: .AddSeconds(36), // token的有效时间
                signingCredentials: creds
                );
            var handler = new JwtSecurityTokenHandler();
            // 生成 jwt字符串
            var strJWT = handler.WriteToken(jwt);
            return strJWT;
        }
    }
}

