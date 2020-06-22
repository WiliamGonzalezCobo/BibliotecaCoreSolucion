using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaCore.Service.Interface;
using BibliotecaCore.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace BibliotecaCore.WebApi.Controllers
{
    [Route("api/autentication")]
    public class AuthController : Controller
    {
        private readonly IAuthService _iAuthService;
        public AuthController(IAuthService iAuthService)
        {
            _iAuthService = iAuthService;
        }

        [HttpPost("token")]
        public IActionResult Token([FromBody]UserModel userData)
        {
            string token;
            DateTime dateNow = DateTime.UtcNow;
            TimeSpan timeStampExpired = TimeSpan.FromMinutes(5);
            DateTime dateExpired = dateNow.Add(timeStampExpired);

            if (_iAuthService.ValidateLogin(userData.User, userData.Password))
            {
                token = _iAuthService.GenerateToken(dateNow, userData.User, timeStampExpired);

                return Ok(new
                {
                    Token = token,
                    ExpiredDateTime = dateExpired,
                    isAuthenticated = true
                });
            }
            else
            {
                return StatusCode(401);
            }
        }

    }
}