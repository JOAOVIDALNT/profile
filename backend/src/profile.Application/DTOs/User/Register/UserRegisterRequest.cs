namespace profile.Application.DTOs.User.Register;

public record UserRegisterRequest(string firtsName, string lastName, string email, string password);