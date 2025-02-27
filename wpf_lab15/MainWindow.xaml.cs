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

        public static List<ToDo>? ToDoList { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            ToDoList = new List<ToDo>();

            ToDoList.Add(new ToDo("Приготовить покушать", new DateTime(2024, 1, 15), "Нет описания"));
            ToDoList.Add(new ToDo("Поработать", new DateTime(2024, 1, 20), "Съездить на совещание в Москву"));
            ToDoList.Add(new ToDo("Отдохнуть", new DateTime(2024, 2, 1), "Съездить в отпуск в Сочи"));
            ToDoList.Add(new ToDo("Покормить котика", new DateTime(2024, 2, 2), "Нет описания"));
            ToDoList.Add(new ToDo("Забрать посылку", new DateTime(2024, 2, 21), "Почта на ул. Крауля, 74"));
            ToDoList.Add(new ToDo("Прибраться дома", new DateTime(2024, 1, 29), "Нет описания"));

            listToDo.ItemsSource = ToDoList;

            EndToDo();
        }

        public void EndToDo()
        {
            int countIsDoing = ToDoList.Where(x => x.IsDoing).Count();
            ProgressBar.Minimum = 0;
            ProgressBar.Maximum = ToDoList.Count;
            ProgressBar.Value = countIsDoing;
            ProgressBarText.Text = $"{countIsDoing}/{ToDoList.Count}";
        }

        private void AddToDo(object sender, RoutedEventArgs e)
        {
            WindowToDoList _windowToDoList = new WindowToDoList();
            _windowToDoList.Owner = this;
            _windowToDoList.Show();
        }

        private void RemoveToDo(object sender, RoutedEventArgs e)
        {
            var todo = (sender as Button).DataContext as ToDo;

            ToDoList?.Remove(todo);
            listToDo.Items.Refresh();

            EndToDo();
        }

        private void CheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            var todo = (sender as CheckBox).DataContext as ToDo;

            todo.IsDoing = false;

            EndToDo();
        }

        private void CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            var todo = (sender as CheckBox)?.DataContext as ToDo;

            todo.IsDoing = true;

            EndToDo();
        }
    }
}