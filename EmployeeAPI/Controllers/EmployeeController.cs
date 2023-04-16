using EmployeeAPI.Models;
using EmployeeAPI.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace EmployeeAPI.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeController(IEmployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<Employee>> GetEmployees()
        {
            try
            {
                var employees = await _repository.GetEmployees();
                return Ok(employees);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        [HttpGet("{id:int:min(1)}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            try
            {
                var employee = await _repository.GetEmployeeById(id);

                if(employee is null)
                {
                    return BadRequest($"Não existe funcionário com o id({id})");
                }

                return Ok(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Ocorreu um problema ao tratar a sua solicitação.");
            }           
        }

        [HttpPost("CreateEmployee")]
        public async Task<ActionResult> CreateEmployee(Employee employee)
        {
            try
            {
                if (!ValidaEmail(employee.Email))
                {
                    return BadRequest("Endereço de email inserido incorretamente, favor verificar");
                }

                if (!ValidaCpf(employee.Cpf))
                {
                    return BadRequest("O cpf informado é falso, favor vericar");
                }

                employee.Password = CriaMD5(employee.Password);

                await _repository.CreateEmployee(employee);
                await _repository.Commit();
                return Ok($"Usuário {employee.UserName} criado");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                        "Ocorreu um problema ao tratar a sua solicitação.");
            }           
        }

        [HttpPut("UpdateEmloyee/{id:int:min(1)}")]
        public async Task<ActionResult> UpdateEmployee(int id, Employee employee)
        {
            try
            {
                if (id != employee.EmployeeId)
                {
                    return BadRequest("Os id's informados são diferentes, favor verificar");
                }

                await _repository.UpdateEmployee(employee);
                await _repository.Commit();

                return Ok("Dados atualizados com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Ocorreu um problema ao tratar a sua solicitação.");
            }           
        }

        [HttpDelete("DeleteEmployee/{id:int:min(1)}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var employee = await _repository.GetEmployeeById(id);
                if(employee is null)
                {
                    return BadRequest($"Funcionário com o id({id}) não existe");
                }
                await _repository.Delete(id);
                await _repository.Commit();

                return Ok($"Funcionário {employee.UserName} deletado com com sucesso");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                       "Ocorreu um problema ao tratar a sua solicitação.");
            }
        }

        private bool ValidaCpf(string cpf)
        {
            cpf = Regex.Replace(cpf, @"\D", "");

            if ((cpf == "11111111111") || (cpf == "22222222222") || (cpf == "33333333333") || (cpf == "44444444444") || (cpf == "55555555555") ||
                (cpf == "66666666666") || (cpf == "77777777777") || (cpf == "88888888888") || (cpf == "99999999999") || (cpf == "00000000000"))
            {
                return false;
            }

            if (cpf.Length != 11)
                return false;

            int soma = 0;
            for (int i = 0; i < 9; i++)
                soma += int.Parse(cpf[i].ToString()) * (10 - i);
            int resto = soma % 11;
            int digito1 = resto < 2 ? 0 : 11 - resto;

            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(cpf[i].ToString()) * (11 - i);
            resto = soma % 11;
            int digito2 = resto < 2 ? 0 : 11 - resto;

            return cpf.EndsWith(digito1.ToString() + digito2.ToString());
        }

        private bool ValidaEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        private string CriaMD5(string senha)
        {
            return BitConverter.ToString(MD5.Create().
                   ComputeHash(Encoding.ASCII.GetBytes(senha))).Replace("-", "").ToString();
        }
    }
}
