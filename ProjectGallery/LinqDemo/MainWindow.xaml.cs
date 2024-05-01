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
		
		//AddButtons();
	}

	private void LoadProducts() {
		string rawJson = File.ReadAllText("Products.json");
		products = JsonSerializer.Deserialize<List<Product>>(rawJson);
		ResultsDataGrid.ItemsSource = products;
	}
}
