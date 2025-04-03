
using backend.Model;

public interface IAuthRepository
{
    Paciente? Login(string documento, DateTime fechaNacimiento);
}
