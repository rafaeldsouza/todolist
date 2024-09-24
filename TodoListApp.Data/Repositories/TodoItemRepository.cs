using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoListApp.Data.Context;
using TodoListApp.Data.Repositories.Interfaces;
using TodoListApp.Models;

namespace TodoListApp.Data.Repositories
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly TodoContext _context;
        private readonly DbSet<TodoItem> _dbSet;

        public TodoItemRepository(TodoContext context)
        {
            _context = context;
            _dbSet = _context.Set<TodoItem>();
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<TodoItem> GetByIdAsync(int id) => await _dbSet.FindAsync(id);
        public async Task AddAsync(TodoItem entity) => await _dbSet.AddAsync(entity);
        public void Update(TodoItem entity) => _dbSet.Update(entity);
        public void Delete(TodoItem entity) => _dbSet.Remove(entity);
    }
}
