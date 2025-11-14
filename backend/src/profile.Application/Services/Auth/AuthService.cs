using profile.Application.DTOs.Auth.Login;
using valet.lib.Auth.Domain.Interfaces;
using valet.lib.Auth.Domain.Interfaces.Repositories;

namespace profile.Application.Services.Auth;

public class AuthService(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    ITokenGenerator tokenGenerator)
    : IAuthService
{
    public async Task<UserLoginResponse> Login(UserLoginRequest request)
    {
        // TODO: VALIDATE
        
        var user = await userRepository.GetAsync(x => x.Email == request.email, false);
        
        if (user == null)
            throw new Exception("User not found"); // TODO: CUSTOM EXCPETIONSS
        
        if (!passwordHasher.VerifyPassword(request.password, user.Password))
            throw new Exception("Invalid password");

        var token = tokenGenerator.GenerateToken(user);

        return new UserLoginResponse(token);
    }   
}