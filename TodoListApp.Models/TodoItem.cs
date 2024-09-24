using System.ComponentModel.DataAnnotations;

namespace TodoListApp.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "The Name field is required.")]
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}
