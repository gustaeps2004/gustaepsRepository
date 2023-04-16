using EmployeeAPI.Models;

namespace EmployeeAPI.Repository
{
    public interface IPositionsRepository : IRepository<Positions>
    {
        IEnumerable<Positions> GetPositionsEmployee();
    }
}
