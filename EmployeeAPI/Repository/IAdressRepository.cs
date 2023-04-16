using EmployeeAPI.Models;

namespace EmployeeAPI.Repository
{
    public interface IAdressRepository : IRepository<Adress>
    {
        IEnumerable<Adress> GetAdressesWithEmployee();
    }
}
