using Infra.IRepositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public AuthenticationController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("user")]
        public async Task<IActionResult> AuthenticateUser([FromBody] UserCredentialDTO userCredential)
        {
            var token = _userRepository.Authenticate(userCredential.Email, userCredential.Password);
            if (token == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(new { token });
        }

        [AllowAnonymous]
        [HttpPost("checktoken/{token}")]
        public async Task<IActionResult> CheckToken(string token)
        {
            var tokenIsValid = _userRepository.CheckToken(token);
            if (!tokenIsValid)
                return Unauthorized(new { message = "Token invalid" });

            return Ok(new { token });
        }
    }
}
