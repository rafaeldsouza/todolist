using TodoListApp.Data.Context;
using TodoListApp.Data.Repositories;
using TodoListApp.Data.Repositories.Interfaces;
using TodoListApp.Data.UnitOfWorks.Interfaces;
using TodoListApp.Models;

namespace TodoListApp.Data.UnitOfWorks
{
    public class TodoItemUnitOfWork : ITodoItemUnitOfWork
    {     

        private readonly TodoContext _context;
        private ITodoItemRepository _todoRepository;

        public TodoItemUnitOfWork(TodoContext context)
        {
            _context = context;
        }

        public IRepository<TodoItem> TodoRepository => _todoRepository ??= new TodoItemRepository(_context);
      

        public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();

        public void Dispose() => _context.Dispose();
    }
}
