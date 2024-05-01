using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LinqDemo;
public partial class MainWindow : Window {
	List<Product> products;

	public MainWindow() {
		InitializeComponent();

		LoadProducts();
		
		AddButtons();
		AddButtons();
		AddButtons();
		AddButtons();
	}

	private void AddButtons() {
		StackPanel stackPanel = new StackPanel() {
			Orientation = Orientation.Horizontal
		};
		ButtonStack.Children.Add(stackPanel);

		Button btnMethod = new Button {
			Margin = new Thickness(5),
			Padding = new Thickness(5),
			FontSize = 15,
			Content = "Method 1"
		};
		stackPanel.Children.Add(btnMethod);

		Button btnSyntax = new Button {
			Margin = new Thickness(5),
			Padding = new Thickness(5),
			FontSize = 15,
			Content = "Syntax 1"
		};
		stackPanel.Children.Add(btnSyntax);
	}

	private void LoadProducts() {
		string rawJson = File.ReadAllText("Products.json");
		products = JsonSerializer.Deserialize<List<Product>>(rawJson);
		ResultsDataGrid.ItemsSource = products;
	}
}
