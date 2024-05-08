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
	Random rnd = new Random();

	public MainWindow() {
		InitializeComponent();

		LoadProducts();

		AddButtons("Get All", GetAllMethod, GetAllSyntax);
		AddButtons("Get All Names", GetAllNamesMethod, GetAllNamesSyntax);
		AddButtons("Get All New Obj", GetAllNewObjMethod, GetAllNewObjSyntax);
		AddButtons("Get All New AnonObj", GetAllNewAnonObjMethod, GetAllNewAnonObjSyntax);

		AddButtons("Order By", OrderByMethod, OrderBySyntax);
		AddButtons("Use String Ext", UseStringExtension, UseStringExtension);
	}

	private void UseStringExtension(object sender, RoutedEventArgs e) {
		string result = StringExtensions.FirstLetterToUpper("simon");
		string result2 = "bob".FirstLetterToUpper();

		string name = "jim";
		name.FirstLetterToUpper();

		MessageBox.Show(result2);

		if (3.IsEven()) {
			MessageBox.Show("Im even");
		} else {
			MessageBox.Show("Im odd");
		}
		
	}

	private void OrderByMethod(object sender, RoutedEventArgs e) {
		var result =
			rawListOfProducts
							.OrderBy(product => product.CategoryId)
							.ThenByDescending(product => product.Name)
							.Select(product => product);


		//StringExtensions.ReturnAWord(result);
		//result.ReturnAWord();

		ResultsDataGrid.ItemsSource = result;
	}

	private void OrderBySyntax(object sender, RoutedEventArgs e) {
		var result =
			from product in rawListOfProducts
			orderby product.CategoryId, product.Name ascending
			select product;

		ResultsDataGrid.ItemsSource = result;
	}


	private void GetAllNewAnonObjMethod(object sender, RoutedEventArgs e) {
		var result =
			rawListOfProducts.Select(product => new {
				SomeName = product.Name,
				Source = "Method",
				Age = rnd.Next(10, 50),
				Id = product.Id
			});

		//var tmp = new {
		//	Name = "Bob"
		//};

		//var x = 1;
		//var y = new Product();
		//var z = new object();

		ResultsDataGrid.ItemsSource = result;
	}

	private void GetAllNewAnonObjSyntax(object sender, RoutedEventArgs e) {
		var result =
			from product in rawListOfProducts
			select new {
				SomeName = product.Name,
				Source = "Syntax",
				Age = rnd.Next(10, 50),
				Id = product.Id
			};

		ResultsDataGrid.ItemsSource = result;
	}


	private void GetAllNewObjMethod(object sender, RoutedEventArgs e) {
		var result =
			rawListOfProducts.Select(product => new ShortProduct {
				MyName = product.Name + " Method"
			});

		ResultsDataGrid.ItemsSource = result;
	}

	private void GetAllNewObjSyntax(object sender, RoutedEventArgs e) {

		var result =
			from product in rawListOfProducts
			select new ShortProduct {
				MyName = product.Name + " Syntax"
			};

		ResultsDataGrid.ItemsSource = result;
	}

	public class ShortProduct {
		public string MyName { get; set; }
	}

	private void GetAllNamesMethod(object sender, RoutedEventArgs e) {
		IEnumerable<string> result =
			rawListOfProducts.Select(product => product.Name);

		List<string> listOfNames = result.ToList();

		ResultsDataGrid.ItemsSource = listOfNames;
	}

	private void GetAllNamesSyntax(object sender, RoutedEventArgs e) {
		IEnumerable<string> result =
			from product in rawListOfProducts
			select product.Name;

		List<string> listOfNames = result.ToList();

		ResultsDataGrid.ItemsSource = listOfNames;
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
