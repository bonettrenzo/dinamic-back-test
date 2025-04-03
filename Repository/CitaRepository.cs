using backend.Context;
using backend.Model;
using backend.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class CitaRepository : ICitaRepository
    {
        private readonly AppDbContext _context;

        public CitaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cita>> GetAll()
        {
            return await _context.Citas.Include(c => c.Medico).ToListAsync();
        }

        public async Task<Cita> GetById(int id)
        {
            return await _context.Citas.Include(c => c.Medico)
                                       .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<Cita>> GetByMedicoId(int medicoId)
        {
            return await _context.Citas.Include(c => c.Medico)
                                       .Where(c => c.IdMedico == medicoId)
                                       .ToListAsync();
        }

        public async Task<IEnumerable<Cita>> GetByEspecialidad(string especialidad)
        {
            return await _context.Citas.Include(c => c.Medico)
                                       .Where(c => c.Especialidad == especialidad)
                                       .ToListAsync();
        }

        public async Task Add(Cita cita)
        {
            await _context.Citas.AddAsync(cita);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Cita cita)
        {
            _context.Citas.Update(cita);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var cita = await _context.Citas.FindAsync(id);
            if (cita != null)
            {
                _context.Citas.Remove(cita);
                await _context.SaveChangesAsync();
            }
        }
    }
}
