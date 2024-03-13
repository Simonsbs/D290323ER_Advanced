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

namespace HelloWPF;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
	public MainWindow() {
		InitializeComponent();

		
	}

	private void MyButton_OnClick(object sender, RoutedEventArgs e) {
		//MessageBox.Show("Hello, WPF!");
		//MyButton.Content = "Clicked!!";
	}

	private void AddUser_Click(object sender, RoutedEventArgs e) {
		MessageBox.Show("Add a user");
	}
}