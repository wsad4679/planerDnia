using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        var categoryList = new List<string>();
        foreach (var item in CategoryComboBox.Items)
        {
            categoryList.Add(item.ToString());
        }
        
        var task = new Task(name, category, TaskWrapPanel, categoryList);
        
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
    public WrapPanel parentPanel;
    public CheckBox czyUkonczoneCheckBox;
    public List<string> categoryList;
    public ComboBox categoryComboBox;
 

    public Task(string inputName, string inputCategory, WrapPanel parentPanel, List<string> inputCategoryList)
    {
        name = inputName;
        category = inputCategory;
        categoryList = new List<string> { "Nic", "Praca", "Rozrywka", "Trening", "Spotkanie" };
        
        stackPanel = new StackPanel
        {
            Orientation = Orientation.Vertical,
            Margin = new Thickness(5),
            Background = Brushes.DarkGray
        };
        
        categoryComboBox = new ComboBox
        {
            
            ItemsSource = categoryList, 
            SelectedItem = categoryList.Contains(inputCategory) ? inputCategory : "" ,
            Margin = new Thickness(5)
        };
        
        textBlock = new TextBlock
        {
            Text = $"{inputName}",
            TextWrapping = TextWrapping.Wrap,
            TextAlignment = TextAlignment.Center,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
        };

        czyUkonczoneCheckBox = new CheckBox
        {
            Content = "Czy ukończone: ",
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            Margin = new Thickness(10)
        };

        removeButton = new Button
        {
            Content = "Usuń",
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center
        };
        removeButton.Click += (_, _) => parentPanel.Children.Remove(stackPanel);
        
        stackPanel.Children.Add(categoryComboBox);
        stackPanel.Children.Add(textBlock);
        stackPanel.Children.Add(czyUkonczoneCheckBox);
        stackPanel.Children.Add(removeButton);

    }
    
}