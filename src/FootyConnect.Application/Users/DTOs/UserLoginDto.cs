namespace FootyConnect.Application.Users.DTOs;

public class UserLoginDto
{
    public UserDto User { get; set; } = new UserDto();  
    public string AccessToken { get; set; } = string.Empty; 
}
