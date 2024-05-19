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
	public List<Category> rawListOfCategories;

	Random rnd = new Random();

	public MainWindow() {
		InitializeComponent();

		LoadProducts();
		LoadCategories();

		AddButtons("Get All", GetAllMethod, GetAllSyntax);
		AddButtons("Get All Names", GetAllNamesMethod, GetAllNamesSyntax);
		AddButtons("Get All New Obj", GetAllNewObjMethod, GetAllNewObjSyntax);
		AddButtons("Get All New AnonObj", GetAllNewAnonObjMethod, GetAllNewAnonObjSyntax);

		AddButtons("Order By", OrderByMethod, OrderBySyntax);
		//AddButtons("Use String Ext", UseStringExtension, UseStringExtension);
		AddButtons("Filter", FilterMethod, FilterSyntax);
		AddButtons("First", FirstMethod, FirstSyntax);

		AddButtons("Single", SingleOK, SingleNotOK);
		AddButtons("Take", Take5, Take2);

		AddButtons("All", All, Any);

		AddButtons("Join", JoinMethod, JoinSyntax);
	}

	private void JoinMethod(object sender, RoutedEventArgs e) {
		var result = rawListOfProducts.Join(
				rawListOfCategories,
				p => p.CategoryId,
				c => c.Id,
				(p, c) => new {
					ProductName = p.Name,
					ProductPrice = p.Price,
					CategoryName = c.Name,
					ADate = DateTime.Now,
					Simon = "IS COOL"
				}
			);

		foreach (var item in result) {
			// DO SOMETHING 
			// MessageBox.Show(item.ProductName);
		}


		ResultsDataGrid.ItemsSource = result;
	}

	private void JoinSyntax(object sender, RoutedEventArgs e) {
		/*
		 * var result = from p in rawListOfProducts
					 join c in rawListOfCategories on p.CategoryId equals c.Id
					 select new {
						 ProductName = p.Name,
						 ProductPrice = p.Price,
						 CategoryName = c.Name
					 };
		*/
		var result = from p in rawListOfProducts
					 join c in rawListOfCategories on p.CategoryId equals c.Id
					 select new FullProduct {
						 Name = p.Name,
						 Price = p.Price,
						 CategoryName = c.Name
					 };

		ResultsDataGrid.ItemsSource = result;
	}

	private void All(object sender, RoutedEventArgs e) {
		var result = rawListOfProducts
			.Where(p => p.CategoryId == 2)
			.All(p => p.Name.StartsWith("N"));

		if (result) {
			MessageBox.Show("Im True");
		} else {
			MessageBox.Show("Im False");
		}
	}

	private void Any(object sender, RoutedEventArgs e) {
		var result = rawListOfProducts
			.Any(p => p.Name.StartsWith("Z"));

		if (result) {
			MessageBox.Show("Im True");
		} else {
			MessageBox.Show("Im False");
		}
	}


	private void Take5(object sender, RoutedEventArgs e) {
		var result = rawListOfProducts.Take(5);

		ResultsDataGrid.ItemsSource = result;
	}

	private void Take2(object sender, RoutedEventArgs e) {
		var result = rawListOfProducts.Take(2..4);

		/*string helloworld = "Hello World!";
		string subString = helloworld[^5..^1];

		MessageBox.Show(subString);*/

		ResultsDataGrid.ItemsSource = result;

	}

	private void SingleOK(object sender, RoutedEventArgs e) {
		var result =
			rawListOfProducts
							.OrderBy(product => product.CategoryId)
							.Where(product => product.CategoryId == 2)
							.Single();

		if (result == null) {
			ResultsDataGrid.ItemsSource = null;
		} else {
			ResultsDataGrid.ItemsSource = new List<Product>() { result };
		}
	}

	private void SingleNotOK(object sender, RoutedEventArgs e) {
		var result =
			rawListOfProducts
							.OrderBy(product => product.CategoryId)
							.Where(product => product.CategoryId == 999)
							.SingleOrDefault();

		if (result == null) {
			ResultsDataGrid.ItemsSource = null;
		} else {
			ResultsDataGrid.ItemsSource = new List<Product>() { result };
		}
	}

	private void FirstMethod(object sender, RoutedEventArgs e) {
		var result =
			rawListOfProducts
							.OrderBy(product => product.CategoryId)
							//.Where(product => product.CategoryId == 2)
							.FirstOrDefault();

		if (result == null) {
			ResultsDataGrid.ItemsSource = null;
		} else {
			ResultsDataGrid.ItemsSource = new List<Product>() { result };
		}
	}

	private void FirstSyntax(object sender, RoutedEventArgs e) {
		var result =
			from product in rawListOfProducts
			orderby product.CategoryId
			select product;

		var singleResult = result.FirstOrDefault();

		if (singleResult == null) {
			ResultsDataGrid.ItemsSource = null;
		} else {
			ResultsDataGrid.ItemsSource = new List<Product>() { singleResult };
		}
	}

	private void FilterMethod(object sender, RoutedEventArgs e) {
		var result =
			rawListOfProducts
							.OrderBy(product => product.CategoryId)
							.Where(product => product.Name.StartsWith("C") && product.CategoryId == 7)
							.Select(product => product);

		ResultsDataGrid.ItemsSource = result;
	}

	private void FilterSyntax(object sender, RoutedEventArgs e) {
		var result =
			from product in rawListOfProducts
			where product.Name.StartsWith("B") || product.CategoryId == 1
			select product;

		ResultsDataGrid.ItemsSource = result;
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

	private void LoadCategories() {
		string rawJson = File.ReadAllText("Categories.json");
		rawListOfCategories = JsonSerializer.Deserialize<List<Category>>(rawJson);
		//ResultsDataGrid.ItemsSource = rawListOfProducts;
	}
}
