namespace Application.Common.Interfaces;

public interface IJwtTokenService
{
    string GenerateToken(string accountId, string role);
}
