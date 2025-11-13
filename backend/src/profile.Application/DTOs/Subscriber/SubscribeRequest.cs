namespace profile.Application.DTOs.Subscriber;

public record SubscribeRequest(string email, Guid authorId);