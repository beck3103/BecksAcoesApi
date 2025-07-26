using Application.Dtos.Input;

namespace Application.Interfaces;

public interface IAuthenticationAppService
{
    bool Authenticate(LoginDto loginDto);
}