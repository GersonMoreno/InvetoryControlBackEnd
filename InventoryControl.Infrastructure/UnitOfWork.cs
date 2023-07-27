using InventoryControl.Domain.Base;
using InventoryControl.Domain.Contracts;
using InventoryControl.Infrastructure.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IControlContext _iControlContext;
        public UnitOfWork(IControlContext iControlContext)
        {
            _iControlContext = iControlContext;
        }
        public IGenericRepository<T> GenericRepository<T>() where T : class
        {
            return new GenericRepository<T>(_iControlContext);
        }
        public async Task BeginTransaction()
        {
            await _iControlContext.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            //await _vecidadContext.SaveChangesAsync();
            try
            {
                _iControlContext.SaveChanges();
                await _iControlContext.Database.CommitTransactionAsync();
            }
            catch (Exception e)
            {
            }
        }

        public async Task Rollback()
        {
            await _iControlContext.Database.RollbackTransactionAsync();
        }

    }
}
