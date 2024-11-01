using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ToDo_list
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TodoService todoService = new TodoService();
        
        public MainWindow()
        {
            InitializeComponent();
            
            list_todo.ItemsSource = todoService.GetAllTodos();
        }
        bool deleteFlag = false;

        private void btn_title_Click(object sender, RoutedEventArgs e)
        {
            Todo todo = (sender as Button).DataContext as Todo;
            if (deleteFlag) // удаление
            {
                
                todoService.DeleteTodo(todo.Id);
                list_todo.ItemsSource = todoService.GetAllTodos();
                MessageBox.Show("Удаление успешно");
                
            }
            else
            {
                page.ToDoNote toDoNote = new page.ToDoNote(todoService, todo.Id);
                toDoNote.Closed += (s, args) => list_todo.ItemsSource = todoService.GetAllTodos();
                toDoNote.Show();

            }
        }

        private void btn_create_Click(object sender, RoutedEventArgs e)
        {
            page.TodoCreate todoCreate = new page.TodoCreate(todoService);
            todoCreate.Closed += (s, args) => list_todo.ItemsSource = todoService.GetAllTodos();
            todoCreate.Show();
            
        }

        private void btn_delete_Click(object sender, RoutedEventArgs e)
        {
            deleteFlag = !deleteFlag;
            btn_delete.Background = deleteFlag ? Brushes.Red : Brushes.White;
        }
    }
}
