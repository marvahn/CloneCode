using CloneCode.Application.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace CloneCode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : Controller
    {
        private ITokenService _tokenService;

        public TokenController(ITokenService tokenService)
        {
            _tokenService = tokenService;
        }

        [HttpGet(Name = "AccessToken")]

        public string AccessToken()
        {
            return JsonSerializer.Serialize(new { accesstoken = _tokenService.GenerateToken("id0123") });
        }
    }
}
