namespace backend.Repository;

using backend.Context;
using backend.Model;
using Microsoft.EntityFrameworkCore;

public class AuthRepository : IAuthRepository
{
    private readonly AppDbContext _context;

    public AuthRepository(AppDbContext context)
    {
        _context = context;
    }

    public Paciente? Login(string documento, DateTime fechaNacimiento)
    {
        return _context.Set<Paciente>()
            .FirstOrDefault(p => p.Documento == documento && p.FechaNacimiento.Date == fechaNacimiento.Date);
    }
}
