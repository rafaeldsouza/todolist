using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Models;

namespace TodoListApp.Business.Services.Interfaces
{
    public interface ITodoService
    {
        Task<IEnumerable<TodoItem>> GetAllTodosAsync();
        Task<TodoItem> GetTodoByIdAsync(int id);
        Task AddTodoAsync(TodoItem item);
        Task UpdateTodoAsync(TodoItem item);
        Task DeleteTodoAsync(int id);
    }
}
