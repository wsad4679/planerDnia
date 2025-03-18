using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace planerDnia;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        
    }

    public List<Task> taskList = new();
    
    void CreateTaskButtonClick(object? sender, RoutedEventArgs e)
    {
        var name = TaskName.Text;
        var category = (CategoryComboBox.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Nie wybrano kategorii";

        taskList.Add(new Task(name, category));


    }

}

public class Task
{
    public static string name;
    public static string category;

    public Task(string name, string category)
    {
        name = name;
        category = category;
    }
    
}