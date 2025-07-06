using CloneCode.Application.DTOs.Response;

namespace CloneCode.Application.Interface
{
    public interface ISupabaseService
    {
        Task<List<ResponseBook>> GetBookAsync();
    }
}
