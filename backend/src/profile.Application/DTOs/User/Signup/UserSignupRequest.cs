namespace profile.Application.DTOs.User.Signup;

public record UserSignupRequest(string firtsName, string lastName, string email, string password);