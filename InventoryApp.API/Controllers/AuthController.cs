using InventoryApp.Application.Auth;
using Microsoft.AspNetCore.Mvc;

namespace InventoryApp.API.Controllers
{
    /// <summary>
    /// Handles authentication-related operations.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ITokenService _tokenService;

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthController"/> class.
        /// </summary>
        /// <param name="tokenService">Service for generating JWT tokens.</param>
        public AuthController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        /// <summary>
        /// Authenticates a user and returns a JWT token if successful.
        /// </summary>
        /// <param name="request">Login credentials (username and password).</param>
        /// <returns>A JWT token if authentication is successful; otherwise, Unauthorized.</returns>
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Username == "admin" && request.Password == "admin")
            {
                var token = _tokenService.GenerateJwtToken(request.Username);
                return Ok(new { token });
            }
            return Unauthorized("Invalid credentials");
        }
    }
}
