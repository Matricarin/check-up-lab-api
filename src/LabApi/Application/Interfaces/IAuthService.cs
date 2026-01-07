using LabApi.Application.Dtos.Login;
using LabApi.Application.Dtos.Register;

namespace LabApi.Application.Interfaces;

public interface IAuthService
{
    Task<RegisterResponseDto?> CreateUser(RegisterRequestDto request);
    Task<LoginResponseDto?> LoginUser(LoginRequestDto request);
}