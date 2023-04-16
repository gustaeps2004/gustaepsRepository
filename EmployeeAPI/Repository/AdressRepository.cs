using EmployeeAPI.Context;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repository
{
    public class AdressRepository : Repository<Adress>, IAdressRepository
    {
        public AdressRepository(AppdbContext context) : base(context)
        {            
        }

        public IEnumerable<Adress> GetAdressesWithEmployee()
        {
            return Get().Include(a => a.Employee).ToList();
        }
    }
}
