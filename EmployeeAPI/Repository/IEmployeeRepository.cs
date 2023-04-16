using EmployeeAPI.Models;

namespace EmployeeAPI.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee> GetEmployeeById(int id);
        Task CreateEmployee(Employee employee);
        Task UpdateEmployee(Employee employee);
        Task Delete(int id);

        Task Commit();
    }
}
