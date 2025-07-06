using CloneCode.Application.DTOs.Response;
using CloneCode.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CloneCode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private ISupabaseService _supabaseService;
        public BookController(ISupabaseService supabaseService)
        {
            _supabaseService = supabaseService;
        }

        [HttpGet(Name = "BookGet")]
        public async Task<List<ResponseBook>> BookGet()
        {
            return await _supabaseService.GetBookAsync();
        }
    }
}