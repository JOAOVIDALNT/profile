using profile.Application.DTOs.User.Login;
using profile.Application.DTOs.User.Signup;

namespace profile.Application.Services.User;

public class UserService : IUserService
{
    public Task Signup(UserSignupRequest request)
    {
        throw new NotImplementedException();
    }

    public Task<UserLoginResponse> Login(UserLoginRequest request)
    {
        throw new NotImplementedException();
    }
}