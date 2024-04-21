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

namespace Recursive;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window {
	public MainWindow() {
		InitializeComponent();
	}

	private void Button_Click(object sender, RoutedEventArgs e) {
		if (int.TryParse(UserInput.Text, out int number)) {
			int result = Factorial(number);

			Result.Text = $"The Factorial of {number}! result is: {result}";
		} else {
			Result.Text = "Invalid value, enter a number";
		}
	}

	private int Factorial(int n) {
		if (n <= 1) {
			return (n * 1);
		}

		int calcRestOfFactorial = Factorial(n - 1);

		return n * calcRestOfFactorial;
	}
}