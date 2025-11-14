using profile.Application.DTOs.Auth.Login;

namespace profile.Application.Services.Auth;

public interface IAuthService
{
    Task<UserLoginResponse> Login(UserLoginRequest request);
}