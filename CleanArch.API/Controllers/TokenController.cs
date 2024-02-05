using CleanArch.API.Models;
using CleanArch.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authentication;

        public TokenController(IAuthenticate authentication)
        {
            _authentication = authentication ?? 
                throw new ArgumentNullException(nameof(authentication));
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            var result = await _authentication.Authenticate(userInfo.Email, userInfo.Password);

            if (result)
                //return GenerateToken(userInfo);
                return Ok($"User {userInfo.Email} login successfully");

            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return BadRequest(ModelState);
            }
        }
    }
}
