namespace CloneCode.Application.Interface
{
    public interface ITokenService
    {
        Task<string> GenerateToken(string username);

        string GenerateRefreshToken(int length = 32);
    }
}
