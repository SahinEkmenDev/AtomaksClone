using Microsoft.AspNetCore.Mvc;

namespace AtomaksClone.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly string adminUsername = "admin";
        private readonly string adminPassword = "123456"; // production için env'de tut

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Username == adminUsername && request.Password == adminPassword)
            {
                return Ok(new { message = "Giriş başarılı" });
            }

            return Unauthorized(new { message = "Geçersiz kullanıcı adı veya şifre" });
        }
    }

    public class LoginRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
