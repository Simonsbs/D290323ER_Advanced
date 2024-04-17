using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UsersCRUDApi;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
	private HttpClient client = new HttpClient();
	private List<User> users = new List<User>();

	public MainWindow() {
		InitializeComponent();

		client.BaseAddress = new Uri("https://662005ea3bf790e070aebf48.mockapi.io/");
	}

	private async void Button_Click(object sender, RoutedEventArgs e) {
		users = await client.GetFromJsonAsync<List<User>>("users");
		UsersListBox.ItemsSource = users;
	}
}


public class User {
	[JsonPropertyName("id")]
	public int ID { get; set; }

	[JsonPropertyName("email")]
	public string Email { get; set; }

	[JsonPropertyName("name")]
	public string Name { get; set; }

	[JsonPropertyName("avatar")]
	public string Image { get; set; }
}