using backend.Interface;
using backend.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteController(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        // GET: api/Paciente
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetAll()
        {
            var pacientes = await _pacienteRepository.GetAll();
            return Ok(pacientes);
        }

        // GET: api/Paciente/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetById(int id)
        {
            var paciente = await _pacienteRepository.GetById(id);
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente); 
        }

        // GET: api/Paciente/documento/{documento}
        [HttpGet("documento/{documento}")]
        public async Task<ActionResult<Paciente>> GetByDocumento(string documento)
        {
            var paciente = await _pacienteRepository.GetByDocumento(documento);
            if (paciente == null)
            {
                return NotFound();
            }
            return Ok(paciente); 
        }

        // POST: api/Paciente
        [HttpPost]
        public async Task<ActionResult<Paciente>> Post(Paciente paciente)
        {
            await _pacienteRepository.Add(paciente);
            return CreatedAtAction(nameof(GetById), new { id = paciente.Id }, paciente);
        }

        // PUT: api/Paciente/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest();
            }

            try
            {
                await _pacienteRepository.Update(paciente);
            }
            catch
            {
                return NotFound();
            }

            return NoContent();
        }
        
        // DELETE: api/Paciente/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var paciente = await _pacienteRepository.GetById(id);
            if (paciente == null)
            {
                return NotFound();
            }

            await _pacienteRepository.Delete(id); 
            return NoContent(); 
        }
    }
}
