using Application.Dtos.Input;
using Application.Interfaces;

namespace Application.AppServices;

public sealed class AuthenticationAppService : IAuthenticationAppService
{
    // Example method to authenticate a user
    public bool Authenticate(LoginDto loginDto)
    {
        return loginDto != null;
    }
}