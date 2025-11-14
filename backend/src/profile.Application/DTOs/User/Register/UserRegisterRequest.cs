namespace profile.Application.DTOs.User.Register;

public record UserRegisterRequest(string firstName, string lastName, string email, string password);