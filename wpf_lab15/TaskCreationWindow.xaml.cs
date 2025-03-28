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
    public partial class TaskCreationWindow : Window
    {
        public static RoutedCommand AddTaskCommand = new RoutedCommand();
        public TaskCreationWindow()
        {
            InitializeComponent();

            descriptionToDo.Text = "Описания нет";
            dateToDo.SelectedDate = DateTime.Now;
        }

        private void CreateTaskButton(object sender, RoutedEventArgs e)
        {
            if (titleToDo.Text == null ||
                dateToDo.SelectedDate == null ||
                titleToDo.Text == "")
                return;

            var todo = new Task();

            todo.Name = titleToDo.Text;
            titleToDo.Text = null;

            todo.Date = dateToDo.SelectedDate.Value;
            dateToDo.SelectedDate = null;

            todo.Description = descriptionToDo.Text;
            descriptionToDo.Text = "Описания нет";

            MainWindow.TaskList.Add(todo);

            var o = Owner as MainWindow;

            o.TaskListBox.ItemsSource = null;
            o.TaskListBox.ItemsSource = MainWindow.TaskList;

            o.UpdateTaskProgressBar();

            this.Close();

        }
    }
}