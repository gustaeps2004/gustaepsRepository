using EmployeeAPI.Models;
using EmployeeAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly IUnitOfWork _uof;

        public PositionsController(IUnitOfWork uof)
        {
            _uof = uof;
        }       

        [HttpGet]
        public ActionResult<IEnumerable<Positions>> Get()
        {
            try
            {
                var positions = _uof.PositionsRepository.Get().ToList();
                return positions;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpGet("WithEmployee")]
        public ActionResult<IEnumerable<Positions>> GetEmployee()
        {
            try
            {
                return _uof.PositionsRepository.GetPositionsEmployee().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<ActionResult> GetById(int id)
        {
            try
            {
                var position = await _uof.PositionsRepository.GetById(a => a.OfficeId == id);
                if (position is null)
                    return BadRequest($"O cargo com id({id}) não existe.");

                return Ok(position);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpPost("CreatePosition")]
        public async Task<ActionResult> CreatePosition(Positions position)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(position.Description))
                    return BadRequest("O cargo não pode ser nulo.");

                _uof.PositionsRepository.Add(position);
                await _uof.Commit();

                return Ok($"Cargo {position.Description} criado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpPut("UpdatePosition/{id:int:min(1)}")]
        public async Task<ActionResult> UpdatePosition(int id, Positions position)
        {
            if (position.OfficeId != id || String.IsNullOrWhiteSpace(position.Description))
                return BadRequest("Cargo vazio ou parâmetros enviados incorretamente.");

            _uof.PositionsRepository.Update(position);
            await _uof.Commit();

            return Ok($"Cargo {position.Description} atualizado com sucesso.");
        }
    }
}
