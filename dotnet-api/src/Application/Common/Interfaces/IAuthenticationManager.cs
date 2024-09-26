// using Domain.Enums;

namespace Application.Common.Interfaces;

public interface IAuthenticationManager
{
    Task<string> CreateToken();
    // Task<AuthenticationStatus> ValidateUser(string userName, string password);
    Task<bool> CheckUserNameExists(string userName);
    Task<bool> CheckEmailExists(string email);
    Task<IList<string>> GetUserRoles(string userName);
    Task<string> GetEmail(string userName);
    // Task<RegistrationStatus> RegisterNewUser(string userName, string password, string email, int role, string phoneNumber);
    // Task<ChangePasswordStatus> ChangePassword(string userName, string oldPassword, string confirmPassword, string newPassword);

}
