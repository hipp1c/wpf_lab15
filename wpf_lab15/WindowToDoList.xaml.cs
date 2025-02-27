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

namespace wpf_lab15
{
    public partial class WindowToDoList : Window
    {

        public WindowToDoList()
        {
            InitializeComponent();

            descriptionToDo.Text = "Описания нет";
            dateToDo.SelectedDate = new DateTime(2024, 1, 10);
        }

        private void SaveToDo(object sender, RoutedEventArgs e)
        {
            if (titleToDo.Text == null ||
                dateToDo.SelectedDate == null ||
                titleToDo.Text == "")
                return;

            var todo = new ToDo();

            todo.Name = titleToDo.Text;
            titleToDo.Text = null;

            todo.Date = dateToDo.SelectedDate.Value;
            dateToDo.SelectedDate = null;

            todo.Description = descriptionToDo.Text;
            descriptionToDo.Text = "Описания нет";

            MainWindow.ToDoList.Add(todo);

            var o = Owner as MainWindow;

            o.listToDo.ItemsSource = null;
            o.listToDo.ItemsSource = MainWindow.ToDoList;

            o.EndToDo();

            this.Close();

        }
    }
}