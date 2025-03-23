using System.Collections.Generic;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Layout;
using Avalonia.Media;

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
    
        var task = new Task(name, category);
        
        TaskWrapPanel.Children.Add(task.stackPanel);
        
    }

}

public class Task
{
    public string name;
    public string category;
    public StackPanel stackPanel;
    public Button removeButton;
    public TextBlock textBlock;
 

    public Task(string inputName, string inputCategory)
    {
        name = inputName;
        category = inputCategory;

        
        stackPanel = new StackPanel
        {
            Orientation = Orientation.Vertical,
            Margin = new Thickness(5)
        };
        
        textBlock = new TextBlock
        {
            Text = $"{inputCategory}: {inputName}",
            TextWrapping = TextWrapping.Wrap,
            TextAlignment = TextAlignment.Center,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
        };

        removeButton = new Button
        {
            Content = "Usuń",
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
        };
        
        stackPanel.Children.Add(removeButton);
        stackPanel.Children.Add(textBlock);

    }
    
}