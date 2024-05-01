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
	public List<Product> rawListOfProducts;

	public MainWindow() {
		InitializeComponent();

		LoadProducts();
		
		AddButtons("Get All", GetAllMethod, GetAllSyntax);
	}

	private void GetAllMethod(object sender, RoutedEventArgs e) {
		IEnumerable<Product> result =
			rawListOfProducts.Select(product => product);

		ResultsDataGrid.ItemsSource = result;
	}

	private void GetAllSyntax(object sender, RoutedEventArgs e) {
		IEnumerable<Product> result = 
			from product in rawListOfProducts
			select product;

		ResultsDataGrid.ItemsSource = result;
	}

	private void AddButtons(string name, 
		RoutedEventHandler clickMethod, 
		RoutedEventHandler clickSyntax) {

		StackPanel stackPanel = new StackPanel() {
			Orientation = Orientation.Horizontal
		};
		ButtonStack.Children.Add(stackPanel);

		Button btnMethod = new Button {
			Margin = new Thickness(5),
			Padding = new Thickness(5),
			FontSize = 15,
			Content = name + " (M)"
		};
		btnMethod.Click += clickMethod;

		stackPanel.Children.Add(btnMethod);

		Button btnSyntax = new Button {
			Margin = new Thickness(5),
			Padding = new Thickness(5),
			FontSize = 15,
			Content = name + " (S)"
		};
		btnSyntax.Click += clickSyntax;

		stackPanel.Children.Add(btnSyntax);
	}

	private void LoadProducts() {
		string rawJson = File.ReadAllText("Products.json");
		rawListOfProducts = JsonSerializer.Deserialize<List<Product>>(rawJson);
		//ResultsDataGrid.ItemsSource = rawListOfProducts;
	}
}
