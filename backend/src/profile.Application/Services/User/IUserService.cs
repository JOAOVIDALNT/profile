using profile.Application.DTOs.User.Login;
using profile.Application.DTOs.User.Signup;

namespace profile.Application.Services.User;

public interface IUserService
{
    Task Signup(UserSignupRequest request);
    Task<UserLoginResponse> Login(UserLoginRequest request);
}