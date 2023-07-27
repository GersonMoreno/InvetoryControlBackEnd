namespace InventoryControl.Domain.Base
{
    using InventoryControl.Domain.Contracts;
   
    using System.Threading.Tasks;

    public interface IUnitOfWork
    {
        IGenericRepository<T> GenericRepository<T>() where T : class;

        //IEmpleadoContratoRepositorio EmpleadoContratoRepositorio { get; }
        Task BeginTransaction();

        Task Commit();
        Task Rollback();
    }
}
