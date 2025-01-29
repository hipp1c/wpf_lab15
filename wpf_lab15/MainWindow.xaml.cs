using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_lab15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<ToDo> toDoList = new List<ToDo>();
        public MainWindow()
        {
            InitializeComponent();

            descriptionToDo.Text = "Описания нет";
            dateToDo.SelectedDate = new DateTime(2024, 1, 10);

            toDoList.Add(new ToDo("Приготовить покушать", new DateTime(2024, 1, 15), "Нет описания"));
            toDoList.Add(new ToDo("Поработать", new DateTime(2024, 1, 20), "Съездить на совещание в Москву"));
            toDoList.Add(new ToDo("Отдохнуть", new DateTime(2024, 2, 1), "Съездить в отпуск в Сочи"));
            toDoList.Add(new ToDo("Покормить котика", new DateTime(2024, 2, 2), "Нет описания"));
            toDoList.Add(new ToDo("Забрать посылку", new DateTime(2024, 2, 21), "Почта на ул. Крауля, 74"));
            toDoList.Add(new ToDo("Прибраться дома", new DateTime(2024, 1, 29), "Нет описания"));
            
            listToDo.ItemsSource = toDoList;
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (checkBoxToDo.IsChecked == true)
            {
                groupBoxToDo.Visibility = Visibility.Visible;
                addToDo.Visibility = Visibility.Visible;
            }
            else
            {
                groupBoxToDo.Visibility = Visibility.Hidden;
                addToDo.Visibility = Visibility.Hidden;
            }
        }

        private void addToDo_Click(object sender, RoutedEventArgs e)
        {
            if (titleToDo.Text == null || dateToDo.SelectedDate == null || titleToDo.Text == "") return;

            var todo = new ToDo();

            todo.Name = titleToDo.Text;
            titleToDo.Text = null;

            todo.Date = dateToDo.SelectedDate.Value;
            dateToDo.SelectedDate = null;

            todo.Description = descriptionToDo.Text;
            descriptionToDo.Text = "Описания нет";

            toDoList.Add(todo);
            listToDo.Items.Refresh();
        }

        private void removeToDo_Click(object sender, RoutedEventArgs e)
        {
            if (listToDo.SelectedItem == null) return;

            var todo = listToDo.SelectedItem as ToDo;

            toDoList.Remove(todo);
            listToDo.Items.Refresh();
        }
    }
}