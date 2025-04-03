using backend.Model;
using backend.Interface;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        private readonly IMedicoRepository _medicoRepository;

        public MedicoController(IMedicoRepository medicoRepository)
        {
            _medicoRepository = medicoRepository;
        }

        // Obtener todos los médicos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Medico>>> GetAll()
        {
            var medicos = await _medicoRepository.GetAll();
            return Ok(medicos);
        }

        // Obtener un médico por su ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Medico>> GetById(int id)
        {
            var medico = await _medicoRepository.GetById(id);
            if (medico == null)
            {
                return NotFound();
            }
            return Ok(medico);
        }

        // Obtener un médico por especialidad
        [HttpGet("especialidad/{especialidad}")]
        public async Task<ActionResult<Medico>> GetByEspecialidad(string especialidad)
        {
            var medico = await _medicoRepository.GetByEspecialidad(especialidad);
            if (medico == null)
            {
                return NotFound();
            }
            return Ok(medico);
        }

        // Crear un nuevo médico
        [HttpPost]
        public async Task<ActionResult<Medico>> Create(Medico medico)
        {
            await _medicoRepository.Add(medico);
            return CreatedAtAction(nameof(GetById), new { id = medico.Id }, medico);
        }

        // Actualizar los datos de un médico
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Medico medico)
        {
            if (id != medico.Id)
            {
                return BadRequest();
            }

            await _medicoRepository.Update(medico);
            return NoContent();
        }

        // Eliminar un médico
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var medico = await _medicoRepository.GetById(id);
            if (medico == null)
            {
                return NotFound();
            }

            await _medicoRepository.Delete(id);
            return NoContent();
        }
    }
}
