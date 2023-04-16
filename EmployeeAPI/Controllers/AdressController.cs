using EmployeeAPI.Models;
using EmployeeAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly IUnitOfWork _uof;
        private readonly IEmployeeRepository _repository;

        public AdressController(IUnitOfWork unitOfWork, IEmployeeRepository repository)
        {
            _uof = unitOfWork;
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Adress>> Get()
        {           
            try
            {
                return _uof.AdressRepository.Get().ToList();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
            
        }

        [HttpGet("WithEmployee")]
        public ActionResult<IEnumerable<Adress>> GetWithEmployee()
        {
            try
            {
                return _uof.AdressRepository.GetAdressesWithEmployee().ToList();
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
                var adress = await _uof.AdressRepository.GetById(a => a.AdressId == id);
                if (adress is null)
                    return BadRequest($"Endereço com o id({id}) não existe.");

                return Ok(adress);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpPost("CreateAdress/{id:int:min(1)}")]
        public async Task<ActionResult> CreateAdress(int id, Adress adress)
        {
            try
            {
                var verificaEmployee = await VerificaEmployee(id);
                if (!verificaEmployee)
                    return BadRequest($"Funcionário com id({id}) não existe.");

                adress.EmployeeId = id;
                _uof.AdressRepository.Add(adress);
                await _uof.Commit();

                return Ok("Endereço cadastrado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpPut("UpdateAdress/{id:int:min(1)}/{idEmployee:int:min(1)}")]
        public async Task<ActionResult> UpdateAdress(int id, int idEmployee, Adress adress)
        {
            try
            {
                if (adress.AdressId != id || adress.EmployeeId != idEmployee)
                    return BadRequest("Parâmetros enviados incorretamente, favor ferificar");

                _uof.AdressRepository.Update(adress);
                await _uof.Commit();

                return Ok("Endereço atualizado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpDelete("Delete/{id:int:min(1)}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var adress = await _uof.AdressRepository.GetById(a => a.AdressId == id);
                if (adress is null)
                    return BadRequest($"Endereço com id({id}) não encontrado.");

                _uof.AdressRepository.Delete(adress);
                await _uof.Commit();

                return Ok("Endereço deletado com sucesso.");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                   "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        private async Task<bool> VerificaEmployee(int id)
        {
            var employee = await _repository.GetEmployeeById(id);

            if(employee is null)
                return false;
            
            return true;
        }
    }
}
