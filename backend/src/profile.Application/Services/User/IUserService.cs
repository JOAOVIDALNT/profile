using profile.Application.DTOs.Subscriber;
using profile.Application.DTOs.User.Register;

namespace profile.Application.Services.User;

public interface IUserService
{
    Task Register(UserRegisterRequest request);
    Task Subscribe(SubscribeRequest request);
}