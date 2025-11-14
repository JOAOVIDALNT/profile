using Microsoft.EntityFrameworkCore;
using profile.Application.DTOs.User.Subscribe;
using profile.Application.DTOs.User.Register;
using profile.Application.DTOs.User.Subscribers;
using profile.Domain.Entities;
using profile.Domain.Interfaces.Repositories;
using valet.lib.Auth.Domain.Entities;
using valet.lib.Auth.Domain.Interfaces;
using valet.lib.Auth.Domain.Interfaces.Repositories;
using valet.lib.Core.Domain.Interfaces;

namespace profile.Application.Services.User;

public class UserService(
    ILocalUserRepository userRepository,
    IUnitOfWork unitOfWork,
    IPasswordHasher passwordHasher,
    IRoleRepository roleRepository,
    ISubscriptionRepository subscriptionRepository)
    : IUserService
{
    public async Task Register(UserRegisterRequest request)
    {
        // TODO: VALIDATE
        
        var user = new LocalUser(request.firstName, request.lastName, request.email, request.password);
        
        user.UpdatePassword(passwordHasher.HashPassword(request.password));

        var role = await RoleHandler();
        
        user.AddUserRole(new UserRole(user, role));
        
        await userRepository.CreateAsync(user);
        await unitOfWork.CommitAsync();
    }
    
    public async Task Subscribe(SubscribeRequest request)
    {
        // TODO: VALIDATE
        var author = await userRepository.GetAsync(x=> x.Id == request.authorId,
            include: q => q.Include(u => u.Subscribers));
        
        if (author == null)
            throw new ApplicationException("Author not found"); //TODO: CUSTOM EXCEPTION
        
        if (author.Subscribers.Any(x => x.Subscriber.Email == request.email))
            throw new ApplicationException("Email already registered");
        
        var subscriber = new Domain.Entities.Subscriber(request.email);
        
        var subscription = new Subscription(author, subscriber);
        
        await subscriptionRepository.CreateAsync(subscription);
        
        await unitOfWork.CommitAsync();
    }

    public async Task<ListSubscribersResponse> ListSubscribers()
    {
        var author = await userRepository
            .GetAsync(x => x.Email.Equals("joao.vidal@gmail.com"), 
                include: q => 
                q.Include(u => u.Subscribers)
                    .ThenInclude(s => s.Subscriber));
        
        return new ListSubscribersResponse(author.Subscribers.Select(x => x.Subscriber.Email).ToList());
    }

    private async Task<Role> RoleHandler()
    {
        if (!roleRepository.RoleExistsAsync("user").GetAwaiter().GetResult())
        {
            var role = new Role("user");
            await roleRepository.CreateAsync(role);
            await unitOfWork.CommitAsync();
            return role;
        }
        return await roleRepository.GetAsync(x => x.Name == "user");
    }
}