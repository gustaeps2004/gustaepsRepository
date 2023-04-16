using EmployeeAPI.Context;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace EmployeeAPI.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly AppdbContext _context;

        public EmployeeRepository(AppdbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var employees = await _context.Employees.AsNoTracking().Include(a => a.Office)
                        .Include(a => a.Adress).OrderBy(a => a.EmployeeId).ToListAsync();
            return employees;
        }

        public async Task<Employee> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.Include(a => a.Adress)
                    .Include(a => a.Office).FirstOrDefaultAsync(a => a.EmployeeId == id);
            return employee!;
        }       

        public async Task CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            await Commit();
        }

        public async Task UpdateEmployee(Employee employee)
        {
            _context.Entry(employee).State = EntityState.Modified;
            _context.Set<Employee>().Update(employee);

            await Commit();
        }

        public async Task Delete(int id)
        {
            var employee = await GetEmployeeById(id);

            if (employee.Adress is null)
            {
                _context.Employees.Remove(employee);
                await Commit();
            }
            else
            {
                await DeleteAdress(id);
                _context.Employees.Remove(employee);
                await Commit();                
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
        }

        private async Task DeleteAdress(int id)
        {
            var employee = _context.Employees.Include(a => a.Adress).First(a => a.EmployeeId == id);

            _context.Adresses.Remove(employee.Adress!);
            await Commit();
        }
    }
}
