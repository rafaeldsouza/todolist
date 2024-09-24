using Moq;
using TodoListApp.Business.Services;
using TodoListApp.Data.UnitOfWorks.Interfaces;
using TodoListApp.Models;
using TodoListApp.Data.Repositories.Interfaces;

namespace TodoListApp.Tests
{
    [TestFixture]
    public class TodoServiceTests
    {
        private TodoService _todoService;
        private Mock<ITodoItemUnitOfWork> _mockUnitOfWork;
        private Mock<ITodoItemRepository> _mockTodoRepository;

        [SetUp]
        public void Setup()
        {
            _mockUnitOfWork = new Mock<ITodoItemUnitOfWork>();
            _mockTodoRepository = new Mock<ITodoItemRepository>();

            _mockUnitOfWork.Setup(u => u.TodoRepository).Returns(_mockTodoRepository.Object);

            _todoService = new TodoService(_mockUnitOfWork.Object);
        }

        [Test]
        public async Task GetAllTodosAsync_ShouldReturnAllTodos()
        {
            // Arrange
            var todos = new List<TodoItem>
            {
                new TodoItem { Id = 1, Name = "Test Todo 1" },
                new TodoItem { Id = 2, Name = "Test Todo 2" }
            }.AsQueryable();

            _mockTodoRepository.Setup(r => r.GetAllAsync()).ReturnsAsync(todos);

            // Act
            var result = await _todoService.GetAllTodosAsync();

            // Assert
            Assert.AreEqual(2, result.Count());
        }

        [Test]
        public async Task GetTodoByIdAsync_ShouldReturnCorrectTodo()
        {
            // Arrange
            var todo = new TodoItem { Id = 1, Name = "Test Todo" };
            _mockTodoRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(todo);

            // Act
            var result = await _todoService.GetTodoByIdAsync(1);

            // Assert
            Assert.AreEqual(todo, result);
        }

        [Test]
        public async Task AddTodoAsync_ShouldAddTodo()
        {
            // Arrange
            var todo = new TodoItem { Id = 1, Name = "New Todo" };

            // Act
            await _todoService.AddTodoAsync(todo);

            // Assert
            _mockTodoRepository.Verify(r => r.AddAsync(todo), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task UpdateTodoAsync_ShouldUpdateTodo()
        {
            // Arrange
            var todo = new TodoItem { Id = 1, Name = "Updated Todo" };

            // Act
            await _todoService.UpdateTodoAsync(todo);

            // Assert
            _mockTodoRepository.Verify(r => r.Update(todo), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteTodoAsync_ShouldDeleteTodo()
        {
            // Arrange
            var todo = new TodoItem { Id = 1, Name = "Test Todo" };
            _mockTodoRepository.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(todo);

            // Act
            await _todoService.DeleteTodoAsync(1);

            // Assert
            _mockTodoRepository.Verify(r => r.Delete(todo), Times.Once);
            _mockUnitOfWork.Verify(u => u.SaveChangesAsync(), Times.Once);
        }

        [Test]
        public async Task DeleteTodoAsync_ShouldThrowException_WhenTodoNotFound()
        {
            // Arrange
            _mockTodoRepository.Setup(r => r.GetByIdAsync(It.IsAny<int>())).ReturnsAsync((TodoItem)null);

            // Act & Assert
            var ex = Assert.ThrowsAsync<KeyNotFoundException>(async () => await _todoService.DeleteTodoAsync(1));
            Assert.That(ex.Message, Is.EqualTo("TodoItem not found"));
        }
    }
}
