using profile.Application.DTOs.User.Subscribe;
using profile.Application.DTOs.User.Register;
using profile.Application.DTOs.User.Subscribers;

namespace profile.Application.Services.User;

public interface IUserService
{
    Task Register(UserRegisterRequest request);
    Task Subscribe(SubscribeRequest request);
    Task<ListSubscribersResponse> ListSubscribers();
}