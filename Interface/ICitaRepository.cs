using backend.Model;

namespace backend.Interface
{
    public interface ICitaRepository
    {
        Task<IEnumerable<Cita>> GetAll();
        Task<Cita> GetById(int id);
        Task<IEnumerable<Cita>> GetByMedicoId(int medicoId);
        Task<IEnumerable<Cita>> GetByEspecialidad(string especialidad);
        Task Add(Cita cita);
        Task Update(Cita cita);
        Task Delete(int id);
        Task UpdateEstado(int id, string estado);

    }
}
