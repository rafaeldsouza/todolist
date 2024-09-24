using Microsoft.AspNetCore.Mvc;
using TodoListApp.Business.Services.Interfaces;
using TodoListApp.Models;

namespace TodoListApp.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _todoService;

        public TodoController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        public async Task<IActionResult> Index()
        {
            var todos = await _todoService.GetAllTodosAsync();
            return View(todos);
        }

        [HttpPost]
        public async Task<IActionResult> Create(TodoItem item)
        {
            if (ModelState.IsValid)
            {
                await _todoService.AddTodoAsync(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(TodoItem item)
        {
            if (ModelState.IsValid)
            {
                await _todoService.UpdateTodoAsync(item);
                return RedirectToAction(nameof(Index));
            }
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            await _todoService.DeleteTodoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
