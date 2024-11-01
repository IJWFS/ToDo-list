using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ToDo_list.page
{
    /// <summary>
    /// Логика взаимодействия для ToDoNote.xaml
    /// </summary>
    public partial class ToDoNote : Window
    {
        private readonly TodoService _todoService;
        int Id;
        public ToDoNote(TodoService todoService, int id)
        {
            InitializeComponent();
            _todoService = todoService;
            Id = id;
            txt_title.Text = _todoService.GetAllTodos().Where(x => x.Id == Id).First().Title;
            txt_description.Text = _todoService.GetAllTodos().Where(x => x.Id == Id).First().Description;
        }

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            _todoService.UpdateTodo(Id, txt_title.Text, txt_description.Text);
            MessageBox.Show("Изменение успешно");
        }
    }
}
