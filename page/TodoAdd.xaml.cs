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
using System.Windows.Shapes;

namespace ToDo_list.page
{
    /// <summary>
    /// Логика взаимодействия для TodoCreate.xaml
    /// </summary>
    public partial class TodoCreate : Window
    {
        private readonly TodoService _todoService;
        public TodoCreate(TodoService todoService)
        {
            InitializeComponent();
            _todoService = todoService;
        }
        public TodoService todoService = new TodoService();
        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            //if(txt_title.Text != "")
            //{
            //    try
            //    {
            //        _todoService.AddTodo(txt_title.Text, new TextRange(txt_description.Document.ContentStart, txt_description.Document.ContentEnd).Text);
            //        MessageBox.Show("Успешное добавление", "Уведомление");
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show(ex.Message, "Ошибка");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Заголовок не должен быть пустым", "Уведомление");
            //}
            string title = txt_title.Text;
            string description = new TextRange(txt_description.Document.ContentStart, txt_description.Document.ContentEnd).Text;
            string resultMessage = _todoService.SaveTodo(title, description);
            MessageBox.Show(resultMessage, "Уведомление");

        }

   
    }
}
