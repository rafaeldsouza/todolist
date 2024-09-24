using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Models;

namespace TodoListApp.Data.Repositories.Interfaces
{
    public interface ITodoItemRepository : IRepository<TodoItem>
    {
    }
}
