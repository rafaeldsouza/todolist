using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data.Repositories.Interfaces;

namespace TodoListApp.Data.UnitOfWorks.Interfaces
{
    public interface IUnitOfWork<T> : IDisposable where T : class
    {
        IRepository<T> TodoRepository { get; }
        Task<int> SaveChangesAsync();
    }
}
