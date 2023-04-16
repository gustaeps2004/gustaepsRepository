namespace EmployeeAPI.Repository
{
    public interface IUnitOfWork
    {
        IPositionsRepository PositionsRepository { get; }
        IAdressRepository AdressRepository { get; }

        Task Commit();
    }
}
