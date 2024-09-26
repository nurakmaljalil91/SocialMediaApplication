using Application.Common.Models;

namespace Application.Common.Interfaces;

public interface IIdentityService
{
    Task<string> GetUserNameAsync(string userName);

    Task<bool> IsInRoleAsync(string userName, string role);

    Task<bool> AuthorizeAsync(string userName, string policyName);

    Task<(Result Result, string UserName)> CreateUserAsync(string userName, string password);

    Task<Result> DeleteUserAsync(string userName);

}
