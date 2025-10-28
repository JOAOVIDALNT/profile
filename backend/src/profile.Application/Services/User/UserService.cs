using profile.Application.DTOs.User.Login;
using profile.Application.DTOs.User.Signup;
using profile.Domain.Entities;
using valet.lib.Auth.Domain.Entities;
using valet.lib.Auth.Domain.Interfaces;
using valet.lib.Auth.Domain.Interfaces.Repositories;
using valet.lib.Core.Domain.Interfaces;

namespace profile.Application.Services.User;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IRoleRepository _roleRepository;

    public UserService(IUserRepository userRepository, IUnitOfWork unitOfWork, IPasswordHasher passwordHasher,  IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
        _passwordHasher = passwordHasher;
        _roleRepository = roleRepository;
    }

    public async Task Signup(UserSignupRequest request)
    {
        // TODO: VALIDATE
        
        var user = new LocalUser(request.firtsName, request.lastName, request.email, request.password);
        
        user.UpdatePassword(_passwordHasher.HashPassword(request.password));

        var role = await RoleHandler();
        
        user.AddUserRole(new UserRole(user, role));
        
        await _userRepository.CreateAsync(user);
        await _unitOfWork.CommitAsync();
    }

    public async Task<UserLoginResponse> Login(UserLoginRequest request)
    {
        throw new NotImplementedException();
    }

    private async Task<Role> RoleHandler()
    {
        if (!_roleRepository.RoleExistsAsync("user").GetAwaiter().GetResult())
        {
            var role = new Role("user");
            await _roleRepository.CreateAsync(role);
            await _unitOfWork.CommitAsync();
            return role;
        }
        return await _roleRepository.GetAsync(x => x.Name == "user");
    }
}