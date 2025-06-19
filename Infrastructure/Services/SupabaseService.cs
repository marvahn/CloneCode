using CloneCode.Application.DTOs.Response;
using CloneCode.Application.Interface;
using CloneCode.Domains.Models;
using Supabase;

namespace CloneCode.Infrastructure.Services
{
    public class SupabaseService : ISupabaseService
    {
        private readonly Client _supabase;

        public SupabaseService(Client supabase)
        {
            _supabase = supabase;
        }

        public async Task<List<ResponseBook>> GetBookAsync()
        {
            var response = await _supabase.From<Book>().Get();

            return response.Models.Select(p => new ResponseBook
            {
                Title = p.Title
            }).ToList();

        }
    }
}
