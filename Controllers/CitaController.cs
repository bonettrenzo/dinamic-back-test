using backend.Model;
using backend.Interface;
using Microsoft.AspNetCore.Mvc;
using backend.DTOs;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        private readonly ICitaRepository _citaRepository;

        public CitaController(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cita>>> GetAll()
        {
            var citas = await _citaRepository.GetAll();
            return Ok(citas);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cita>> GetById(int id)
        {
            var cita = await _citaRepository.GetById(id);
            if (cita == null)
            {
                return NotFound();
            }
            return Ok(cita);
        }

        [HttpGet("medico/{medicoId}")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetByMedicoId(int medicoId)
        {
            var citas = await _citaRepository.GetByMedicoId(medicoId);
            return Ok(citas);
        }

        [HttpGet("especialidad/{especialidad}")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetByEspecialidad(string especialidad)
        {
            var citas = await _citaRepository.GetByEspecialidad(especialidad);
            return Ok(citas);
        }

        [HttpPost]
        public async Task<ActionResult<Cita>> Create([FromBody] CitaCreateDTO citaDto)
        {
            var cita = new Cita
            {
                Especialidad = citaDto.Especialidad,
                FechaHora = citaDto.FechaHora,
                Estado = citaDto.Estado,
                IdMedico = citaDto.IdMedico
            };

            await _citaRepository.Add(cita);
            return CreatedAtAction(nameof(GetById), new { id = cita.Id }, cita);
        }
    

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Cita cita)
        {
            if (id != cita.Id)
            {
                return BadRequest("El ID de la cita no coincide.");
            }

            await _citaRepository.Update(cita);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cita = await _citaRepository.GetById(id);
            if (cita == null)
            {
                return NotFound();
            }

            await _citaRepository.Delete(id);
            return NoContent();
        }
    }
}
