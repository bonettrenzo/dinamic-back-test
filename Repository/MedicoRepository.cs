using backend.Context;
using backend.Model;
using backend.Interface;
using Microsoft.EntityFrameworkCore;

namespace backend.Repository
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly AppDbContext _context;

        public MedicoRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Medico>> GetAll()
        {
            return await _context.Medicos.ToListAsync();
        }

        public async Task<Medico> GetById(int id)
        {
            return await _context.Medicos.FirstOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Medico> GetByEspecialidad(string especialidad)
        {
            return await _context.Medicos.FirstOrDefaultAsync(m => m.Especialidad == especialidad);
        }

        public async Task Add(Medico medico)
        {
            await _context.Medicos.AddAsync(medico);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Medico medico)
        {
            _context.Medicos.Update(medico);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var medico = await _context.Medicos.FindAsync(id);
            if (medico != null)
            {
                _context.Medicos.Remove(medico);
                await _context.SaveChangesAsync();
            }
        }
    }
}
