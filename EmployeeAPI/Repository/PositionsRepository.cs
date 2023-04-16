using EmployeeAPI.Context;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Repository
{
    public class PositionsRepository : Repository<Positions>, IPositionsRepository
    {
        public PositionsRepository(AppdbContext context) : base(context)
        {
            
        }

        public IEnumerable<Positions> GetPositionsEmployee()
        {
            return Get().Include(a => a.Employee).ToList();
        }
    }
}
