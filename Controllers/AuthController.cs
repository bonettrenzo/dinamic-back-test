namespace backend.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthRepository _authRepository;

    public AuthController(IAuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] Model.LoginRequest request)
    {
        var usuario = _authRepository.Login(request.Documento, request.FechaNacimiento);

        if (usuario == null)
        {
            return Unauthorized(new { message = "Documento o fecha incorrectos"  });
        }

        return Ok(new
        {
            Id = usuario.Id,
            Nombres = usuario.Nombres,
            Apellidos = usuario.Apellidos,
            Documento = usuario.Documento
        });
    }
}
