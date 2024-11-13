using System.Collections.ObjectModel;
using System.Linq;
using Xunit;

namespace ToDo_list.Tests
{
    public class TodoServiceTests
    {
        [Fact]
        public void AddTodo_ShouldAddTodo()
        {
            var todoService = new TodoService();

            var todo = todoService.AddTodo("Test Title", "Test Description");

            Assert.NotNull(todo);
            Assert.Equal(0, todo.Id);
            Assert.Equal("Test Title", todo.Title);
            Assert.Equal("Test Description", todo.Description);
            Assert.Single(todoService.GetAllTodos());
        }

        [Fact]
        public void GetAllTodos_ShouldReturnAllTodos()
        {
            var todoService = new TodoService();
            todoService.AddTodo("Title 1", "Description 1");
            todoService.AddTodo("Title 2", "Description 2");

            var todos = todoService.GetAllTodos();

            Assert.Equal(2, todos.Count);
            Assert.Contains(todos, t => t.Title == "Title 1" && t.Description == "Description 1");
            Assert.Contains(todos, t => t.Title == "Title 2" && t.Description == "Description 2");
        }

        [Fact]
        public void DeleteTodo_ShouldDeleteTodo()
        {
            var todoService = new TodoService();
            var todo = todoService.AddTodo("Test Title", "Test Description");

            var result = todoService.DeleteTodo(todo.Id);

            Assert.True(result);
            Assert.Empty(todoService.GetAllTodos());
        }

        [Fact]
        public void UpdateTodo_ShouldUpdateTodo()
        {
            var todoService = new TodoService();
            var todo = todoService.AddTodo("Test Title", "Test Description");

            var result = todoService.UpdateTodo(todo.Id, "Updated Title", "Updated Description");

            Assert.True(result);
            var updatedTodo = todoService.GetAllTodos().First();
            Assert.Equal("Updated Title", updatedTodo.Title);
            Assert.Equal("Updated Description", updatedTodo.Description);
        }
        [Fact]
        public void SaveTodo_TitleIsEmpty_ReturnsErrorMessage()
        {
            var todoService = new TodoService();
            string title = "";
            string description = "Test Description";

            var result = todoService.SaveTodo(title, description);

            Assert.Equal("Заголовок не должен быть пустым", result);
        }

        [Fact]
        public void SaveTodo_ValidTitleAndDescription_ReturnsSuccessMessage()
        {
            var todoService = new TodoService();
            string title = "Test Title";
            string description = "Test Description";

            var result = todoService.SaveTodo(title, description);

            Assert.Equal("Успешное добавление", result);
            
        }
        [Fact]
        public void SaveTodo_ValidTitleAndDescriptionIsEmpty_ReturnsSuccessMessage()
        {
            var todoService = new TodoService();
            string title = "Test Title";
            string description = "";

            var result = todoService.SaveTodo(title, description);

            Assert.Equal("Успешное добавление", result);

        }
        [Fact]
        public void SaveTodo_TitleIsEmptyAndDescriptionIsEmpty_ReturnsSuccessMessage()
        {
            var todoService = new TodoService();
            string title = "";
            string description = "";

            var result = todoService.SaveTodo(title, description);

            Assert.Equal("Заголовок не должен быть пустым", result);

        }
    }
}
