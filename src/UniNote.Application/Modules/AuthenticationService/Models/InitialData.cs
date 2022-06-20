using UniNote.Application.Dtos;

namespace UniNote.Application.Modules.AuthenticationService.Models;

public class InitialData
{
    public string TokenRefresh { get; set; } = "";
    public string TokenAccess { get; set; } = "";
    public UserDto User { get; set; }

    public InitialData()
    {
    }

    public InitialData(string tokenRefresh, string tokenAccess, UserDto user)
    {
        TokenRefresh = tokenRefresh;
        TokenAccess = tokenAccess;
        User = user;
    }
}