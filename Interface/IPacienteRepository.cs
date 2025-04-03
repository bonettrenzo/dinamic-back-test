using backend.Model;

namespace backend.Interface
{
    public interface IPacienteRepository
    {
        Task<IEnumerable<Paciente>> GetAll();
        Task<Paciente> GetById(int id);
        Task<Paciente> GetByDocumento(string documento);
        Task Add(Paciente paciente);
        Task Update(Paciente paciente);
        Task Delete(int id);

    }
}
