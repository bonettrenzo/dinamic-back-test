using backend.Context;
using backend.Model;
using backend.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly AppDbContext _context;

        public PacienteRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Paciente>> GetAll()
        {
            return await _context.Pacientes.ToListAsync();
        }

        public async Task<Paciente> GetById(int id)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Paciente> GetByDocumento(string documento)
        {
            return await _context.Pacientes.FirstOrDefaultAsync(p => p.Documento == documento);
        }

        public async Task Add(Paciente paciente)
        {
            await _context.Pacientes.AddAsync(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente != null)
            {
                _context.Pacientes.Remove(paciente);
                await _context.SaveChangesAsync();
            }
        }
    }
}
