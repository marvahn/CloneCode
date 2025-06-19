using CloneCode.Application.DTOs.Response;
using CloneCode.Entity;

namespace CloneCode.Application.Interface
{
    public interface ISupabaseService
    {
        Task<List<ResponseBook>> GetBookAsync();
    }
}
