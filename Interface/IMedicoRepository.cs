using backend.Model;

namespace backend.Interface
{
    public interface IMedicoRepository
    {
        Task<IEnumerable<Medico>> GetAll();
        Task<Medico> GetById(int id);
        Task<Medico> GetByEspecialidad(string especialidad);
        Task Add(Medico medico);
        Task Update(Medico medico);
        Task Delete(int id);
    }
}
