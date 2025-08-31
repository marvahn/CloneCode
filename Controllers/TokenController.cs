using CloneCode.Application.DTOs.Request;
using CloneCode.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CloneCode.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TokenController : Controller
    {
        private ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpPost(Name = "AccessToken")]

        public async Task<string> AccessToken([FromBody] RequestToken requestData)
        {
            return JsonSerializer.Serialize(new { accessToken = await _tokenService.GenerateToken(requestData.UserId), refreshToken = _tokenService.GenerateRefreshToken() });
        }
    }
}
