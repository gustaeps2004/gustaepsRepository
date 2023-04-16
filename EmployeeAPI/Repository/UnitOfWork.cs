using EmployeeAPI.Context;

namespace EmployeeAPI.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private PositionsRepository _positionsRepo;
        private AdressRepository _adressRepo;
        public AppdbContext _context { get; set; }

        public UnitOfWork(AppdbContext context)
        {
            _context = context;
        }

        public IPositionsRepository PositionsRepository
        {
            get
            {
                return _positionsRepo = _positionsRepo ?? new PositionsRepository(_context);
            }
        }

        public IAdressRepository AdressRepository
        {
            get
            {
                return _adressRepo = _adressRepo ?? new AdressRepository(_context);
            }
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();  
        }
    }
}
