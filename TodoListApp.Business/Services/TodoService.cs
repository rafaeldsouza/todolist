using TodoListApp.Business.Services.Interfaces;
using TodoListApp.Data.UnitOfWorks.Interfaces;
using TodoListApp.Models;

namespace TodoListApp.Business.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoItemUnitOfWork _unitOfWork;

        public TodoService(ITodoItemUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<TodoItem>> GetAllTodosAsync() => await _unitOfWork.TodoRepository.GetAllAsync();
        public async Task<TodoItem> GetTodoByIdAsync(int id) => await _unitOfWork.TodoRepository.GetByIdAsync(id);
        public async Task AddTodoAsync(TodoItem item)
        {
            await _unitOfWork.TodoRepository.AddAsync(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task UpdateTodoAsync(TodoItem item)
        {
            _unitOfWork.TodoRepository.Update(item);
            await _unitOfWork.SaveChangesAsync();
        }
        public async Task DeleteTodoAsync(int id)
        {
            var item = await _unitOfWork.TodoRepository.GetByIdAsync(id);
            if (item != null)
            {
                _unitOfWork.TodoRepository.Delete(item);
                await _unitOfWork.SaveChangesAsync();
            }
            else
                throw new KeyNotFoundException("TodoItem not found");
            
        }
    }
}
