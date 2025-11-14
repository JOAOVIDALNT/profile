namespace profile.Application.DTOs.User.Subscribe;

public record SubscribeRequest(string email, Guid authorId);