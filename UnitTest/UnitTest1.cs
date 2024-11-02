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
            // Arrange
            var todoService = new TodoService();

            // Act
            var todo = todoService.AddTodo("Test Title", "Test Description");

            // Assert
            Assert.NotNull(todo);
            Assert.Equal(0, todo.Id);
            Assert.Equal("Test Title", todo.Title);
            Assert.Equal("Test Description", todo.Description);
            Assert.Single(todoService.GetAllTodos());
        }

        [Fact]
        public void GetAllTodos_ShouldReturnAllTodos()
        {
            // Arrange
            var todoService = new TodoService();
            todoService.AddTodo("Title 1", "Description 1");
            todoService.AddTodo("Title 2", "Description 2");

            // Act
            var todos = todoService.GetAllTodos();

            // Assert
            Assert.Equal(2, todos.Count);
            Assert.Contains(todos, t => t.Title == "Title 1" && t.Description == "Description 1");
            Assert.Contains(todos, t => t.Title == "Title 2" && t.Description == "Description 2");
        }

        [Fact]
        public void DeleteTodo_ShouldDeleteTodo()
        {
            // Arrange
            var todoService = new TodoService();
            var todo = todoService.AddTodo("Test Title", "Test Description");

            // Act
            var result = todoService.DeleteTodo(todo.Id);

            // Assert
            Assert.True(result);
            Assert.Empty(todoService.GetAllTodos());
        }

        [Fact]
        public void UpdateTodo_ShouldUpdateTodo()
        {
            // Arrange
            var todoService = new TodoService();
            var todo = todoService.AddTodo("Test Title", "Test Description");

            // Act
            var result = todoService.UpdateTodo(todo.Id, "Updated Title", "Updated Description");

            // Assert
            Assert.True(result);
            var updatedTodo = todoService.GetAllTodos().First();
            Assert.Equal("Updated Title", updatedTodo.Title);
            Assert.Equal("Updated Description", updatedTodo.Description);
        }
    }
}
