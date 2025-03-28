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
using System.Text.Json;
using Microsoft.Win32;
using System.IO;

namespace wpf_lab15
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public static List<Task>? TaskList { get; set; }
        private static string _currentDirectory;
        private static string _jsonPath;
        

        public MainWindow()
        {
            InitializeComponent();

            LoadTaskList();

            UpdateTaskProgressBar();
        }

        private void LoadTaskList()
        {
            _currentDirectory = Directory.GetCurrentDirectory();
            _jsonPath = System.IO.Path.Combine(_currentDirectory, "json.txt");
            TaskList = new List<Task>();

            if (!File.Exists(_jsonPath))
            {
                return;
            }

            string json = File.ReadAllText(_jsonPath);

            TaskList = JsonSerializer.Deserialize<List<Task>>(json);

            TaskListBox.ItemsSource = TaskList;
        }

        public void UpdateTaskProgressBar()
        {
            int countIsDoing = TaskList.Where(x => x.IsDoing).Count();
            ProgressBar.Minimum = 0;
            ProgressBar.Maximum = TaskList.Count;
            ProgressBar.Value = countIsDoing;
            ProgressBarText.Text = $"{countIsDoing}/{TaskList.Count}";
        }

        private void AddTaskButton(object sender, RoutedEventArgs e)
        {
            TaskCreationWindow _windowToDoList = new TaskCreationWindow();
            _windowToDoList.Owner = this;
            _windowToDoList.Show();
        }

        private void CheckBoxUnchecked(object sender, RoutedEventArgs e)
        {
            var task = (sender as CheckBox).DataContext as Task;

            task.IsDoing = false;

            UpdateTaskProgressBar();
        }

        private void CheckBoxChecked(object sender, RoutedEventArgs e)
        {
            var task = (sender as CheckBox).DataContext as Task;

            task.IsDoing = true;

            UpdateTaskProgressBar();
        }

        private void SaveTaskButton(object sender, ExecutedRoutedEventArgs e)
        {
            SaveTask();
        }

        private void SaveTask()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Normal text file (*.txt)|*.txt";

            if (saveFileDialog.ShowDialog() == true)
            {
                if (TaskList.Count == 0)
                {
                    MessageBox.Show("В списке нет дел");
                    return;
                }

                string text = "";

                foreach (Task item in TaskList)
                {
                    text += item.ToString();
                }

                string json = JsonSerializer.Serialize(TaskList);

                File.WriteAllText(saveFileDialog.FileName, text);
                File.WriteAllText(_jsonPath, json);

            }
        }

        private void DeleteTaskButton(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите удалить дело?", "655", MessageBoxButton.YesNo);;

            if (result.HasFlag(MessageBoxResult.No))
            {
                return;
            }

            if(sender is Button)
            {
                var task = (sender as Button).DataContext as Task;
                TaskList?.Remove(task);
            }
            else
            {
                TaskList.Remove(TaskListBox.SelectedItem as Task);
            }

            TaskListBox.ItemsSource = null;
            TaskListBox.ItemsSource = TaskList;
            UpdateTaskProgressBar();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveTask();
        }
    }
}